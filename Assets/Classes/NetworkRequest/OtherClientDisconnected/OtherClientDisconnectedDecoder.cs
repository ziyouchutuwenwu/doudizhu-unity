using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class OtherClientDisconnectedDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            string disconnectedUserId = Convert.ToString(data["disconnectUserId"]);

            if (disconnectedUserId == leftUserObject.getId())
            {
                leftUserObject.setOnline(UserObject.OnLineType.OFFLINE);
            }
            if (disconnectedUserId == rightUserObject.getId())
            {
                rightUserObject.setOnline(UserObject.OnLineType.OFFLINE);
            }
            if (disconnectedUserId == selfUserObject.getId())
            {
                selfUserObject.setOnline(UserObject.OnLineType.OFFLINE);
            }
        }
    }
}