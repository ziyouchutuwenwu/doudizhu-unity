using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserSitOnDeskDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserSitOnDeskObject sitOnDeskObject = ModelManager.shareInstance().getUserSitOnDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            bool isError = Convert.ToBoolean(data["error"]);
            string deskId = Convert.ToString(data["deskId"]);

            Dictionary<string, object> leftUserJsonObject = data["leftUser"] as Dictionary<string, object>;
            string leftUserId = Convert.ToString(leftUserJsonObject["id"]);

            bool isLeftUserOnline = Convert.ToBoolean(leftUserJsonObject["online"]);
            string leftUserGender = Convert.ToString(leftUserJsonObject["gender"]);

            Dictionary<string, object> rightUserJsonObject = data["rightUser"] as Dictionary<string, object>;
            string rightUserId = Convert.ToString(rightUserJsonObject["id"]);
            bool isRightUserOnline = Convert.ToBoolean(rightUserJsonObject["online"]);
            string rightUserGender = Convert.ToString(rightUserJsonObject["gender"]);

            sitOnDeskObject.setError(isError);
            if (isError) return;

            deskObject.setId(deskId);

            //left
            leftUserObject.setId(leftUserId);
            if (leftUserGender.ToLower() == "male")
            {
                leftUserObject.setGender(UserObject.Gender.MALE);
            }
            if (leftUserGender.ToLower() == "female")
            {
                leftUserObject.setGender(UserObject.Gender.FEMALE);
            }
            if ( isLeftUserOnline)
            {
                leftUserObject.setOnline(UserObject.OnLineType.ONLINE);
            }
            else
            {
                leftUserObject.setOnline(UserObject.OnLineType.OFFLINE);
            }

            //right
            rightUserObject.setId(rightUserId);
            if (rightUserGender.ToLower() == "male")
            {
                rightUserObject.setGender(UserObject.Gender.MALE);
            }
            if (rightUserGender.ToLower() == "female")
            {
                rightUserObject.setGender(UserObject.Gender.FEMALE);
            }
            if (isRightUserOnline)
            {
                rightUserObject.setOnline(UserObject.OnLineType.ONLINE);
            }
            else
            {
                rightUserObject.setOnline(UserObject.OnLineType.OFFLINE);
            }
        }
    }
}
