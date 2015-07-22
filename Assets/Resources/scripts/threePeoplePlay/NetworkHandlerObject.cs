using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;

namespace ThreePeoplePlayScene
{
    public class NetworkHandlerObject : MonoBehaviour
    {
         private CallBackObject _callBackObject = null;
         private UpdateUIObject _updateUIObject = null;
         private DelayUpdateUIObject _delayUpdateUIObject = null;
 
        void Awake()
        {
            _callBackObject = GameObject.Find("callBackObject").GetComponent<CallBackObject>();
            _updateUIObject = GameObject.Find("updateUIObject").GetComponent<UpdateUIObject>();
            _delayUpdateUIObject = GameObject.Find("delayUpdateUIObject").GetComponent<DelayUpdateUIObject>();
        }

        public void onClientDisconnected()
        {
            AlertViewHelper.addConnectErrorAlertView(_callBackObject.connectErrorAlertViewOkTapped, _callBackObject.connectErrorAlertViewCancelTapped, "连接断开，是否重连？");
        }

        public void onOtherClientDisconnected()
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            UserHeadHelper.setLeftUserHead(leftUserObject.getGender(), leftUserObject.getUserType(), leftUserObject.getOnline());
            UserHeadHelper.setRightUserHead(rightUserObject.getGender(), rightUserObject.getUserType(), rightUserObject.getOnline());
            UserHeadHelper.setSelfUserHead(selfUserObject.getGender(), selfUserObject.getUserType(), selfUserObject.getOnline());
        }

        public void onUserSitOnDesk()
        {
            _updateUIObject.updateUserSitOnDeskUI();
        }

        public void onUserLeaveDesk()
        {
            _updateUIObject.updateUserLeaveDeskUI();
        }

        public void onUserPromptReady()
        {
            _updateUIObject.updateUserPromptReadyUI();
        }

        public void onUserReady()
        {
            _updateUIObject.updateUserReadyUI();
        }

        public void onDeskFaPai()
        {
            InfoCleanerHelper.clearAllInfo();
            DelayCallerHelper.doDelayCall(_delayUpdateUIObject.delayUpdateFaPaiUI);
        }

        public void onDeskPromptUserJiaoDiZhu()
        {
            _updateUIObject.updateDeskPromptUserJiaoDiZhuUI();
        }

        public void onDeskJiaoDiZhu()
        {
            InfoCleanerHelper.clearReadyInfo();
            InfoCleanerHelper.resetJiaoDiZhuInfo();

            DelayCallerHelper.doDelayCall(_delayUpdateUIObject.delayUpdateJiaoDiZhuUI);
        }

        public void onDeskJiaoDiZhuFinish()
        {
            _updateUIObject.updateDeskJiaoDiZhuFinishUI();
        }

        public void onDeskFaDiPai()
        {
            _updateUIObject.updateDeskFaDiPaiUI();
        }

        public void onDeskChuPai()
        {
            InfoCleanerHelper.resetPlayInfo();
            DelayCallerHelper.doDelayCall(_delayUpdateUIObject.delayUpdateDeskChuPaiUI);
        }

        public void onDeskCardsValidate()
        {
            _updateUIObject.updateDeskCardsValidateUI();
        }

        public void onDeskCardsPrompt()
        {
            _updateUIObject.updateDeskCardsPromptUI();
        }

        public void onDeskDaPaiEnd()
        {
            InfoCleanerHelper.resetPlayInfo();

            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            //延迟调用，给各自用户添加牌
            bool isLeftUserDiZhu = false;
            if (deskObject.getDiZhuId() == leftUserObject.getId()) isLeftUserDiZhu = true;
            DelayCallerHelper.doDelayCall(_delayUpdateUIObject.delayAddLeftUserSendCards, leftUserObject.getCards(), isLeftUserDiZhu);

            bool isRightUserDiZhu = false;
            if (deskObject.getDiZhuId() == rightUserObject.getId()) isRightUserDiZhu = true;
            DelayCallerHelper.doDelayCall(_delayUpdateUIObject.delayAddRightUserSendCards, rightUserObject.getCards(), isRightUserDiZhu);

            //设置牌数为0
            if (leftUserObject.getIsWin())
            {
                CardNumberHelper.setLeftUserCardNumber(0);
            }
            if (rightUserObject.getIsWin())
            {
                CardNumberHelper.setRightUserCardNumber(0);
            }

            //显示输赢界面
            SoundHelper.playWinLoseSound(selfUserObject.getIsWin());
            if (selfUserObject.getIsWin())
            {
                WinLoseViewHelper.addWinView(_callBackObject.playAgainButtonTapped, _callBackObject.winLoseViewCloseTapped);
            }
            else
            {
                WinLoseViewHelper.addLoseView(_callBackObject.playAgainButtonTapped, _callBackObject.winLoseViewCloseTapped);
            }

            ModelManager.shareInstance().resetPlaying();
        }

        //自动叫地主和自动出牌
        public void onAutoDeskJiaoDiZhu()
        {
            onDeskJiaoDiZhu();
        }

        public void onAutoDeskChuPai()
        {
            onDeskChuPai();
        }

        //断线重连
        public void onQueryDeskUsers()
        {
            onUserSitOnDesk();
        }

        public void onQueryDeskFaPai()
        {
            onDeskFaPai();
        }

        public void onQueryDeskPromptUserJiaoDiZhu()
        {
            onDeskPromptUserJiaoDiZhu();
        }

        public void onQueryDeskJiaoDiZhu()
        {
            onDeskJiaoDiZhu();
        }

        public void onQueryDeskJiaoDiZhuFinish()
        {
            onDeskJiaoDiZhuFinish();
        }

        public void onQueryDeskFaDiPai()
        {
            onDeskFaDiPai();
        }

        public void onQueryDeskChuPai()
        {
            DelayCallerHelper.doDelayCall(_delayUpdateUIObject.delayUpdateQueryDeskChuPaiUI);
        }
    }
}