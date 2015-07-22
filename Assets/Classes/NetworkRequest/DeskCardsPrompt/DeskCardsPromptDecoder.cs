using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskCardsPromptDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskCardsPromptObject deskCardsPromptObject = ModelManager.shareInstance().getDeskCardsPromptObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            List<object> promptCardsList = data["cards"] as List<object>;

            List<CardArray> promptCards = new List<CardArray>();
            for (int i = 0; i < promptCardsList.Count; i++)
            {
                List<object> promptCardsPerRound = promptCardsList[i] as List<object>;
                CardArray cards = new CardArray();
                for (int j = 0; j < promptCardsPerRound.Count; j++)
                {
                    cards.addCard(Convert.ToInt32(promptCardsPerRound[j]));
                }
                promptCards.Add(cards);
            }

            deskCardsPromptObject.setCards(promptCards);
        }
    }
}