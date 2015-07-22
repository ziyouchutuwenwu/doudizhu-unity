using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskFaDiPaiDecoder
    {
        public static void decode(string jsonInfo)
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            List<object> diPaiCardsList = data["diPaiCards"] as List<object>;
            List<int> diPaiCards = new List<int>();
            for (int i = 0; i < diPaiCardsList.Count; i++)
            {
                diPaiCards.Add(Convert.ToInt32(diPaiCardsList[i]));
            }
            deskObject.setDiPaiCards(diPaiCards);

            //设置每个人的牌和牌的张数
            if (deskObject.getDiZhuId() == selfUserObject.getId())
            {
                List<int> cardsInHand = selfUserObject.getCards();
                cardsInHand.AddRange(diPaiCards);

                selfUserObject.setCards(Card.sortCardsByCardNumber(cardsInHand));
                selfUserObject.setCardNumber(cardsInHand.Count);
            }

            if (deskObject.getDiZhuId() == leftUserObject.getId())
            {
                int cardsNumber = leftUserObject.getCardNumber();
                cardsNumber += diPaiCards.Count;
                leftUserObject.setCardNumber(cardsNumber);
            }
            if (deskObject.getDiZhuId() == rightUserObject.getId())
            {
                int cardsNumber = rightUserObject.getCardNumber();
                cardsNumber += diPaiCards.Count;
                rightUserObject.setCardNumber(cardsNumber);
            }
        }
    }
}
