using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserLeaveDeskDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            string leaveUserId = Convert.ToString(data["leaveUserId"]);

            if (leaveUserId == leftUserObject.getId())
            {
                leftUserObject.reset();
            }
            if (leaveUserId == rightUserObject.getId())
            {
                rightUserObject.reset();
            }
            if (leaveUserId == selfUserObject.getId())
            {
                //id，性别等等当然必须保存
                selfUserObject.resetPlaying();
            }
        }
    }
}