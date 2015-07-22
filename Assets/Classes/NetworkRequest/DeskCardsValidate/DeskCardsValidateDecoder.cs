using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskCardsValidateDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskCardsValidateObject deskCardsValidateObject = ModelManager.shareInstance().getDeskCardsValidateObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            bool isCardsValidate = Convert.ToBoolean(data["cardsValid"]);
            deskCardsValidateObject.setIsCardsValidate(isCardsValidate);
        }
    }
}