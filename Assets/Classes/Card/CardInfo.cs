using UnityEngine;
using System.Collections;

public struct CardInfo {

    public enum CardType
    {
        INVALID = -1,
        HEI_TAO = 0,
        HONG_TAO = 1,
        MEI_HUA = 2,
        FANG_KUAI = 3,
        WANG = 4
    }

    public enum CardPromptType
    {
        CARD_PROMPT_INVALID_TYPE = -1,
        CARD_PROMPT_FEI_JI = 1,
        CARD_PROMPT_SHUN_ZI = 2,
        CARD_PROMPT_HUO_JIAN = 3,
        CARD_PROMPT_ZHA_DAN = 4,
        CARD_PROMPT_DAN_ZHANG = 5,
        CARD_PROMPT_DUI_ZI = 6,
        CARD_PROMPT_SAN_ZHANG = 7,
        CARD_PROMPT_SAN_DAI_YI = 8,
        CARD_PROMPT_SAN_DAI_ER = 9
    }

    public CardType cardType;
    public int cardNumber;
}