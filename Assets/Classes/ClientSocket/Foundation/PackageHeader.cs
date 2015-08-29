using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ClientSocket.Foundation
{
	public class PackageHeader
	{
		//4字节，用于拆包
		public static int size()
		{
			return 4;
		}
	}
}
