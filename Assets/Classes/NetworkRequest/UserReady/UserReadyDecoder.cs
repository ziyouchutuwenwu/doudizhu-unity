using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserReadyDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            string readyUserId = Convert.ToString(data["readyUserId"]);

            if (readyUserId == leftUserObject.getId())
            {
                leftUserObject.setReady(true);
            }
            if (readyUserId == rightUserObject.getId())
            {
                rightUserObject.setReady(true);
            }
            if (readyUserId == selfUserObject.getId())
            {
                selfUserObject.setReady(true);
            }
        }
    }
}
