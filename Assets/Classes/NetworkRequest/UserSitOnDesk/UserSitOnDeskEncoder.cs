using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserSitOnDeskEncoder
    {
        public static string encode()
        {
            RoomObject roomObject = ModelManager.shareInstance().getRoomObject();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["roomId"] = roomObject.getId();

            return Json.Serialize(dict);
        }
    }
}