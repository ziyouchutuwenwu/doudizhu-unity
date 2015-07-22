using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientSocket.Business
{
    public interface ISocketStatus
    {
        void onConnectSuccess();
        void onConnectFail();
        void onDisconnect();
    }
}
