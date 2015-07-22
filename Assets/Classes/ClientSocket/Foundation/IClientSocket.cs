using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientSocket.Foundation
{
    interface IClientSocket
    {
        void onConnectSuccess();
        void onConnectFail();
        void onDisconnect();

        void onReceiveData(byte[] data,int length);

        void onSendSuccess(byte[] data);
        void onSendFail(byte[] data);
    }
}