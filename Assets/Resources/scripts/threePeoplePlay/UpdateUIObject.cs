using UnityEngine;
using System.Collections.Generic;

namespace ThreePeoplePlayScene
{
    public class UpdateUIObject : MonoBehaviour
    {
        private Transform _buttonCanvs = null;
        private ButtonEventsObject _buttonEventObject = null;
        private CallBackObject _callBackObject = null;

        void Awake()
        {
            _buttonCanvs = GameObject.Find("buttonCanvas").transform;
            _buttonEventObject = GameObject.Find("buttonEventsObject").GetComponent<ButtonEventsObject>();
            _callBackObject = GameObject.Find("callBackObject").GetComponent<CallBackObject>();
        }

        public void updateUserSitOnDeskUI()
        {
            UserSitOnDeskObject sitOnDeskObject = ModelManager.shareInstance().getUserSitOnDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            if (sitOnDeskObject.getError())
            {
                AlertViewHelper.addSitOnDeskErrorAlertView(_callBackObject.sitOnDeskErrorOkTapped);
            }
            else
            {
                if (leftUserObject.getId().Length > 0)
                {
                    //头像不是正面，也没有向正面翻转
                    if (!UserHeadHelper.isLeftUserHeadFront() && !UserHeadHelper.isLeftUserHeadTuringToFront())
                    {
                        UserHeadHelper.doLeftUserHeadFlip();
                    }
                    UserHeadHelper.setLeftUserHead(leftUserObject.getGender(), leftUserObject.getUserType(), leftUserObject.getOnline());
                }

                if (rightUserObject.getId().Length > 0)
                {
                    if (!UserHeadHelper.isRightUserHeadFront() && !UserHeadHelper.isRightUserHeadTuringToFront())
                    {
                        UserHeadHelper.doRightUserHeadFlip();
                    }
                    UserHeadHelper.setRightUserHead(rightUserObject.getGender(), rightUserObject.getUserType(), rightUserObject.getOnline());
                }

                if (selfUserObject.getId().Length > 0)
                {
                    if (!UserHeadHelper.isSelfUserHeadFront() && !UserHeadHelper.isSelfUserHeadTuringToFront())
                    {
                        UserHeadHelper.doSelfUserHeadFlip();
                    }
                    UserHeadHelper.setSelfUserHead(selfUserObject.getGender(), selfUserObject.getUserType(), selfUserObject.getOnline());
                }
            }
        }

        public void updateUserLeaveDeskUI()
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            if (leftUserObject.getId().Length == 0)
            {
                InfoCleanerHelper.clearLeftUserInfo();

                if (UserHeadHelper.isLeftUserHeadFront() && !UserHeadHelper.isLeftUserHeadTuringToBack())
                {
                    UserHeadHelper.doLeftUserHeadFlip();
                }
            }
            if (rightUserObject.getId().Length == 0)
            {
                InfoCleanerHelper.clearRightUserInfo();

                if (UserHeadHelper.isRightUserHeadFront() && !UserHeadHelper.isRightUserHeadTuringToBack())
                {
                    UserHeadHelper.doRightUserHeadFlip();
                }
            }
            if (selfUserObject.getId().Length == 0)
            {
                InfoCleanerHelper.clearSelfUserInfo();

                if (UserHeadHelper.isSelfUserHeadFront() && !UserHeadHelper.isSelfUserHeadTuringToBack())
                {
                    UserHeadHelper.doSelfUserHeadFlip();
                }

                InfoCleanerHelper.clearLeftUserInfo();

                if (UserHeadHelper.isLeftUserHeadFront() && !UserHeadHelper.isLeftUserHeadTuringToBack())
                {
                    UserHeadHelper.doLeftUserHeadFlip();
                }

                InfoCleanerHelper.clearRightUserInfo();

                if (UserHeadHelper.isRightUserHeadFront() && !UserHeadHelper.isSelfUserHeadTuringToBack())
                {
                    UserHeadHelper.doRightUserHeadFlip();
                }
            }
        }

        public void updateUserPromptReadyUI()
        {
            ButtonHelper.addReadyButton(_buttonCanvs, _buttonEventObject.readyButtonTapped);
            ButtonHelper.addChangeDeskButton(_buttonCanvs, _buttonEventObject.changeDeskButtonTapped);
        }

        public void updateUserReadyUI()
        {
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            if (leftUserObject.getReady())
            {
                InfoSpriteHelper.addLeftUserReadyInfo();
            }
            if (rightUserObject.getReady())
            {
                InfoSpriteHelper.addRightUserReadyInfo();
            }
            if (selfUserObject.getReady())
            {
                InfoSpriteHelper.addSelfUserReadyInfo();
            }
        }

        public void updateDeskPromptUserJiaoDiZhuUI()
        {
            InfoCleanerHelper.clearReadyInfo();

            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();

            DeskJiaoDiZhuObject deskJiaoDiZhuObject = ModelManager.shareInstance().getDeskJiaoDiZhuObject();
            if (deskJiaoDiZhuObject.getNextUserObject().getId() == selfUserObject.getId())
            {
                TimerHelper.addSelfUserTimer(null, _callBackObject.timerAlarmCallBack);
                ButtonHelper.addJiaoDiZhuButton(_buttonCanvs, _buttonEventObject.jiaoDiZhuButtonTapped);
                ButtonHelper.addBuJiaoButton(_buttonCanvs, _buttonEventObject.buJiaoButtonTapped);
            }
            if (deskJiaoDiZhuObject.getNextUserObject().getId() == leftUserObject.getId())
            {
                TimerHelper.addLeftUserTimer(null, _callBackObject.timerAlarmCallBack);
            }
            if (deskJiaoDiZhuObject.getNextUserObject().getId() == rightUserObject.getId())
            {
                TimerHelper.addRightUserTimer(null, _callBackObject.timerAlarmCallBack);
            }
        }

        public void updateDeskJiaoDiZhuFinishUI()
        {
            InfoCleanerHelper.clearReadyInfo();
            InfoCleanerHelper.clearJiaoDiZhuInfo();

            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            if (deskObject.getDiZhuId() == selfUserObject.getId())
            {
                CardSpriteHelper.removeSelfUserCards();
            }
        }

        public void updateDeskFaDiPaiUI()
        {
            DeskChuPaiObject deskChuPaiObject = ModelManager.shareInstance().getDeskChuPaiObject();
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            CardSpriteHelper.setDiPaiCards(deskObject.getDiPaiCards());

            CardNumberHelper.setLeftUserCardNumber(leftUserObject.getCardNumber());
            CardNumberHelper.setRightUserCardNumber(rightUserObject.getCardNumber());

            bool isDiZhu = false;
            if (deskObject.getDiZhuId() == selfUserObject.getId()) isDiZhu = true;
            CardSpriteHelper.addSelfUserCards(selfUserObject.getCards(), isDiZhu, _buttonEventObject.cardTapped);

            //提示下一个人要出牌了
            if (deskChuPaiObject.getNextUserObject().getId() == leftUserObject.getId())
            {
                TimerHelper.addLeftUserTimer(null, _callBackObject.timerAlarmCallBack);
            }
            if (deskChuPaiObject.getNextUserObject().getId() == rightUserObject.getId())
            {
                TimerHelper.addRightUserTimer(null, _callBackObject.timerAlarmCallBack);
            }
            if (deskChuPaiObject.getNextUserObject().getId() == selfUserObject.getId())
            {
                TimerHelper.addSelfUserTimer(null, _callBackObject.timerAlarmCallBack);

                if (deskChuPaiObject.getIsNextUserMustChuPai())
                {
                    ButtonHelper.addBuChuButton(_buttonCanvs, false, _buttonEventObject.buChuButtonTapped);
                    ButtonHelper.addChongXuanButton(_buttonCanvs, false, _buttonEventObject.chongXuanButtonTapped);
                    ButtonHelper.addTiShiButton(_buttonCanvs, false, _buttonEventObject.tiShiButtonTapped);
                    ButtonHelper.addChuPaiButton(_buttonCanvs, false, _buttonEventObject.chuPaiButtonTapped);
                }
                else
                {
                    ButtonHelper.addBuChuButton(_buttonCanvs, true, _buttonEventObject.buChuButtonTapped);
                    ButtonHelper.addChongXuanButton(_buttonCanvs, false, _buttonEventObject.chongXuanButtonTapped);
                    ButtonHelper.addTiShiButton(_buttonCanvs, true, _buttonEventObject.tiShiButtonTapped);
                    ButtonHelper.addChuPaiButton(_buttonCanvs, false, _buttonEventObject.chuPaiButtonTapped);
                }
            }
        }

        public void updateDeskCardsValidateUI()
        {
            DeskCardsValidateObject deskCardsValidateObject = ModelManager.shareInstance().getDeskCardsValidateObject();
            DeskChuPaiObject deskChuPaiObject = ModelManager.shareInstance().getDeskChuPaiObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            if (!deskCardsValidateObject.getIsCardsValidate())
            {
                InfoSpriteHelper.addSelfUserChuPaiErrorInfo();

                if (deskChuPaiObject.getNextUserObject().getId() == selfUserObject.getId())
                {
                    TimerHelper.addSelfUserTimer(null, _callBackObject.timerAlarmCallBack);

                    if (deskChuPaiObject.getIsNextUserMustChuPai())
                    {
                        ButtonHelper.addBuChuButton(_buttonCanvs, false, _buttonEventObject.buChuButtonTapped);
                        ButtonHelper.addChongXuanButton(_buttonCanvs, false, _buttonEventObject.chongXuanButtonTapped);
                        ButtonHelper.addTiShiButton(_buttonCanvs, false, _buttonEventObject.tiShiButtonTapped);
                        ButtonHelper.addChuPaiButton(_buttonCanvs, false, _buttonEventObject.chuPaiButtonTapped);
                    }
                    else
                    {
                        ButtonHelper.addBuChuButton(_buttonCanvs, true, _buttonEventObject.buChuButtonTapped);
                        ButtonHelper.addChongXuanButton(_buttonCanvs, false, _buttonEventObject.chongXuanButtonTapped);
                        ButtonHelper.addTiShiButton(_buttonCanvs, true, _buttonEventObject.tiShiButtonTapped);
                        ButtonHelper.addChuPaiButton(_buttonCanvs, false, _buttonEventObject.chuPaiButtonTapped);
                    }
                }
            }
        }

        public void updateDeskCardsPromptUI()
        {
            DeskCardsPromptObject deskCardsPromptObject = ModelManager.shareInstance().getDeskCardsPromptObject();

            int index = deskCardsPromptObject.getLoopCardsIndex();
            if (deskCardsPromptObject.getCards().Count > 0)
            {
                CardArray cards = deskCardsPromptObject.getCards()[index];

                List<int> promptCards = cards.toIntList();
                CardSpriteHelper.makeSelfUserDownCardsUp(promptCards);

                if (promptCards.Count > 0)
                {
                    ButtonHelper.setChongXuanButtonEnabled(true);
                    ButtonHelper.setChuPaiButtonEnabled(true);
                }
            }
            else
            {
                _buttonEventObject.buChuButtonTapped(null);
            }
        }
    }
}