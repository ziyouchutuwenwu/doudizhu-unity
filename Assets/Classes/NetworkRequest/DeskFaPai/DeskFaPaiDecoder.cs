using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskFaPaiDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskJiaoDiZhuObject deskJiaoDiZhuObject = ModelManager.shareInstance().getDeskJiaoDiZhuObject();
            deskJiaoDiZhuObject.reset();

            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            deskObject.setIsPlaying(true);

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            List<object> cardList = data["cards"] as List<object>;

            List<int> cards = new List<int>();
            for (int i = 0; i < cardList.Count; i++)
            {
                cards.Add(Convert.ToInt32(cardList[i]));
            }

            Dictionary<string, object> leftUserJsonObject = data["leftUser"] as Dictionary<string, object>;
            Dictionary<string, object> rightUserJsonObject = data["rightUser"] as Dictionary<string, object>;
            int leftUserCardNumber = Convert.ToInt32(leftUserJsonObject["cardNumber"]);
            int rightUserCardNumber = Convert.ToInt32(rightUserJsonObject["cardNumber"]);

            leftUserObject.setCardNumber(leftUserCardNumber);
            rightUserObject.setCardNumber(rightUserCardNumber);
            selfUserObject.setCards(Card.sortCardsByCardNumber(cards));
            selfUserObject.setCardNumber(cards.Count);
        }
    }
}