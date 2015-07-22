using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskChuPaiDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskChuPaiObject deskChuPaiObject = ModelManager.shareInstance().getDeskChuPaiObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            DeskCardsPromptObject deskCardsPromptObject = ModelManager.shareInstance().getDeskCardsPromptObject();
            deskCardsPromptObject.reset();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            //secondPreviousUser
            Dictionary<string, object> secondPreviousUserJsonObject = data["secondPreviousUser"] as Dictionary<string, object>;
            string secondPreviousUserId = Convert.ToString(secondPreviousUserJsonObject["id"]);
            bool isSecondPreviousUserBuYao = Convert.ToBoolean(secondPreviousUserJsonObject["isBuYao"]);

            List<object> secondPreviousUserSendJsonCards = secondPreviousUserJsonObject["cards"] as List<object>;
            List<int> secondPreviousUserSendCards = new List<int>();
            for (int i = 0; i < secondPreviousUserSendJsonCards.Count; i++)
            {
                secondPreviousUserSendCards.Add(Convert.ToInt32(secondPreviousUserSendJsonCards[i]));
            }

            //firstPreviousUser
            Dictionary<string, object> firstPreviousUserJsonObject = data["firstPreviousUser"] as Dictionary<string, object>;
            string firstPreviousUserId = Convert.ToString(firstPreviousUserJsonObject["id"]);
            int firstPreviousUserSendCardsType = Convert.ToInt32(firstPreviousUserJsonObject["cardsType"]);
            bool isFirstPreviousUserBuYao = Convert.ToBoolean(firstPreviousUserJsonObject["isBuYao"]);
            bool isFirstPreviousUserDaNi = Convert.ToBoolean(firstPreviousUserJsonObject["isDaNi"]);

            List<object> firstPreviousUserSendJsonCards = firstPreviousUserJsonObject["cards"] as List<object>;
            List<int> firstPreviousUserSendCards = new List<int>();
            for (int i = 0; i < firstPreviousUserSendJsonCards.Count; i++)
            {
                firstPreviousUserSendCards.Add(Convert.ToInt32(firstPreviousUserSendJsonCards[i]));
            }

            //nextUser
            Dictionary<string, object> nextUserJsonObject = data["nextUser"] as Dictionary<string, object>;
            string nextUserId = Convert.ToString(nextUserJsonObject["id"]);
            bool isNextUserMustChuPai = Convert.ToBoolean(nextUserJsonObject["mustChuPai"]);

            //赋值到deskChuPaiObject
            deskChuPaiObject.setIsFirstPreviousUserBuYao(isFirstPreviousUserBuYao);
            deskChuPaiObject.setIsFirstPreviousUserDaNi(isFirstPreviousUserDaNi);
            deskChuPaiObject.setFirstPreviousUserSendCards(firstPreviousUserSendCards);
            deskChuPaiObject.setFirstPreviousUserSendCardsType((CardInfo.CardPromptType)firstPreviousUserSendCardsType);
            deskChuPaiObject.setIsSecondPreviousUserBuYao(isSecondPreviousUserBuYao);
            deskChuPaiObject.setSecondPreviousUserSendCards(secondPreviousUserSendCards);
            deskChuPaiObject.setIsNextUserMustChuPai(isNextUserMustChuPai);

            //secondPreviousUser
            if (secondPreviousUserId == leftUserObject.getId())
            {
                deskChuPaiObject.setSecondPreviousUserObject(leftUserObject);
            }
            if (secondPreviousUserId == rightUserObject.getId())
            {
                deskChuPaiObject.setSecondPreviousUserObject(rightUserObject);
            }
            if (secondPreviousUserId == selfUserObject.getId())
            {
                deskChuPaiObject.setSecondPreviousUserObject(selfUserObject);
            }

            //firstPreviousUser
            if (firstPreviousUserId == leftUserObject.getId())
            {
                int cardsNumber = leftUserObject.getCardNumber();
                leftUserObject.setCardNumber(cardsNumber - firstPreviousUserSendCards.Count);
                deskChuPaiObject.setFirstPreviousUserObject(leftUserObject);
            }
            if (firstPreviousUserId == rightUserObject.getId())
            {
                int cardsNumber = rightUserObject.getCardNumber();
                rightUserObject.setCardNumber(cardsNumber - firstPreviousUserSendCards.Count);
                deskChuPaiObject.setFirstPreviousUserObject(rightUserObject);
            }
            if (firstPreviousUserId == selfUserObject.getId())
            {
                int cardsNumber = selfUserObject.getCardNumber();
                selfUserObject.setCardNumber(cardsNumber - firstPreviousUserSendCards.Count);

                List<int> cardsInHand = selfUserObject.getCards();
                List<int> newCardsInHand = CardHelper.minus(cardsInHand, firstPreviousUserSendCards);
                selfUserObject.setCards(newCardsInHand);
                deskChuPaiObject.setFirstPreviousUserObject(selfUserObject);
            }

            //nextUser
            if (nextUserId == leftUserObject.getId())
            {
                deskChuPaiObject.setNextUserObject(leftUserObject);
            }
            if (nextUserId == rightUserObject.getId())
            {
                deskChuPaiObject.setNextUserObject(rightUserObject);
            }
            if (nextUserId == selfUserObject.getId())
            {
                deskChuPaiObject.setNextUserObject(selfUserObject);
            }
        }
    }
}