using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class CardSpriteHelper: MonoBehaviour
{
    public static void addDiPaiCards()
    {
        if (null != GameObject.Find(SpriteNameConst.DI_PAI_CARDS_NAME)) return;

        List<int> diPaiCards = new List<int>();
        diPaiCards.Add(1);
        diPaiCards.Add(2);
        diPaiCards.Add(3);

        Transform bgPrefab = Resources.Load<Transform>("prefab/cardSprite/cardBg");
        Transform bgTransform = Instantiate(bgPrefab, new Vector3(0f, 5.45f, 1f), Quaternion.identity) as Transform;
        bgTransform.gameObject.name = SpriteNameConst.DI_PAI_CARDS_NAME;

        Transform cardPrefab = Resources.Load<Transform>("prefab/cardSprite/cardSprite");
        List<int> sortedCards = Card.sortCardsByCardNumber(diPaiCards);

        for (int i = 0; i < sortedCards.Count; i++)
        {
            Transform transform = Instantiate(cardPrefab, new Vector3(0, 1, 0.01f), Quaternion.identity) as Transform;
            transform.SetParent(bgTransform);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.gameObject.GetComponent<CardSpriteScript>();
            cardSpriteScript.setLayerIndex(i + 1);
            cardSpriteScript.setCardNumber(sortedCards[i], false);

            Vector3 size = cardSpriteScript.getSize();

            float cardWidth = size.x;
            float cardSpace = cardWidth*0.6f;
            float cardTotalWidth = cardWidth + (sortedCards.Count - 1) * cardSpace;

            float x = -cardTotalWidth / 2 + cardSpace * (i + 1);

            transform.localPosition = new Vector3(x, 0f, 0.01f);
            transform.localScale = new Vector3(0.4f, 0.4f, 1);
        }

        bgTransform.DOMoveX(-0.2f, 0f).SetEase(Ease.Unset).SetLoops(0);
    }

    public static void removeDiPaiCards()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.DI_PAI_CARDS_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void setDiPaiCards(List<int> diPaiCards)
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.DI_PAI_CARDS_NAME);
        if (null != gameObject)
        {
            Transform bgTransform = gameObject.transform;

            List<CardSpriteScript> cardSpriteScripts = new List<CardSpriteScript>();
            for (int i = 0; i < bgTransform.childCount; i++)
            {
                Transform cardTransform = bgTransform.GetChild(i);
                CardSpriteScript cardSpriteScript = (CardSpriteScript)cardTransform.gameObject.GetComponent<CardSpriteScript>();
                if (null != cardSpriteScript)
                {
                    cardSpriteScripts.Add(cardSpriteScript);
                }
            }

            if (cardSpriteScripts.Count != diPaiCards.Count) return;

            for (int i = 0; i < cardSpriteScripts.Count; i++)
            {
                CardSpriteScript cardSpriteScript = cardSpriteScripts[i];
                if (null != cardSpriteScript)
                {
                    cardSpriteScript.setCardNumber(diPaiCards[i], false);
                    cardSpriteScript.triggerFlip();
                }
            }
        }
    }

    public static void addLeftUserSendCards(List<int> cards, bool isDiZhu)
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_CARDS_NAME)) return;

        Transform bgPrefab = Resources.Load<Transform>("prefab/cardSprite/cardBg");
        Transform bgTransform = Instantiate(bgPrefab, new Vector3(-5f, 2f, 1f), Quaternion.identity) as Transform;
        bgTransform.gameObject.name = SpriteNameConst.LEFT_USER_CARDS_NAME;

        Transform prefab = Resources.Load<Transform>("prefab/cardSprite/cardSprite");
        List<int> sortedCards = Card.sortCardsByCardNumber(cards);

        for (int i = 0; i < sortedCards.Count; i++)
        {
            Transform transform = Instantiate(prefab, new Vector3(0, 1, 0.01f), Quaternion.identity) as Transform;
            transform.SetParent(bgTransform);
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.gameObject.GetComponent<CardSpriteScript>();
            cardSpriteScript.setLayerIndex(i + 1);
            cardSpriteScript.setCardNumber(sortedCards[i], isDiZhu);

            Vector3 size = cardSpriteScript.getSize();

            float cardWidth = size.x;
            float cardSpace = (float)(cardWidth * 0.3);
            float cardTotalWidth = cardWidth + (sortedCards.Count - 1) * cardSpace;

            float x = -cardTotalWidth / 2 + cardSpace * (i + 1);
            transform.localPosition = new Vector3(x, 0.5f, 0.01f);
            cardSpriteScript.turnToFront();
        }

        bgTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public static void removeLeftUserSendCards()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_CARDS_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserSendCards(List<int> cards, bool isDiZhu)
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_CADRS_NAME)) return;

        Transform bgPrefab = Resources.Load<Transform>("prefab/cardSprite/cardBg");
        Transform bgTransform = Instantiate(bgPrefab, new Vector3(5f, 2f, 1f), Quaternion.identity) as Transform;
        bgTransform.gameObject.name = SpriteNameConst.RIGHT_USER_CADRS_NAME;

        Transform prefab = Resources.Load<Transform>("prefab/cardSprite/cardSprite");
        List<int> sortedCards = Card.sortCardsByCardNumber(cards);

        for (int i = 0; i < sortedCards.Count; i++)
        {
            Transform transform = Instantiate(prefab, new Vector3(0, 1, 0.01f), Quaternion.identity) as Transform;
            transform.SetParent(bgTransform);
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.gameObject.GetComponent<CardSpriteScript>();
            cardSpriteScript.setLayerIndex(i + 1);
            cardSpriteScript.setCardNumber(sortedCards[i], isDiZhu);

            Vector3 size = cardSpriteScript.getSize();

            float cardWidth = size.x;
            float cardSpace = (float)(cardWidth * 0.3);
            float cardTotalWidth = cardWidth + (sortedCards.Count - 1) * cardSpace;

            float x = -cardTotalWidth / 2 + cardSpace * (i + 1);
            transform.localPosition = new Vector3(x, 0.5f, 0.01f);
            cardSpriteScript.turnToFront();
        }

        bgTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public static void removeRightUserSendCards()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_CADRS_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserCards(List<int> cards, bool isDiZhu, CardButtonScript.TouchCallBack cardTouchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME)) return;

        Transform bgPrefab = Resources.Load<Transform>("prefab/cardSprite/cardBg");
        Transform bgTransform = Instantiate(bgPrefab, new Vector3(0f, -2.5f, 1f), Quaternion.identity) as Transform;
        bgTransform.gameObject.name = SpriteNameConst.SELF_USER_CARDS_NAME;

        Transform cardPrefab = Resources.Load<Transform>("prefab/cardSprite/cardSprite");
        Transform buttonCanvasPrefab = Resources.Load<Transform>("prefab/cardSprite/cardButtonCanvas");
        List<int> sortedCards = Card.sortCardsByCardNumber(cards);

        for (int i = 0; i < sortedCards.Count; i++)
        {
            Transform cardTransform = Instantiate(cardPrefab, new Vector3(0, 1, 0.01f), Quaternion.identity) as Transform;
            CardSpriteScript cardSpriteScript = (CardSpriteScript)cardTransform.gameObject.GetComponent<CardSpriteScript>();
            cardSpriteScript.setParent(bgTransform);
            cardSpriteScript.setLayerIndex(i + 1);
            cardSpriteScript.setCardNumber(sortedCards[i], isDiZhu);

            Vector3 size = cardSpriteScript.getSize();

            float cardWidth = size.x;
            float cardSpace = (float)(cardWidth * 0.5);
            float cardTotalWidth = cardWidth + (sortedCards.Count - 1) * cardSpace;

            float x = -cardTotalWidth / 2 + cardSpace * (i + 1);

            cardSpriteScript.moveTo(new Vector3(x, 0f, 0.01f));
            cardSpriteScript.turnToFront();

            Transform buttonCanvasTransform = Instantiate(buttonCanvasPrefab, new Vector3(0, 1, 0.01f), Quaternion.identity) as Transform;
            CardButtonScript cardButtonScript = (CardButtonScript)buttonCanvasTransform.FindChild("Button").gameObject.GetComponent<CardButtonScript>();
            cardButtonScript.setParent(bgTransform);
            cardButtonScript.setTag(sortedCards[i]);
            cardButtonScript.setTouchEnabled(true);
            cardButtonScript.setTouchCallBack(cardTouchCallBack);
            cardButtonScript.moveTo(new Vector3(x, 0f, 0.01f));
        }

        bgTransform.localScale = new Vector3(0.8f, 0.8f, 1.0f);
    }

    public static void removeSelfUserCards()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void moveSelfUserCardsToSend(List<int> cardsToMove)
    {
        if (null == GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME)) return;

        List<CardSpriteScript> cardSpritesToMove = new List<CardSpriteScript>();
        List<CardButtonScript> cardButtonsToRemove = new List<CardButtonScript>();

        Transform oldBgTransform = GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME).transform;
        CardBgScript cardBgScript = oldBgTransform.GetComponent<CardBgScript>();

        List<int> sortedCardsToMove = Card.sortCardsByCardNumber(cardsToMove);
        for (int i = 0; i < sortedCardsToMove.Count; i++)
        {
            int card = sortedCardsToMove[i];
            CardSpriteScript cardSpriteScript = cardBgScript.getCardSpriteScriptByTag(card);
            CardButtonScript cardButtonScript = cardBgScript.getCardButtonScriptByTag(card);
            cardSpritesToMove.Add(cardSpriteScript);
            cardButtonsToRemove.Add(cardButtonScript);
        }

        Transform bgPrefab = Resources.Load<Transform>("prefab/cardSprite/cardBg");
        Transform bgTransform = Instantiate(bgPrefab, new Vector3(0f, -3f, 1f), Quaternion.identity) as Transform;
        bgTransform.gameObject.name = SpriteNameConst.SELF_USER_SEND_CARDS_NAME;
        for (int i = 0; i < cardSpritesToMove.Count; i++)
        {
            CardSpriteScript cardSpriteScript = cardSpritesToMove[i];
            cardSpriteScript.setParent(bgTransform);
            Vector3 size = cardSpriteScript.getSize();
            float cardWidth = size.x;
            float cardSpace = (float)(cardWidth * 0.3);
            float cardTotalWidth = cardWidth + (cardSpritesToMove.Count - 1) * cardSpace;

            float x = -cardTotalWidth / 2 + cardSpace * (i+1);
            cardSpriteScript.moveTo(new Vector3(x, 0.5f, 0.01f));
        }

        bgTransform.DOMoveY(-0.5f, 0.2f).SetEase(Ease.Unset).SetLoops(0);
        bgTransform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.2f).SetEase(Ease.Unset).SetLoops(0);

        foreach (CardButtonScript cardButtonScript in cardButtonsToRemove)
        {
            cardButtonScript.remove();
        }
    }

    public static List<int> getSelfUserUpCards()
    {
        List<int> cardsList = new List<int>();
        if (null == GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME)) return cardsList;
     
        Transform selfCardsBgTransform = GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME).transform;
       
        for (int i = 0; i < selfCardsBgTransform.childCount; i++)
        {
            Transform transform = selfCardsBgTransform.GetChild(i);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.GetComponent<CardSpriteScript>();
            if (null != cardSpriteScript)
            {
                if (cardSpriteScript.getCardStatus() == CardSpriteScript.CardStatus.CARD_UP)
                {
                    cardsList.Add(cardSpriteScript.getTag());
                }
            }
        }

        return cardsList;
    }

    public static void makeSelfUserUpCardsDown(List<int> cards)
    {
        if (null == GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME)) return;

        Transform selfCardsBgTransform = GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME).transform;

        List<Transform> cardSpriteList = new List<Transform>();
        for (int i = 0; i < selfCardsBgTransform.childCount; i++)
        {
            Transform transform = selfCardsBgTransform.GetChild(i);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.GetComponent<CardSpriteScript>();
            if (null != cardSpriteScript) cardSpriteList.Add(transform);
        }
        if (cards.Count > cardSpriteList.Count) return;

        for (int i = 0; i < cards.Count; i++)
        {
            int card = cards[i];
            for (int j = 0; j < cardSpriteList.Count; j++)
            {
                Transform transform = cardSpriteList[j];
                CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.GetComponent<CardSpriteScript>();
                if (cardSpriteScript.getTag() == card) cardSpriteScript.triggerMoveDown();
            }
        }
    }

    public static void makeSelfUserDownCardsUp(List<int> cards)
    {
        if (null == GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME)) return;

        Transform selfCardsBgTransform = GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME).transform;

        List<Transform> cardSpriteList = new List<Transform>();
        for (int i = 0; i < selfCardsBgTransform.childCount; i++)
        {
            Transform transform = selfCardsBgTransform.GetChild(i);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.GetComponent<CardSpriteScript>();
            if (null != cardSpriteScript)
            {
                cardSpriteList.Add(transform);
            }
        }
        if (cards.Count > cardSpriteList.Count) return;

        for (int i = 0; i < cards.Count; i++)
        {
            int card = cards[i];
            for (int j = 0; j < cardSpriteList.Count; j++)
            {
                Transform transform = cardSpriteList[j];
                CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.GetComponent<CardSpriteScript>();
                if (cardSpriteScript.getTag() == card) cardSpriteScript.triggerMoveUp();
            }
        }
    }

    public static void addSelfUserSendCards(List<int> cards, bool isDiZhu)
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_SEND_CARDS_NAME)) return;

        Transform bgPrefab = Resources.Load<Transform>("prefab/cardSprite/cardBg");
        Transform bgTransform = Instantiate(bgPrefab, new Vector3(0f, -3f, 1f), Quaternion.identity) as Transform;
        bgTransform.gameObject.name = SpriteNameConst.SELF_USER_SEND_CARDS_NAME;

        Transform prefab = Resources.Load<Transform>("prefab/cardSprite/cardSprite");
        List<int> sortedCards = Card.sortCardsByCardNumber(cards);

        for (int i = 0; i < sortedCards.Count; i++)
        {
            Transform transform = Instantiate(prefab, new Vector3(0, 1, 0.01f), Quaternion.identity) as Transform;
            transform.SetParent(bgTransform);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.gameObject.GetComponent<CardSpriteScript>();
            cardSpriteScript.setLayerIndex(i + 1);
            cardSpriteScript.setCardNumber(sortedCards[i], isDiZhu);

            Vector3 size = cardSpriteScript.getSize();

            float cardWidth = size.x;
            float cardSpace = (float)(cardWidth * 0.3);
            float cardTotalWidth = cardWidth + (sortedCards.Count - 1) * cardSpace;

            float x = -cardTotalWidth / 2 + cardSpace * (i + 1);
            transform.localPosition = new Vector3(x, 0.5f, 0.01f);
            cardSpriteScript.turnToFront();
        }

        bgTransform.DOMoveY(-0.5f, 0f).SetEase(Ease.Unset).SetLoops(0);
        float scale = 0.8f * 0.8f;
        bgTransform.DOScale(new Vector3(scale, scale, 1), 0f).SetEase(Ease.Unset).SetLoops(0);
    }

    public static void removeSelfUserSendCards()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_SEND_CARDS_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    //剩下的transform重新排序
    public static void reArrangeSelfUserCards()
    {
        if (null == GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME)) return;

        List<Transform> cardTransformList = new List<Transform>();
        Transform selfCardsBgTransform = GameObject.Find(SpriteNameConst.SELF_USER_CARDS_NAME).transform;
        for (int i = 0; i < selfCardsBgTransform.childCount; i++)
        {
            Transform transform = selfCardsBgTransform.GetChild(i);
            CardSpriteScript cardSpriteScript = (CardSpriteScript)transform.GetComponent<CardSpriteScript>();
            if (null != cardSpriteScript)
            {
                cardTransformList.Add(transform);
            }
        }

        List<Transform> cardButtonList = new List<Transform>();
        for (int i = 0; i < selfCardsBgTransform.FindChild("Canvas").childCount; i++)
        {
            Transform transform = selfCardsBgTransform.FindChild("Canvas").GetChild(i);
            CardButtonScript cardButtonScript = (CardButtonScript)transform.GetComponent<CardButtonScript>();
            if (null != cardButtonScript)
            {
                cardButtonList.Add(transform);
            }
        }

        for (int i = 0; i < cardTransformList.Count; i++)
        {
            Transform cardTransform = cardTransformList[i];
            Transform buttonTransform = cardButtonList[i];
            CardSpriteScript cardSpriteScript = (CardSpriteScript)cardTransform.GetComponent<CardSpriteScript>();

            Vector3 size = cardSpriteScript.getSize();
            float cardWidth = size.x;
            float cardSpace = (float)(cardWidth * 0.5);
            float cardTotalWidth = cardWidth + (cardTransformList.Count - 1) * cardSpace;

            float x = -cardTotalWidth / 2 + cardSpace * (i + 1);

            cardTransform.DOLocalMoveX(x, 1.5f).
                        SetEase(Ease.OutQuint).
                        SetLoops(0);

            buttonTransform.DOLocalMoveX(x, 1.5f).
            SetEase(Ease.OutQuint).
            SetLoops(0);
        }
    }
}