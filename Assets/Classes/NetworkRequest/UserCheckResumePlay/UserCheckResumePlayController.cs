using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;

namespace NetworkRequest
{
    class UserCheckResumePlayController : ISocketResponse
    {
        public void onReceiveData(short cmd, string response)
        {
            if (cmd == SocketConst.CMD_USER_CHECK_RESUME_PLAY)
            {
                UserCheckResumePlayDecoder.decode(response);
                ReceivedDataStatusQueue.shareInstance().addStatus(cmd);
            }
        }
    }
}