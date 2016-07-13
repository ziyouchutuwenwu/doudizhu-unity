using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ClientSocket.Foundation
{
	public class PackageHeader
	{
		private static int HEADER_SIZE_2 = 2;
    	private static int HEADER_SIZE_4 = 4;

		public static int size()
		{
			return HEADER_SIZE_2;
		}

		public static byte[] setDataSizeBytes(int dataSize)
		{
			byte[] dataSizeBytes = null;

			if ( size() == HEADER_SIZE_2 ) 
			{
				dataSizeBytes = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder((short)dataSize));
			}
			else if ( size() == HEADER_SIZE_4 )
			{
				dataSizeBytes = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(dataSize));
			}

	        return dataSizeBytes;
    	}

    	public static int getHeaderDataLen(byte[] buffer)
		{
	        int headerDataLen = 0;

	        if ( size() == HEADER_SIZE_2 )
			{
				headerDataLen = (int)System.Net.IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 0));
	        }
			else if ( size() == HEADER_SIZE_4 )
	        {
				headerDataLen = (int)System.Net.IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
	        }

	        return headerDataLen;
    	}

	}
}
