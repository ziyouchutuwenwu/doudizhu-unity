using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;

namespace NetworkRequest
{
    class UserSitOnDeskController: ISocketResponse
    {
        public void onReceiveData(short cmd, string response)
        {
            if (cmd == SocketConst.CMD_USER_SIT_ON_DESK)
            {
                UserSitOnDeskDecoder.decode(response);
                ReceivedDataStatusQueue.shareInstance().addStatus(cmd);
            }
        }
    }
}