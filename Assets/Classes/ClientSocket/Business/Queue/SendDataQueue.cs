using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClientSocket.Business
{
	class SendDataQueue
	{
        private static SendDataQueue _instance = null;
        private Queue _queue = null;

        public static SendDataQueue shareInstance()
        {
            if (null == _instance)
            {
                _instance = new SendDataQueue();
            }
            return _instance;
        }

        private SendDataQueue()
        {
            _queue = new Queue();
        }

        public int getSize()
        {
            return _queue.Count;
        }

        public byte[] getDataBytes()
        {
            return (byte[])_queue.Peek();
        }

        public void addDataBytes(byte[] dataBytes)
        {
            lock (_queue)
            {
                _queue.Enqueue(dataBytes);
            }
        }

        public void removeDataBytes()
        {
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    _queue.Dequeue();
                }
            }
        }

        public void clear()
        {
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    _queue.Clear();
                }
            }
        }
	}
}
