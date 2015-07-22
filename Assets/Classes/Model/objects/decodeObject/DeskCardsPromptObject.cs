using UnityEngine;
using System.Collections.Generic;

public class DeskCardsPromptObject
{
    private List<CardArray> _cards;
    private int _index;

    public void resetPlaying()
    {
        _index = 0;
        _cards = new List<CardArray>();
    }

    public void reset()
    {
        _index = 0;
        _cards = new List<CardArray>();
    }

    public List<CardArray> getCards()
    {
        return _cards;
    }

    public void setCards(List<CardArray> cards)
    {
        _cards.Clear();
        for (int i = 0; i < cards.Count; i++)
        {
            CardArray promptCardsPerRound = cards[i].clone();
            _cards.Add(promptCardsPerRound);
        }
    }

    public int getLoopCardsIndex()
    {
        if (_cards.Count > 0)
        {
            if (_index == _cards.Count - 1)
            {
                _index = 0;
            }
            else
            {
                _index++;
            }
        }
        else
        {
            _index = 0;
        }

        return _index;
    }
}