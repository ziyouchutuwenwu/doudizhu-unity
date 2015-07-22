using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientSocket.Foundation.Codec
{
    public class GenCodec
    {
        public static byte[] encode(short cmd,byte[] data)
        {
            byte[] cmdArray = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(cmd));
            byte[] dataBytes = new byte[cmdArray.Length + data.Length];

            Array.Copy(cmdArray, 0, dataBytes, 0, cmdArray.Length);
            Array.Copy(data, 0, dataBytes, cmdArray.Length, data.Length);

            return dataBytes;
        }

        public static void decode(byte[] fullData, int fullDataLen,out short cmd, out byte[] dataBytes)
        {
            dataBytes = new byte[fullDataLen - 2];

            cmd = System.Net.IPAddress.NetworkToHostOrder(BitConverter.ToInt16(fullData, 0));
            Array.Copy(fullData, 2, dataBytes, 0, fullDataLen - 2);
        }
    }
}