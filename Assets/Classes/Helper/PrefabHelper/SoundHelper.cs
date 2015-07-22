using UnityEngine;
using System.Collections.Generic;

public class SoundHelper : MonoBehaviour {

    public static void addSoundPlayer()
    {
        if (null != GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/sound/soundPlayer");
        Transform transform = Instantiate(prefab, new Vector3(-1, 1, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SOUND_PLAYER_NAME;
    }

    public static void setVolume(float volume)
    {
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (null != soundPlayerScript)
        {
            soundPlayerScript.setVolume(volume);
        }
    }

    public static void playSoundWithAnimation(List<int> cards, CardInfo.CardPromptType sendCardsType, bool isMale)
    {
        //飞机
        if (sendCardsType == CardInfo.CardPromptType.CARD_PROMPT_FEI_JI)
        {
            SoundHelper.playFeiJiSound(isMale);
            AnimationHelper.addFeiJiAnimation();
        }
        //顺子
        if (sendCardsType == CardInfo.CardPromptType.CARD_PROMPT_SHUN_ZI)
        {
            SoundHelper.playShunZiSound(isMale);
            AnimationHelper.addShunZiAnimation();
        }
        //单张
        if (sendCardsType == CardInfo.CardPromptType.CARD_PROMPT_DAN_ZHANG)
        {
            int card = cards[0];
            CardInfo cardInfo = Card.getCardInfoFromInteger(card);
            SoundHelper.playDanZhangSound(isMale, cardInfo.cardNumber);
        }
        //对子
        if (sendCardsType == CardInfo.CardPromptType.CARD_PROMPT_DUI_ZI)
        {
            int card = cards[0];
            CardInfo cardInfo = Card.getCardInfoFromInteger(card);
            SoundHelper.playDuiZiSound(isMale, cardInfo.cardNumber);
        }
        //三张
        if (sendCardsType == CardInfo.CardPromptType.CARD_PROMPT_SAN_ZHANG)
        {
            SoundHelper.playSanZhangSound(isMale);
        }
        //三带一
        if (sendCardsType == CardInfo.CardPromptType.CARD_PROMPT_SAN_DAI_YI)
        {
            SoundHelper.playSanDaiYiSound(isMale);
        }
        //三带二
        if (sendCardsType == CardInfo.CardPromptType.CARD_PROMPT_SAN_DAI_ER)
        {
            SoundHelper.playSanDaiErSound(isMale);
        }
    }

    public static void playJiaoDiZhuSound(bool isMale, bool isJiaoDiZhu)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            if (isJiaoDiZhu)
            {
                soundFullPath = "audios/male/jiaodizhu";
            }
            else
            {
                soundFullPath = "audios/male/bujiao";
            }
        }
        else
        {
            if (isJiaoDiZhu)
            {
                soundFullPath = "audios/female/jiaodizhu";
            }
            else
            {
                soundFullPath = "audios/female/bujiao";
            }
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playQiangDiZhuSound(bool isMale, bool isQiangDiZhu)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            if (isQiangDiZhu)
            {
                soundFullPath = "audios/male/qiangdizhu";
            }
            else
            {
                soundFullPath = "audios/male/buqiang";
            }
        }
        else
        {
            if (isQiangDiZhu)
            {
                soundFullPath = "audios/female/qiangdizhu";
            }
            else
            {
                soundFullPath = "audios/female/buqiang";
            }
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playDanZhangSound(bool isMale, int cardNumber)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/" + cardNumber.ToString();
        }
        else
        {
            soundFullPath = "audios/female/" + cardNumber.ToString();
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playDuiZiSound(bool isMale, int cardNumber)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/dui-" + cardNumber.ToString();
        }
        else
        {
            soundFullPath = "audios/female/dui-" + cardNumber.ToString();
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playSanZhangSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/sange";
        }
        else
        {
            soundFullPath = "audios/female/sange";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playSanDaiYiSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/sandaiyi";
        }
        else
        {
            soundFullPath = "audios/female/sandaiyi";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playSanDaiErSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/sandaiyidui";
        }
        else
        {
            soundFullPath = "audios/female/sandaiyidui";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playShunZiSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/shunzi";
        }
        else
        {
            soundFullPath = "audios/female/shunzi";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playFeiJiSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/feiji";
        }
        else
        {
            soundFullPath = "audios/female/feiji";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playZhaDanSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/zhadan";
        }
        else
        {
            soundFullPath = "audios/female/zhadan";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playWangZhaSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            soundFullPath = "audios/male/wangzha";
        }
        else
        {
            soundFullPath = "audios/female/wangzha";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playCardsLeftSound(bool isMale,int leftCardNumber)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        if (isMale)
        {
            if (1 == leftCardNumber)
            {
                soundFullPath = "audios/male/yizhang-left";
            }
            if (2 == leftCardNumber)
            {
                soundFullPath = "audios/male/liangzhang-left";
            }
        }
        else
        {
            if (1 == leftCardNumber)
            {
                soundFullPath = "audios/female/yizhang-left";
            }
            if (2 == leftCardNumber)
            {
                soundFullPath = "audios/female/liangzhang-left";
            }
        }
        soundPlayerScript.delayPlay(soundFullPath);
    }

    public static void playBuYaoSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        int randomNumber = Random.Range(1, 54) %4 + 1;

        if (isMale)
        {
            soundFullPath = "audios/male/buyao-" + randomNumber.ToString();
        }
        else
        {
            soundFullPath = "audios/female/buyao-" + randomNumber.ToString();
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playDaNiSound(bool isMale)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        int randomNumber = Random.Range(1, 54) % 3 + 1;

        if (isMale)
        {
            soundFullPath = "audios/male/dani-" + randomNumber.ToString();
        }
        else
        {
            soundFullPath = "audios/female/dani-" + randomNumber.ToString();
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playWinLoseSound(bool isWin)
    {
        string soundFullPath = "";
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();

        if (isWin)
        {
            soundFullPath = "audios/win";
        }
        else
        {
            soundFullPath = "audios/lose";
        }
        soundPlayerScript.play(soundFullPath);
    }

    public static void playWashCardSound()
    {
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        soundPlayerScript.play("audios/wash-card");
    }

    public static void playCardTappedSound()
    {
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        soundPlayerScript.play("audios/card-tap");
    }

    public static void playCardSendSound()
    {
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        soundPlayerScript.play("audios/card-send");
    }

    public static void playClockAlarmSound()
    {
        SoundPlayerScript soundPlayerScript = GameObject.Find(SpriteNameConst.SOUND_PLAYER_NAME).GetComponent<SoundPlayerScript>();
        soundPlayerScript.play("audios/clock-alarm");
    }
}