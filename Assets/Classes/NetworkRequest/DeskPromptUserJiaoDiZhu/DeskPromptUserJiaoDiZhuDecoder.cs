using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskPromptUserJiaoDiZhuDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskJiaoDiZhuObject deskJiaoDiZhuObject = ModelManager.shareInstance().getDeskJiaoDiZhuObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            string canJiaoDiZhuUserId = Convert.ToString(data["canJiaoDiZhuUserId"]);

            if (canJiaoDiZhuUserId == leftUserObject.getId())
            {
                deskJiaoDiZhuObject.setNextUserObject(leftUserObject);
            }
            if (canJiaoDiZhuUserId == rightUserObject.getId())
            {
                deskJiaoDiZhuObject.setNextUserObject(rightUserObject);
            }
            if (canJiaoDiZhuUserId == selfUserObject.getId())
            {
                deskJiaoDiZhuObject.setNextUserObject(selfUserObject);
            }
        }
    }
}