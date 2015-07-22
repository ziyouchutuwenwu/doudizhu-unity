using UnityEngine;
using System.Collections;
using DG.Tweening;

/*
    List<int> cards = new List<int>();
    for (int i = 0; i < 20; i++)
    {
        int card = Random.Range(1, 54);
        cards.Add(card);
    }
    CardSpriteHelper.addSelfCardsToLayer(cards, true, true, this.cardTouchCallBack);

    public void cardTouchCallBack(CardSpriteScript cardSpriteScript)
    {
        Debug.Log("tag is " + cardSpriteScript.getTag());
    }
*/
public class CardSpriteScript : MonoBehaviour
{
    public enum CardStatus
    {
        CARD_UP = 1,
        CARD_DOWN = 2
    }

    private bool _isAnimationProceeding = false;
    private bool _isFront = false;

    private int _tag = 0;
    private CardStatus _cardStatus = CardStatus.CARD_DOWN;

    private SpriteRenderer _leftTopSpriteRender = null;
    private SpriteRenderer _leftTypeSpriteRender = null;
    private SpriteRenderer _landownerMaskRender = null;
    private SpriteRenderer _typeSpriteRender = null;

    private bool _isDiZhu = false;

    public void setCardNumber(int cardNumber, bool isDiZhu)
    {
        if (cardNumber > 54 || cardNumber < 1) return;

        _tag = cardNumber;

        bool isJQKCard = false;
        bool isWangCard = false;

        string leftTopImgName = "";
        string typeImgName = "";
        string leftTypeImgName = "";

        CardInfo cardInfo = Card.getCardInfoFromInteger(cardNumber);

        switch (cardInfo.cardType)
        {
            case CardInfo.CardType.HEI_TAO:
                leftTypeImgName = "heitao_big";
                typeImgName = "heitao_big";
                break;
            case CardInfo.CardType.HONG_TAO:
                leftTypeImgName = "hongtao_big";
                typeImgName = "hongtao_big";
                break;
            case CardInfo.CardType.MEI_HUA:
                leftTypeImgName = "meihua_big";
                typeImgName = "meihua_big";
                break;
            case CardInfo.CardType.FANG_KUAI:
                leftTypeImgName = "fangkuai_big";
                typeImgName = "fangkuai_big";
                break;
        }
        
        string numberName = "";
        string colorName = "";
        if (cardInfo.cardType == CardInfo.CardType.HEI_TAO || cardInfo.cardType == CardInfo.CardType.MEI_HUA) colorName = "black";
        if (cardInfo.cardType == CardInfo.CardType.HONG_TAO || cardInfo.cardType == CardInfo.CardType.FANG_KUAI) colorName = "red";
        
        //jqk，大小王比较特殊
        switch (cardInfo.cardNumber)
        {
            case 11:
                numberName = "j";
                typeImgName = numberName + "_" + colorName + "_" + "type";
                isJQKCard = true;
                break;
            case 12:
                numberName = "q";
                typeImgName = numberName + "_" + colorName + "_" + "type";
                isJQKCard = true;
                break;
            case 13:
                numberName = "k";
                typeImgName = numberName + "_" + colorName + "_" + "type";
                isJQKCard = true;
                break;
            case 16:
                numberName = "wang";
                colorName = "black";
                typeImgName = numberName + "_" + colorName + "_" + "type";
                isWangCard = true;
                break;
            case 17:
                numberName = "wang";
                colorName = "red";
                typeImgName = numberName + "_" + colorName + "_" + "type";
                isWangCard = true;
                break;
            case 14:
                numberName = "a";
                break;
            case 15:
                numberName = "2";
                break;
            default:
                numberName = cardInfo.cardNumber.ToString();
                break;
        }

        leftTopImgName = numberName + "_" + colorName;

        _leftTopSpriteRender.sprite = Resources.Load<Sprite>("imgs/threePersonsPlay/cards/" + leftTopImgName);
        _leftTypeSpriteRender.sprite = Resources.Load<Sprite>("imgs/threePersonsPlay/cards/" + leftTypeImgName);
        _typeSpriteRender.sprite = Resources.Load<Sprite>("imgs/threePersonsPlay/cards/" + typeImgName);


        _isDiZhu = isDiZhu;
        if ( _isDiZhu && _isFront )
        {
            _landownerMaskRender.transform.gameObject.SetActive(true);
        }
        else
        {
            _landownerMaskRender.transform.gameObject.SetActive(false);
        }

        //重新调整位置
        if (isJQKCard)
        {
            _typeSpriteRender.transform.localPosition = new Vector3(0.05f, -0.2f, 0.01f);
        }
        if (isWangCard)
        {
            _leftTopSpriteRender.transform.localPosition = new Vector3(-0.48f, 0.3f, 0.01f);
            _typeSpriteRender.transform.localPosition = new Vector3(0.1f, -0.2f, 0.01f);
        }
    }

    public int getTag()
    {
        return _tag;
    }

    public void setTag(int tag)
    {
        _tag = tag;
    }

    public CardStatus getCardStatus()
    {
        return _cardStatus;
    }

    public Vector3 getSize()
    {
        SpriteRenderer frontSpriteRender = this.transform.FindChild("cardFront").GetComponent<SpriteRenderer>();

        return frontSpriteRender.bounds.size;
    }

    public void setLayerIndex(int index)
    {
        int zCount = 3;//一共三层

        SpriteRenderer backSpriteRender = this.transform.FindChild("cardBack").GetComponent<SpriteRenderer>();
        SpriteRenderer frontSpriteRender = this.transform.FindChild("cardFront").GetComponent<SpriteRenderer>();

        backSpriteRender.sortingOrder = index * zCount;
        frontSpriteRender.sortingOrder = index * zCount;

        _leftTopSpriteRender.sortingOrder = index * zCount + 1;
        _leftTypeSpriteRender.sortingOrder = index * zCount + 1;
        _typeSpriteRender.sortingOrder = index * zCount + 1;
        _landownerMaskRender.sortingOrder = index * zCount + 2;
    }

    void Awake()
    {
        _leftTopSpriteRender = this.transform.FindChild("cardFront").FindChild("leftTopSprite").GetComponent<SpriteRenderer>();
        _leftTypeSpriteRender = this.transform.FindChild("cardFront").FindChild("leftTypeSprite").GetComponent<SpriteRenderer>();
        _typeSpriteRender = this.transform.FindChild("cardFront").FindChild("typeSprite").GetComponent<SpriteRenderer>();
        _landownerMaskRender = this.transform.FindChild("cardFront").FindChild("landownerMask").GetComponent<SpriteRenderer>();

        hideFrontSprites();
    }

    public void setParent(Transform parentTransform)
    {
        this.transform.SetParent(parentTransform);
    }

    private void showFrontSprites()
    {
        _leftTopSpriteRender.transform.gameObject.SetActive(true);
        _leftTypeSpriteRender.transform.gameObject.SetActive(true);
        _typeSpriteRender.transform.gameObject.SetActive(true);

        if (_isDiZhu)
        {
            _landownerMaskRender.transform.gameObject.SetActive(true);
        }
        else
        {
            _landownerMaskRender.transform.gameObject.SetActive(false);
        }
    }

    private void hideFrontSprites()
    {
        _leftTopSpriteRender.transform.gameObject.SetActive(false);
        _leftTypeSpriteRender.transform.gameObject.SetActive(false);
        _typeSpriteRender.transform.gameObject.SetActive(false);

        _landownerMaskRender.transform.gameObject.SetActive(false);
    }

    void flipStart(){
    }

    void flipUpdate()
    {
        float rotateAngles = System.Math.Abs(this.transform.eulerAngles.y);
        
        if (rotateAngles >= 90 && rotateAngles <= 270) _isFront = true;
        else _isFront = false;

        if (_isFront)
        {
            showFrontSprites();
        }
        else
        {
            hideFrontSprites();
        }
    }

    void flipStop()
    {
        _isAnimationProceeding = false;
    }

    public void turnToFront()
    {
        if (!_isAnimationProceeding && !_isFront)
        {
            _isAnimationProceeding = true;

            this.transform.DORotate(new Vector3(0, 180f, 0), 0f).
                SetEase(Ease.OutQuint).
                SetLoops(0).
                OnStart(flipStart).
                OnUpdate(flipUpdate).
                OnComplete(flipStop);
        }
    }

    public void triggerFlip()
    {
        if (!_isAnimationProceeding)
        {
            _isAnimationProceeding = true;

            float degree = 180f;

            if (!_isFront) degree = 180f;
            else degree = 0;

            this.transform.DORotate(new Vector3(0, degree, 0), 2.5f).
                SetEase(Ease.OutQuint).
                SetLoops(0).
                OnStart(flipStart).
                OnUpdate(flipUpdate).
                OnComplete(flipStop);
        }
    }

    public void triggerMoveUpDown()
    {
        float height = 0.3f;

        if (!_isAnimationProceeding)
        {
            _isAnimationProceeding = true;

            float y = transform.localPosition.y;
            switch (_cardStatus)
            {
                case CardStatus.CARD_UP:
                    y -= height;
                    _cardStatus = CardStatus.CARD_DOWN;
                    break;
                case CardStatus.CARD_DOWN:
                    y += height;
                    _cardStatus = CardStatus.CARD_UP;
                    break;
            }

            this.transform.DOLocalMoveY(y, 0.5f).
                SetEase(Ease.OutQuint).
                SetLoops(0).
                OnComplete(moveStop);
        }
    }

    public void triggerMoveUp()
    {
        float height = 0.3f;

        if (!_isAnimationProceeding)
        {
            _isAnimationProceeding = true;

            float y = transform.localPosition.y;
            switch (_cardStatus)
            {
                case CardStatus.CARD_DOWN:
                    y += height;
                    _cardStatus = CardStatus.CARD_UP;
                    break;
            }

            this.transform.DOLocalMoveY(y, 0.5f).
                SetEase(Ease.OutQuint).
                SetLoops(0).
                OnComplete(moveStop);
        }
    }

    public void triggerMoveDown()
    {
        float height = 0.3f;

        if (!_isAnimationProceeding)
        {
            _isAnimationProceeding = true;

            float y = transform.localPosition.y;
            switch (_cardStatus)
            {
                case CardStatus.CARD_UP:
                    y -= height;
                    _cardStatus = CardStatus.CARD_DOWN;
                    break;
            }

            this.transform.DOLocalMoveY(y, 0.5f).
                SetEase(Ease.OutQuint).
                SetLoops(0).
                OnComplete(moveStop);
        }
    }

    void moveStop()
    {
        _isAnimationProceeding = false;
    }

    public void moveTo(Vector3 position)
    {
        this.transform.DOLocalMove(position, 2).
                        SetEase(Ease.OutQuint).
                        SetLoops(0);
    }
}