using System;
using ClientSocket.Business;
using UnityEngine;

namespace NetworkRequest
{
    class ClientStatusController : ISocketStatus
    {
        public void onConnectSuccess()
        {
            ReceivedDataStatusQueue.shareInstance().addStatus(SocketConst.CMD_CLIENT_CONNECTED);
        }

        public void onConnectFail()
        {
            ReceivedDataStatusQueue.shareInstance().addStatus(SocketConst.CMD_CLIENT_CONNECTED_FAIL);
        }

        public void onDisconnect()
        {
            ReceivedDataStatusQueue.shareInstance().addStatus(SocketConst.CMD_CLIENT_DISCONNECTED);
        }
    }
}