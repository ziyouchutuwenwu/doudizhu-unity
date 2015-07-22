using UnityEngine;
using System.Collections;

public class CardNumberScript : MonoBehaviour
{
    private SpriteRenderer _leftNumberSprite = null;
    private SpriteRenderer _rightNumberSprite = null;

	// Use this for initialization
	void Awake () {
        _leftNumberSprite = this.transform.FindChild("leftNumber").GetComponent<SpriteRenderer>();
        _rightNumberSprite = this.transform.FindChild("rightNumber").GetComponent<SpriteRenderer>();
	}

    public void setCardNumber(int number)
    {
        if (number <= 0) return;

        int shiWeiValue = number / 10;
        int geWeiValue = number % 10;

        string shiWeiImgName = "golden_number_small_" + shiWeiValue.ToString();
        string geWeiImgName = "golden_number_small_" + geWeiValue.ToString();

        _leftNumberSprite.sprite = Resources.Load<Sprite>("imgs/threePersonsPlay/cardExtra/" + shiWeiImgName);
        _rightNumberSprite.sprite = Resources.Load<Sprite>("imgs/threePersonsPlay/cardExtra/" + geWeiImgName);
    }
}
