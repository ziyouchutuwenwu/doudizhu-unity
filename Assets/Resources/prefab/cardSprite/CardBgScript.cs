using UnityEngine;
using System.Collections.Generic;

public class CardBgScript : MonoBehaviour 
{
    public CardSpriteScript getCardSpriteScriptByTag(int tag)
    {
        CardSpriteScript script = null;

        for(int i=0;i < this.transform.childCount; i++)
        {
            Transform transform = this.transform.GetChild(i);
            CardSpriteScript cardSpriteScript = transform.GetComponent<CardSpriteScript>();
            if (cardSpriteScript != null && cardSpriteScript.getTag() == tag)
            {
                script = cardSpriteScript;
                break;
            }
        }
        return script;
    }

    public CardButtonScript getCardButtonScriptByTag(int tag)
    {
        CardButtonScript script = null;

        for (int i = 0; i < this.transform.FindChild("Canvas").childCount; i++)
        {
            Transform transform = this.transform.FindChild("Canvas").GetChild(i);
            CardButtonScript cardButtonScript = transform.GetComponent<CardButtonScript>();
            if (cardButtonScript != null && cardButtonScript.getTag() == tag)
            {
                script = cardButtonScript;
                break;
            }
        }
        return script;
    }

    void Awake()
    {
        this.transform.FindChild("Canvas").GetComponent<Canvas>().worldCamera = Camera.main;
    }
}