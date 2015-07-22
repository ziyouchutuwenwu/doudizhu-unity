using System;
using System.Collections.Generic;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserEditProfileDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserEditProfileObject userEditProfileObject = ModelManager.shareInstance().getUserEditProfileObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            bool isError = Convert.ToBoolean(data["error"]);
            userEditProfileObject.setIsError(isError);

            if (!userEditProfileObject.getIsError())
            {
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
