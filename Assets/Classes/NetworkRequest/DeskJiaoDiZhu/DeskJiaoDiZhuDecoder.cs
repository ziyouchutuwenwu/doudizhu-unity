using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskJiaoDiZhuDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskJiaoDiZhuObject deskJiaoDiZhuObject = ModelManager.shareInstance().getDeskJiaoDiZhuObject();

            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            //secondPreviousUser
            Dictionary<string, object> secondPreviousUserJsonObject = data["secondPreviousUser"] as Dictionary<string, object>;
            string secondPreviousUserId = Convert.ToString(secondPreviousUserJsonObject["id"]);
            bool isSecondPreviousUserJiaoDiZhu = Convert.ToBoolean(secondPreviousUserJsonObject["jiaoDiZhu"]);
            bool isSecondPreviousUserFirstJiaoDiZhu = Convert.ToBoolean(secondPreviousUserJsonObject["isFirstJiaoDiZhu"]);

            //firstPreviousUser
            Dictionary<string, object> firstPreviousUserJsonObject = data["firstPreviousUser"] as Dictionary<string, object>;
            string firstPreviousUserId = Convert.ToString(firstPreviousUserJsonObject["id"]);
            bool isFirstPreviousUserJiaoDiZhu = Convert.ToBoolean(firstPreviousUserJsonObject["jiaoDiZhu"]);
            bool isFirstPreviousUserFirstJiaoDiZhu = Convert.ToBoolean(firstPreviousUserJsonObject["isFirstJiaoDiZhu"]);

            //nextUser
            Dictionary<string, object> nextUserJsonObject = data["nextUser"] as Dictionary<string, object>;
            string nextUserId = Convert.ToString(nextUserJsonObject["id"]);
            bool isNextUserFirstJiaoDiZhu = Convert.ToBoolean(nextUserJsonObject["isFirstJiaoDiZhu"]);

            deskJiaoDiZhuObject.setIsFirstPreviousUserJiaoDiZhu(isFirstPreviousUserJiaoDiZhu);
            deskJiaoDiZhuObject.setIsFirstPreviousUserFirstJiaoDiZhu(isFirstPreviousUserFirstJiaoDiZhu);
            deskJiaoDiZhuObject.setIsSecondPreviousUserJiaoDiZhu(isSecondPreviousUserJiaoDiZhu);
            deskJiaoDiZhuObject.setIsSecondPreviousUserFirstJiaoDiZhu(isSecondPreviousUserFirstJiaoDiZhu);
            deskJiaoDiZhuObject.setIsNextUserFirstJiaoDiZhu(isNextUserFirstJiaoDiZhu);

            //secondPreviousUser
            if (secondPreviousUserId == leftUserObject.getId())
            {
                deskJiaoDiZhuObject.setSecondPreviousUserObject(leftUserObject);
            }
            if (secondPreviousUserId == rightUserObject.getId())
            {
                deskJiaoDiZhuObject.setSecondPreviousUserObject(rightUserObject);
            }
            if (secondPreviousUserId == selfUserObject.getId())
            {
                deskJiaoDiZhuObject.setSecondPreviousUserObject(selfUserObject);
            }

            //firstPreviousUser
            if (firstPreviousUserId == leftUserObject.getId())
            {
                if (isFirstPreviousUserJiaoDiZhu)
                {
                    leftUserObject.setUserType(UserObject.UserType.LANDOWNER);
                    rightUserObject.setUserType(UserObject.UserType.FARMER);
                    selfUserObject.setUserType(UserObject.UserType.FARMER);
                }
                deskJiaoDiZhuObject.setFirstPreviousUserObject(leftUserObject);
            }
            if (firstPreviousUserId == rightUserObject.getId())
            {
                if (isFirstPreviousUserJiaoDiZhu)
                {
                    rightUserObject.setUserType(UserObject.UserType.LANDOWNER);
                    leftUserObject.setUserType(UserObject.UserType.FARMER);
                    selfUserObject.setUserType(UserObject.UserType.FARMER);
                }
                deskJiaoDiZhuObject.setFirstPreviousUserObject(rightUserObject);
            }
            if (firstPreviousUserId == selfUserObject.getId())
            {
                if (isFirstPreviousUserJiaoDiZhu)
                {
                    selfUserObject.setUserType(UserObject.UserType.LANDOWNER);
                    leftUserObject.setUserType(UserObject.UserType.FARMER);
                    rightUserObject.setUserType(UserObject.UserType.FARMER);
                }
                deskJiaoDiZhuObject.setFirstPreviousUserObject(selfUserObject);
            }

            //nextUser
            if (nextUserId.Length == 0)
            {
                UserObject blankNextUserObject = new UserObject();
                blankNextUserObject.reset();
                deskJiaoDiZhuObject.setNextUserObject(blankNextUserObject);
            }
            if (nextUserId == leftUserObject.getId())
            {
                deskJiaoDiZhuObject.setNextUserObject(leftUserObject);
            }
            if (nextUserId == rightUserObject.getId())
            {
                deskJiaoDiZhuObject.setNextUserObject(rightUserObject);
            }
            if (nextUserId == selfUserObject.getId())
            {
                deskJiaoDiZhuObject.setNextUserObject(selfUserObject);
            }
        }
    }
}
