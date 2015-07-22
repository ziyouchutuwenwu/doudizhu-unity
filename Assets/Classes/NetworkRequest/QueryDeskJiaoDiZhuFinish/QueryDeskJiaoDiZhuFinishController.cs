using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;

namespace NetworkRequest
{
    class QueryDeskJiaoDiZhuFinishController : ISocketResponse
    {
        public void onReceiveData(short cmd, string response)
        {
            if (cmd == SocketConst.CMD_QUERY_DESK_JIAO_DI_ZHU_FINISH)
            {
                QueryDeskJiaoDiZhuFinishDecoder.decode(response);
                ReceivedDataStatusQueue.shareInstance().addStatus(cmd);
            }
        }
    }
}