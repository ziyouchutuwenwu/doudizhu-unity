using UnityEngine;
using System.Collections.Generic;

public class CardArray
{
    List<int> _cards = new List<int>();

    public void addCard(int card)
    {
        _cards.Add(card);
    }

    public List<int> toIntList()
    {
        return CloneHelper.clone(_cards);
    }

    public CardArray clone()
    {
        List<int> intCards = toIntList();

        CardArray cloneObject = new CardArray();
        for (int i = 0; i < intCards.Count; i++)
        {
            cloneObject.addCard(intCards[i]);
        }
        return cloneObject;
    }
}