using UnityEngine;
using System.Collections.Generic;

public class DeskObject {

    private string _id;
    private string _diZhuId;
    private List<int> _diPaiCards;
    private bool _isPlaying = false;

    public void resetPlaying()
    {
        _diZhuId = "";
        _diPaiCards = new List<int>();
        _isPlaying = false;
    }

    public void reset()
    {
        _id = "";
        _diZhuId = "";
        _diPaiCards = new List<int>();
        _isPlaying = false;
    }

    public string getId()
    {
        return _id;
    }

    public void setId(string id)
    {
        _id = id;
    }

    public string getDiZhuId()
    {
        return _diZhuId;
    }

    public void setDiZhuId(string diZhuId)
    {
        _diZhuId = diZhuId;
    }

    public List<int> getDiPaiCards()
    {
        return CloneHelper.clone(_diPaiCards);
    }

    public void setDiPaiCards(List<int> diPaiCards)
    {
        _diPaiCards.Clear();
        _diPaiCards = CloneHelper.clone(diPaiCards);
    }

    public bool getIsPlaying()
    {
        return _isPlaying;
    }

    public void setIsPlaying(bool isPlaying)
    {
        _isPlaying = isPlaying;
    }
}