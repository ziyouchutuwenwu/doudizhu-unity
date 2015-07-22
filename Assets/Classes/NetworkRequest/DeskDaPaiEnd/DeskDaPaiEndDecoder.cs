using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskDaPaiEndDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            //leftUser
            Dictionary<string, object> leftUserJsonObject = data["leftUser"] as Dictionary<string, object>;
            string leftUserId = Convert.ToString(leftUserJsonObject["id"]);

            List<int> leftUserCards = new List<int>();
            List<object> leftUserJsonCards = leftUserJsonObject["cards"] as List<object>;
            for (int i = 0; i < leftUserJsonCards.Count; i++)
            {
                leftUserCards.Add(Convert.ToInt32(leftUserJsonCards[i]));
            }
            if (leftUserId == leftUserObject.getId())
            {
                leftUserObject.setCards(leftUserCards);
            }

            //rightUser
            Dictionary<string, object> rightUserJsonObject = data["rightUser"] as Dictionary<string, object>;
            string rightUserId = Convert.ToString(rightUserJsonObject["id"]);

            List<int> rightUserCards = new List<int>();
            List<object> rightUserJsonCards = rightUserJsonObject["cards"] as List<object>;
            for (int i = 0; i < rightUserJsonCards.Count; i++)
            {
                rightUserCards.Add(Convert.ToInt32(rightUserJsonCards[i]));
            }
            if (rightUserId == rightUserObject.getId())
            {
                rightUserObject.setCards(rightUserCards);
            }

            //selfUser
            bool isWin = Convert.ToBoolean(data["isWin"]);
            selfUserObject.setIsWin(isWin);
        }
    }
}