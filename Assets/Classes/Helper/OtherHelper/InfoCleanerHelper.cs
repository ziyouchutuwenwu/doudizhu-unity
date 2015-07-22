using UnityEngine;
using System.Collections;

public class InfoCleanerHelper : MonoBehaviour
{
    public static void clearTimerInfo()
    {
        TimerHelper.removeLeftUserTimer();
        TimerHelper.removeRightUserTimer();
        TimerHelper.removeSelfUserTimer();
    }

    //reset系列为每次循环的时候调用
    public static void resetReadyInfo()
    {
        clearTimerInfo();

        InfoSpriteHelper.removeLeftUserReadyInfo();
        InfoSpriteHelper.removeRightUserReadyInfo();
        InfoSpriteHelper.removeSelfUserReadyInfo();

        ButtonHelper.removeReadyButton();
        ButtonHelper.removeChangeDeskButton();
    }    

    public static void resetJiaoDiZhuInfo()
    {
        clearTimerInfo();

        InfoSpriteHelper.removeLeftUserJiaoDiZhuInfo();
        InfoSpriteHelper.removeLeftUserBuJiaoInfo();
        InfoSpriteHelper.removeLeftUserQiangDiZhuInfo();
        InfoSpriteHelper.removeLeftUserBuQiangInfo();

        InfoSpriteHelper.removeRightUserJiaoDiZhuInfo();
        InfoSpriteHelper.removeRightUserBuJiaoInfo();
        InfoSpriteHelper.removeRightUserQiangDiZhuInfo();
        InfoSpriteHelper.removeRightUserBuQiangInfo();

        InfoSpriteHelper.removeSelfUserJiaoDiZhuInfo();
        InfoSpriteHelper.removeSelfUserBuJiaoInfo();
        InfoSpriteHelper.removeSelfUserQiangDiZhuInfo();
        InfoSpriteHelper.removeSelfUserBuQiangInfo();

        ButtonHelper.removeJiaoDiZhuButton();
        ButtonHelper.removeBuJiaoButton();
        ButtonHelper.removeQiangDiZhuButton();
        ButtonHelper.removeBuQiangButton();
    }

    public static void resetPlayInfo()
    {
        clearTimerInfo();

        InfoSpriteHelper.removeLeftUserBuChuInfo();
        InfoSpriteHelper.removeRightUserBuChuInfo();
        InfoSpriteHelper.removeSelfUserBuChuInfo();
        InfoSpriteHelper.removeSelfUserChuPaiErrorInfo();

        CardSpriteHelper.removeLeftUserSendCards();
        CardSpriteHelper.removeRightUserSendCards();
        CardSpriteHelper.removeSelfUserSendCards();

        ButtonHelper.removeBuChuButton();
        ButtonHelper.removeChongXuanButton();
        ButtonHelper.removeTiShiButton();
        ButtonHelper.removeChuPaiButton();
    }

    /**********************************************************************************************************************************/
    public static void clearLeftUserInfo()
    {
        InfoSpriteHelper.removeLeftUserReadyInfo();
        InfoSpriteHelper.removeLeftUserJiaoDiZhuInfo();
        InfoSpriteHelper.removeLeftUserBuJiaoInfo();
        InfoSpriteHelper.removeLeftUserQiangDiZhuInfo();
        InfoSpriteHelper.removeLeftUserBuQiangInfo();
        InfoSpriteHelper.removeLeftUserBuChuInfo();
    }

    public static void clearRightUserInfo()
    {
        InfoSpriteHelper.removeRightUserReadyInfo();
        InfoSpriteHelper.removeRightUserJiaoDiZhuInfo();
        InfoSpriteHelper.removeRightUserBuJiaoInfo();
        InfoSpriteHelper.removeRightUserQiangDiZhuInfo();
        InfoSpriteHelper.removeRightUserBuQiangInfo();
        InfoSpriteHelper.removeRightUserBuChuInfo();
    }

    public static void clearSelfUserInfo()
    {
        InfoSpriteHelper.removeLeftUserBuChuInfo();
        InfoSpriteHelper.removeRightUserBuChuInfo();
        InfoSpriteHelper.removeSelfUserBuChuInfo();
        InfoSpriteHelper.removeSelfUserChuPaiErrorInfo();

        InfoSpriteHelper.removeSelfUserBuChuInfo();
        InfoSpriteHelper.removeSelfUserChuPaiErrorInfo();
    }

    public static void clearReadyInfo()
    {
        resetReadyInfo();
    }

    public static void clearJiaoDiZhuInfo()
    {
        resetJiaoDiZhuInfo();
    }

    public static void clearPlayInfo()
    {
        resetPlayInfo();

        CardSpriteHelper.removeDiPaiCards();
        CardNumberHelper.removeLeftUserCardNumber();
        CardNumberHelper.removeRightUserCardNumber();
        CardSpriteHelper.removeSelfUserCards();
    }

    public static void clearAllInfo()
    {
        clearTimerInfo();
        clearReadyInfo();
        clearJiaoDiZhuInfo();
        clearPlayInfo();
    }
}