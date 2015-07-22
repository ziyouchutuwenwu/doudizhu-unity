using UnityEngine;
using System.Collections.Generic;


public class CardHelper
{
    public static List<int> minus(List<int> originalCards,List<int> cardsToRemove)
    {
        List<int> cards = new List<int>();

        for (int i = 0; i < originalCards.Count; i++)
        {
            int originalCard = originalCards[i];

            bool isExist = false;
            for (int j = 0; j < cardsToRemove.Count; j++)
            {
                if (originalCard == cardsToRemove[j])
                {
                    isExist = true;
                    break;
                }
            }

            if (!isExist) cards.Add(originalCard);
        }

        return cards;
    }
}