using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card
{
    public static CardInfo getCardInfoFromInteger(int index)
    {
        int typeNumber = index / 13;
        int cardNumber = index % 13;

        if (0 == cardNumber)
        {
            cardNumber = 13;
            typeNumber = (index - 1) / 13;
        }

        CardInfo cardInfo = new CardInfo();
        cardInfo.cardType = (CardInfo.CardType)typeNumber;
        cardInfo.cardNumber = cardNumber + 2;

        if ( (CardInfo.CardType)typeNumber == CardInfo.CardType.WANG )
        {
            cardInfo.cardNumber += 13;
        }

        return cardInfo;
    }

    //根据花色，从大到小排序
    public static List<int> sortCardsByCardNumber(List<int> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            for (int j = 0; j < (cards.Count - i - 1); j++)
            {
                int cardIndex = cards[j];
                int nextCardIndex = cards[j + 1];

                CardInfo cardInfo = Card.getCardInfoFromInteger(cardIndex);
                CardInfo nextCardInfo = Card.getCardInfoFromInteger(nextCardIndex);

                if (cardInfo.cardNumber < nextCardInfo.cardNumber)
                {
                    cards[j] = nextCardIndex;
                    cards[j + 1] = cardIndex;
                }
            }
        }

        return cards;
    }
}