using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace ClientSocket.Foundation
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PackageHeader
    {
       public uint wDataLen;//此项是必须的，不可省略，用于拆包
       
        public short wCmdType;//此项不必须，用于在处理socket业务封包
    }
}