using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserEnterRoomDecoder
    {
        public static void decode(string jsonInfo)
        {
            RoomObject roomObject = ModelManager.shareInstance().getRoomObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            List<object> roomIds = data["roomIds"] as List<object>;

            for (int i = 0; i < roomIds.Count; i++)
            {
                if (i == 0)
                {
                    roomObject.setId(roomIds[i].ToString());
                    break;
                }
            }
        }
    }
}