using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;

namespace NetworkRequest
{
    class UserPromptReadyController : ISocketResponse
    {
        public void onReceiveData(short cmd, string response)
        {
            if (cmd == SocketConst.CMD_USER_PROMPT_READY)
            {
                ReceivedDataStatusQueue.shareInstance().addStatus(cmd);
            }
        }
    }
}