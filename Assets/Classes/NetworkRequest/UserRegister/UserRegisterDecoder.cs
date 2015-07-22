using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserRegisterDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserLoginObject userLoginObject = ModelManager.shareInstance().getUserLoginObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            bool isError = Convert.ToBoolean(data["error"]);
            userLoginObject.setIsError(isError);

            if (!userLoginObject.getIsError())
            {
                userLoginObject.setIsLogin(true);

                string id = Convert.ToString(data["id"]);
                string gender = Convert.ToString(data["gender"]);

                selfUserObject.setId(id);
                if (gender.ToLower() == "male")
                {
                    selfUserObject.setGender(UserObject.Gender.MALE);
                }
                if (gender.ToLower() == "female")
                {
                    selfUserObject.setGender(UserObject.Gender.FEMALE);
                }

                selfUserObject.setOnline(UserObject.OnLineType.ONLINE);
            }
        }
    }
}
