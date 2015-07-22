using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;

namespace NetworkRequest
{
    class DeskJiaoDiZhuFinishController : ISocketResponse
    {
        public void onReceiveData(short cmd, string response)
        {
            if (cmd == SocketConst.CMD_DESK_JIAO_DI_ZHU_FINISH)
            {
                DeskJiaoDiZhuFinishDecoder.decode(response);
                ReceivedDataStatusQueue.shareInstance().addStatus(cmd);
            }
        }
    }
}