using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;

namespace ClientSocket.Foundation
{
    class CClientSocket
    {
        private Socket _socket = null;
        private IClientSocket _callBack = null;
        private Thread _readThread = null;

        private byte[] _savedBuffer = null;
        private int _savedBufferSize = 0;
        private int _packageMaxSize = 0;

        public void init()
        {
            _savedBuffer = new byte[BufferConst.SAVED_BUFFER_CAP];
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void setDelegate(IClientSocket callBack)
        {
            _callBack = callBack;
        }

        public void setPackageMaxSize(int packageMaxSize)
        {
            _packageMaxSize = packageMaxSize;
        }

        //支持超时的connect
        public void connectWithTimeout(String ip, int port, int timeout)
        {
            AutoResetEvent connectDone = new AutoResetEvent(false);

            try
            {
                _socket.BeginConnect(ip, port,
                    new AsyncCallback(
                        delegate(IAsyncResult ar)
                        {
                            _socket.EndConnect(ar);
                            connectDone.Set();
                        }
                    ), _socket);
            }
            catch
            {
            }

            if (!connectDone.WaitOne(timeout))
            {
                if (null != _callBack) _callBack.onConnectFail();
            }
            else
            {
                if (null != _callBack) _callBack.onConnectSuccess();
            }
        }

        public void disConnect()
        {
            _socket.Close();

            if (null != _callBack) _callBack.onDisconnect();
        }

        public void sendData(byte[] data)
        {
			//包头内数据长度不包括包头长度
			byte[] headerSizeBytes = new byte[PackageHeader.size()];
			byte[] sendBuffer = new byte[BufferConst.SEND_BUFFER_CAP];

			int dataSize = data.Length;
			int totalSendSize = headerSizeBytes.Length + dataSize;

			byte[] dataSizeBytes = PackageHeader.setDataSizeBytes (dataSize);

			Array.Copy(dataSizeBytes, 0, headerSizeBytes, 0, dataSizeBytes.Length);

			Array.Copy(headerSizeBytes, 0, sendBuffer, 0, headerSizeBytes.Length);
			Array.Copy(data, 0, sendBuffer, headerSizeBytes.Length, data.Length);

            if (null != _socket && 0 != data.Length)
            {
                bool isSendSuccess = false;
                try
                {
                    if ( _socket.Send(sendBuffer, totalSendSize, 0) > 0)
                    {
                        isSendSuccess = true;
                    }
                }
                catch
                {
                    isSendSuccess = false;
                }
                if (isSendSuccess)
                {
                    if (null != _callBack) _callBack.onSendSuccess(data);
                }
                else
                {
                    if (null != _callBack) _callBack.onSendFail(data);
                }
            }
        }

        public void startReadLoop()
        {
            _readThread = new Thread(new ThreadStart(loopRead));
            _readThread.Start();
        }

        private void loopRead()
        {
            int receivedLen = 0;
            _savedBufferSize = 0;

            byte[] readBuffer = new byte[BufferConst.READ_BUFFER_CAP];
            byte[] totalBytes = new byte[BufferConst.TOTAL_BUFFER_CAP];

            byte[] completeData = new byte[BufferConst.READ_BUFFER_CAP];

            //循环接收
            while(true)
            {
                receivedLen = _socket.Receive(readBuffer, BufferConst.READ_BUFFER_CAP, 0);
                if (receivedLen <= 0)
                {
                    if (null != _callBack) _callBack.onDisconnect();
                    break;
                }

                Array.Clear(totalBytes, 0, totalBytes.Length);
                Array.Copy(_savedBuffer, totalBytes, _savedBufferSize);
                Array.Copy(readBuffer, 0,totalBytes,_savedBufferSize, receivedLen);

                int totalSize = _savedBufferSize + receivedLen;
                int loopBufferPos = 0;

                //单次拆包循环
                while (true)
                {
                    byte[] loopBuffer = new byte[BufferConst.TOTAL_BUFFER_CAP];
                    int loopBufferLen = totalSize - loopBufferPos;

                    Array.Copy(totalBytes, loopBufferPos, loopBuffer, 0, loopBufferLen);

					if (loopBufferLen < PackageHeader.size() ) break;
					int headerDataLen = PackageHeader.getHeaderDataLen(loopBuffer);

					//不能太小，也不能太长
          			if ( loopBufferLen < headerDataLen || loopBufferLen > _packageMaxSize ) break;

					//完整数据包readBufferWithSavedBytes + loopBufferPos，给上层的时候，需要去掉包头长度
					Array.Clear(completeData, 0, completeData.Length);
					Array.Copy(totalBytes, loopBufferPos + PackageHeader.size(), completeData, 0, headerDataLen);
					if (null != _callBack) _callBack.onReceiveData(completeData, headerDataLen);

					loopBufferPos += headerDataLen + PackageHeader.size();
                }

                Array.Clear(_savedBuffer, 0, _savedBufferSize);
                _savedBufferSize = 0;

                Array.Copy(totalBytes, loopBufferPos, _savedBuffer, 0, totalSize - loopBufferPos);
                _savedBufferSize = totalSize - loopBufferPos;
            }
        }
    }
}
