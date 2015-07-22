using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;

namespace ThreePeoplePlayScene
{
    public class ButtonEventsObject : MonoBehaviour {

        private UpdateUIObject _updateUIObject = null;

        void Awake()
        {
            _updateUIObject = GameObject.Find("updateUIObject").GetComponent<UpdateUIObject>();
        }

        //准备按钮
        public void readyButtonTapped(ButtonScript buttonScript)
        {
            ButtonHelper.removeReadyButton();
            ButtonHelper.removeChangeDeskButton();

            RequestSender.doUserReadyRequest();
        }

        //换桌按钮
        public void changeDeskButtonTapped(ButtonScript buttonScript)
        {
            ButtonHelper.removeReadyButton();
            ButtonHelper.removeChangeDeskButton();

            RequestSender.doUserChangeDeskRequest();
        }

        //叫地主按钮
        public void jiaoDiZhuButtonTapped(ButtonScript buttonScript)
        {
            ButtonHelper.removeJiaoDiZhuButton();
            ButtonHelper.removeBuJiaoButton();

            ButtonHelper.removeQiangDiZhuButton();
            ButtonHelper.removeBuQiangButton();

            RequestSender.doUserJiaoDiZhuRequest(true);
        }

        //不叫按钮
        public void buJiaoButtonTapped(ButtonScript buttonScript)
        {
            ButtonHelper.removeJiaoDiZhuButton();
            ButtonHelper.removeBuJiaoButton();

            ButtonHelper.removeQiangDiZhuButton();
            ButtonHelper.removeBuQiangButton();

            RequestSender.doUserJiaoDiZhuRequest(false);
        }

        //抢地主按钮
        public void qiangDiZhuButtonTapped(ButtonScript buttonScript)
        {
            jiaoDiZhuButtonTapped(buttonScript);
        }

        //不抢按钮
        public void buQiangButtonTapped(ButtonScript buttonScript)
        {
            buJiaoButtonTapped(buttonScript);
        }

        //不出按钮
        public void buChuButtonTapped(ButtonScript buttonScript)
        {
            ButtonHelper.removeBuChuButton();
            ButtonHelper.removeChongXuanButton();
            ButtonHelper.removeTiShiButton();
            ButtonHelper.removeChuPaiButton();
            InfoSpriteHelper.removeSelfUserChuPaiErrorInfo();

            SoundHelper.playCardSendSound();

            List<int> upCards = CardSpriteHelper.getSelfUserUpCards();
            CardSpriteHelper.makeSelfUserUpCardsDown(upCards);

            List<int> cards = new List<int>();
            RequestSender.doUserChuPaiRequest(cards);
        }

        //重选按钮
        public void chongXuanButtonTapped(ButtonScript buttonScript)
        {
            SoundHelper.playCardSendSound();

            ButtonHelper.setChongXuanButtonEnabled(false);
            ButtonHelper.setChuPaiButtonEnabled(false);

            List<int> upCards = CardSpriteHelper.getSelfUserUpCards();
            CardSpriteHelper.makeSelfUserUpCardsDown(upCards);
        }

        //提示按钮
        public void tiShiButtonTapped(ButtonScript buttonScript)
        {
            SoundHelper.playCardSendSound();

            DeskCardsPromptObject deskCardsPromptObject = ModelManager.shareInstance().getDeskCardsPromptObject();
            if (deskCardsPromptObject.getCards().Count > 0)
            {
                List<int> upCards = CardSpriteHelper.getSelfUserUpCards();
                CardSpriteHelper.makeSelfUserUpCardsDown(upCards);
                _updateUIObject.updateDeskCardsPromptUI();
            }
            else
            {
                RequestSender.doUserCardsPromptRequest();
            }
        }

        //出牌按钮
        public void chuPaiButtonTapped(ButtonScript buttonScript)
        {
            ButtonHelper.removeBuChuButton();
            ButtonHelper.removeChongXuanButton();
            ButtonHelper.removeTiShiButton();
            ButtonHelper.removeChuPaiButton();
            InfoSpriteHelper.removeSelfUserChuPaiErrorInfo();

            SoundHelper.playCardSendSound();

            List<int> cards = CardSpriteHelper.getSelfUserUpCards();
            RequestSender.doUserChuPaiRequest(cards);
        }

        //卡牌点击
        public void cardTapped(CardButtonScript cardSpriteScript)
        {
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();
            DeskChuPaiObject deskChuPaiObject = ModelManager.shareInstance().getDeskChuPaiObject();
            if (deskChuPaiObject.getNextUserObject().getId() == selfUserObject.getId())
            {
                if (deskChuPaiObject.getIsNextUserMustChuPai())
                {
                    //必须出牌，不出和提示按钮不能点
                    ButtonHelper.setBuChuButtonEnabled(false);
                    ButtonHelper.setTiShiButtonEnabled(false);
                }
                else
                {
                    //四个按钮都允许高亮
                    ButtonHelper.setBuChuButtonEnabled(true);
                    ButtonHelper.setTiShiButtonEnabled(true);
                }

                //UP的牌张数大于0重选和出牌按钮允许，否则禁止
                cardSpriteScript.getTopParentScript().getCardSpriteScriptByTag(cardSpriteScript.getTag()).triggerMoveUpDown();
                List<int> upStatusCards = CardSpriteHelper.getSelfUserUpCards();
                if (upStatusCards.Count > 0)
                {
                    SoundHelper.playCardTappedSound();

                    ButtonHelper.setChongXuanButtonEnabled(true);
                    ButtonHelper.setChuPaiButtonEnabled(true);
                }
                else
                {
                    ButtonHelper.setChongXuanButtonEnabled(false);
                    ButtonHelper.setChuPaiButtonEnabled(false);
                }
            }
        }
    }
}

