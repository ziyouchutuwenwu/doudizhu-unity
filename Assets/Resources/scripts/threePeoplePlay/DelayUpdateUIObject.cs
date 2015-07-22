using UnityEngine;
using System.Collections.Generic;

namespace ThreePeoplePlayScene
{
    public class DelayUpdateUIObject : MonoBehaviour {

        private Transform _buttonCanvs = null;
        private CallBackObject _callBackObject = null;
        private ButtonEventsObject _buttonEventObject = null;

        void Awake()
        {
            _buttonCanvs = GameObject.Find("buttonCanvas").transform;
            _buttonEventObject = GameObject.Find("buttonEventsObject").GetComponent<ButtonEventsObject>();
            _callBackObject = GameObject.Find("callBackObject").GetComponent<CallBackObject>();

            DelayCallerHelper.addDelayCallerObject();
        }

        public void delayReArrangeSelfUserCards(params object[] _args)
        {
            CardSpriteHelper.reArrangeSelfUserCards();
        }

        public void delayAddLeftUserSendCards(params object[] args)
        {
            List<int> cards = (List<int>)args[0];
            bool isDiZhu = (bool)args[1];
            CardSpriteHelper.addLeftUserSendCards(cards, isDiZhu);
        }

        public void delayAddRightUserSendCards(params object[] args)
        {
            List<int> cards = (List<int>)args[0];
            bool isDiZhu = (bool)args[1];
            CardSpriteHelper.addRightUserSendCards(cards, isDiZhu);
        }

        public void delayUpdateFaPaiUI(params object[] _args)
        {
            CardSpriteHelper.addDiPaiCards();
            SoundHelper.playWashCardSound();

            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();

            CardNumberHelper.addLeftUserCardNumber();
            CardNumberHelper.setLeftUserCardNumber(leftUserObject.getCardNumber());

            CardNumberHelper.addRightUserCardNumber();
            CardNumberHelper.setRightUserCardNumber(rightUserObject.getCardNumber());

            bool isDiZhu = false;
            if (deskObject.getDiZhuId() == selfUserObject.getId()) isDiZhu = true;
            CardSpriteHelper.addSelfUserCards(selfUserObject.getCards(), isDiZhu, _buttonEventObject.cardTapped);
        }

        public void delayUpdateJiaoDiZhuUI(params object[] _args)
        {
            DeskJiaoDiZhuObject deskJiaoDiZhuObject = ModelManager.shareInstance().getDeskJiaoDiZhuObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            //显示上上家的info，头像，声音
            if (deskJiaoDiZhuObject.getSecondPreviousUserObject().getId() == leftUserObject.getId())
            {
                if (deskJiaoDiZhuObject.getIsSecondPreviousUserFirstJiaoDiZhu())
                {
                    if (deskJiaoDiZhuObject.getIsSecondPreviousUserJiaoDiZhu())
                    {
                        InfoSpriteHelper.addLeftUserJiaoDiZhuInfo();
                    }
                    else
                    {
                        InfoSpriteHelper.addLeftUserBuJiaoInfo();
                    }
                }
                else
                {
                    if (deskJiaoDiZhuObject.getIsSecondPreviousUserJiaoDiZhu())
                    {
                        InfoSpriteHelper.addLeftUserQiangDiZhuInfo();
                    }
                    else
                    {
                        InfoSpriteHelper.addLeftUserBuQiangInfo();
                    }
                }
            }
            if (deskJiaoDiZhuObject.getSecondPreviousUserObject().getId() == rightUserObject.getId())
            {
                if (deskJiaoDiZhuObject.getIsSecondPreviousUserFirstJiaoDiZhu())
                {
                    if (deskJiaoDiZhuObject.getIsSecondPreviousUserJiaoDiZhu())
                    {
                        InfoSpriteHelper.addRightUserJiaoDiZhuInfo();
                    }
                    else
                    {
                        InfoSpriteHelper.addRightUserBuJiaoInfo();
                    }
                }
                else
                {
                    if (deskJiaoDiZhuObject.getIsSecondPreviousUserJiaoDiZhu())
                    {
                        InfoSpriteHelper.addRightUserQiangDiZhuInfo();
                    }
                    else
                    {
                        InfoSpriteHelper.addRightUserBuQiangInfo();
                    }
                }
            }
            if (deskJiaoDiZhuObject.getSecondPreviousUserObject().getId() == selfUserObject.getId())
            {
                if (deskJiaoDiZhuObject.getIsSecondPreviousUserFirstJiaoDiZhu())
                {
                    if (deskJiaoDiZhuObject.getIsSecondPreviousUserJiaoDiZhu())
                    {
                        InfoSpriteHelper.addSelfUserJiaoDiZhuInfo();
                    }
                    else
                    {
                        InfoSpriteHelper.addSelfUserBuJiaoInfo();
                    }
                }
                else
                {
                    if (deskJiaoDiZhuObject.getIsSecondPreviousUserJiaoDiZhu())
                    {
                        InfoSpriteHelper.addSelfUserQiangDiZhuInfo();
                    }
                    else
                    {
                        InfoSpriteHelper.addSelfUserBuQiangInfo();
                    }
                }
            }

            //显示上家的info，头像，声音
            if (deskJiaoDiZhuObject.getFirstPreviousUserObject().getId() == leftUserObject.getId())
            {
                if (deskJiaoDiZhuObject.getIsFirstPreviousUserFirstJiaoDiZhu())
                {
                    if (deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu()) InfoSpriteHelper.addLeftUserJiaoDiZhuInfo();
                    else InfoSpriteHelper.addLeftUserBuJiaoInfo();
                }
                else
                {
                    if (deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu()) InfoSpriteHelper.addLeftUserQiangDiZhuInfo();
                    else InfoSpriteHelper.addLeftUserBuQiangInfo();
                }
            }
            if (deskJiaoDiZhuObject.getFirstPreviousUserObject().getId() == rightUserObject.getId())
            {
                if (deskJiaoDiZhuObject.getIsFirstPreviousUserFirstJiaoDiZhu())
                {
                    if (deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu()) InfoSpriteHelper.addRightUserJiaoDiZhuInfo();
                    else InfoSpriteHelper.addRightUserBuJiaoInfo();
                }
                else
                {
                    if (deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu()) InfoSpriteHelper.addRightUserQiangDiZhuInfo();
                    else InfoSpriteHelper.addRightUserBuQiangInfo();
                }
            }
            if (deskJiaoDiZhuObject.getFirstPreviousUserObject().getId() == selfUserObject.getId())
            {
                if (deskJiaoDiZhuObject.getIsFirstPreviousUserFirstJiaoDiZhu())
                {
                    if (deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu()) InfoSpriteHelper.addSelfUserJiaoDiZhuInfo();
                    else InfoSpriteHelper.addSelfUserBuJiaoInfo();
                }
                else
                {
                    if (deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu()) InfoSpriteHelper.addSelfUserQiangDiZhuInfo();
                    else InfoSpriteHelper.addSelfUserBuQiangInfo();
                }
            }

            //播放上一家的声音
            bool isFirstPreviousUserMale = false;
            if (deskJiaoDiZhuObject.getFirstPreviousUserObject().getGender() == UserObject.Gender.MALE) isFirstPreviousUserMale = true;

            if (deskJiaoDiZhuObject.getIsFirstPreviousUserFirstJiaoDiZhu())
            {
                SoundHelper.playJiaoDiZhuSound(isFirstPreviousUserMale, deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu());
            }
            else
            {
                SoundHelper.playQiangDiZhuSound(isFirstPreviousUserMale, deskJiaoDiZhuObject.getIsFirstPreviousUserJiaoDiZhu());
            }

            //显示下一家的timer
            if (deskJiaoDiZhuObject.getNextUserObject().getId() == leftUserObject.getId())
            {
                TimerHelper.addLeftUserTimer(null, _callBackObject.timerAlarmCallBack);
            }
            if (deskJiaoDiZhuObject.getNextUserObject().getId() == rightUserObject.getId())
            {
                TimerHelper.addRightUserTimer(null, _callBackObject.timerAlarmCallBack);
            }
            if (deskJiaoDiZhuObject.getNextUserObject().getId() == selfUserObject.getId())
            {
                TimerHelper.addSelfUserTimer(null, _callBackObject.timerAlarmCallBack);

                if (deskJiaoDiZhuObject.getIsNextUserFirstJiaoDiZhu())
                {
                    ButtonHelper.addJiaoDiZhuButton(_buttonCanvs, _buttonEventObject.jiaoDiZhuButtonTapped);
                    ButtonHelper.addBuJiaoButton(_buttonCanvs, _buttonEventObject.buJiaoButtonTapped);
                }
                else
                {
                    ButtonHelper.addQiangDiZhuButton(_buttonCanvs, _buttonEventObject.qiangDiZhuButtonTapped);
                    ButtonHelper.addBuQiangButton(_buttonCanvs, _buttonEventObject.buQiangButtonTapped);
                }
            }

            UserHeadHelper.setLeftUserHead(leftUserObject.getGender(), leftUserObject.getUserType(), leftUserObject.getOnline());
            UserHeadHelper.setRightUserHead(rightUserObject.getGender(), rightUserObject.getUserType(), rightUserObject.getOnline());
            UserHeadHelper.setSelfUserHead(selfUserObject.getGender(), selfUserObject.getUserType(), selfUserObject.getOnline());
        }

        public void delayUpdateDeskChuPaiUI(params object[] _args)
        {
            DeskChuPaiObject deskChuPaiObject = ModelManager.shareInstance().getDeskChuPaiObject();
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            //理顺下自己的牌
            List<int> selfUpCards = CardSpriteHelper.getSelfUserUpCards();
            CardSpriteHelper.makeSelfUserUpCardsDown(selfUpCards);

            //显示上上个人出了什么牌/不出
            if (deskChuPaiObject.getSecondPreviousUserObject().getId() == leftUserObject.getId())
            {
                if (deskChuPaiObject.getIsSecondPreviousUserBuYao())
                {
                    InfoSpriteHelper.addLeftUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getSecondPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == leftUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addLeftUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getSecondPreviousUserObject().getId() == rightUserObject.getId())
            {
                if (deskChuPaiObject.getIsSecondPreviousUserBuYao())
                {
                    InfoSpriteHelper.addRightUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getSecondPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == rightUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addRightUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getSecondPreviousUserObject().getId() == selfUserObject.getId())
            {
                if (deskChuPaiObject.getIsSecondPreviousUserBuYao())
                {
                    InfoSpriteHelper.addSelfUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getSecondPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == selfUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addSelfUserSendCards(cards, isDiZhu);
            }

            //显示上一个人出了什么牌/不出
            if (deskChuPaiObject.getFirstPreviousUserObject().getId() == leftUserObject.getId())
            {
                CardNumberHelper.setLeftUserCardNumber(leftUserObject.getCardNumber());
                if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
                {
                    InfoSpriteHelper.addLeftUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getFirstPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == leftUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addLeftUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getFirstPreviousUserObject().getId() == rightUserObject.getId())
            {
                CardNumberHelper.setRightUserCardNumber(rightUserObject.getCardNumber());
                if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
                {
                    InfoSpriteHelper.addRightUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getFirstPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == rightUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addRightUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getFirstPreviousUserObject().getId() == selfUserObject.getId())
            {
                if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
                {
                    InfoSpriteHelper.addSelfUserBuChuInfo();
                }
                /*
                 * 这里是和自动出牌不一样的地方
                 * */
                CardSpriteHelper.moveSelfUserCardsToSend(deskChuPaiObject.getFirstPreviousUserSendCards());
                DelayCallerHelper.doDelayCall(delayReArrangeSelfUserCards);
            }

            //显示上一个人出牌动画和声音提示
            bool isFirstPreviousUserMale = false;
            if (deskChuPaiObject.getFirstPreviousUserObject().getGender() == UserObject.Gender.MALE) isFirstPreviousUserMale = true;

            if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
            {
                SoundHelper.playBuYaoSound(isFirstPreviousUserMale);
            }
            else
            {
                if (deskChuPaiObject.getFirstPreviousUserObject().getCardNumber() <= 2)
                {
                    SoundHelper.playCardsLeftSound(isFirstPreviousUserMale, deskChuPaiObject.getFirstPreviousUserObject().getCardNumber());
                }

                if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_HUO_JIAN)
                {
                    SoundHelper.playWangZhaSound(isFirstPreviousUserMale);
                    AnimationHelper.addHuoJianAnimation();
                }
                else if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_ZHA_DAN)
                {
                    SoundHelper.playZhaDanSound(isFirstPreviousUserMale);
                    AnimationHelper.addZhaDanAnimation();
                }
                else if (deskChuPaiObject.getIsFirstPreviousUserDaNi())
                {
                    //播放大你或者是出牌提示声音
                    int randomNumber = Random.Range(1, 54) % 6;
                    if (randomNumber == 1)
                    {
                        SoundHelper.playDaNiSound(isFirstPreviousUserMale);
                    }
                    else
                    {
                        SoundHelper.playSoundWithAnimation(
                        deskChuPaiObject.getFirstPreviousUserSendCards(),
                        deskChuPaiObject.getFirstPreviousUserSendCardsType(),
                        isFirstPreviousUserMale);
                    }
                }
                else
                {
                    SoundHelper.playSoundWithAnimation(
                        deskChuPaiObject.getFirstPreviousUserSendCards(),
                        deskChuPaiObject.getFirstPreviousUserSendCardsType(), 
                        isFirstPreviousUserMale);
                }
            }

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

            UserHeadHelper.setLeftUserHead(leftUserObject.getGender(), leftUserObject.getUserType(), leftUserObject.getOnline());
            UserHeadHelper.setRightUserHead(rightUserObject.getGender(), rightUserObject.getUserType(), rightUserObject.getOnline());
            UserHeadHelper.setSelfUserHead(selfUserObject.getGender(), selfUserObject.getUserType(), selfUserObject.getOnline());
        }

        public void delayUpdateQueryDeskChuPaiUI(params object[] _args)
        {
            DeskChuPaiObject deskChuPaiObject = ModelManager.shareInstance().getDeskChuPaiObject();
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            //显示上上个人出了什么牌/不出
            if (deskChuPaiObject.getSecondPreviousUserObject().getId() == leftUserObject.getId())
            {
                if (deskChuPaiObject.getIsSecondPreviousUserBuYao())
                {
                    InfoSpriteHelper.addLeftUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getSecondPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == leftUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addLeftUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getSecondPreviousUserObject().getId() == rightUserObject.getId())
            {
                if (deskChuPaiObject.getIsSecondPreviousUserBuYao())
                {
                    InfoSpriteHelper.addRightUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getSecondPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == rightUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addRightUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getSecondPreviousUserObject().getId() == selfUserObject.getId())
            {
                if (deskChuPaiObject.getIsSecondPreviousUserBuYao())
                {
                    InfoSpriteHelper.addSelfUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getSecondPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == selfUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addSelfUserSendCards(cards, isDiZhu);
            }

            //显示上一个人出了什么牌/不出
            if (deskChuPaiObject.getFirstPreviousUserObject().getId() == leftUserObject.getId())
            {
                CardNumberHelper.setLeftUserCardNumber(leftUserObject.getCardNumber());
                if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
                {
                    InfoSpriteHelper.addLeftUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getFirstPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == leftUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addLeftUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getFirstPreviousUserObject().getId() == rightUserObject.getId())
            {
                CardNumberHelper.setRightUserCardNumber(rightUserObject.getCardNumber());
                if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
                {
                    InfoSpriteHelper.addRightUserBuChuInfo();
                }
                List<int> cards = deskChuPaiObject.getFirstPreviousUserSendCards();
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == rightUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addRightUserSendCards(cards, isDiZhu);
            }
            if (deskChuPaiObject.getFirstPreviousUserObject().getId() == selfUserObject.getId())
            {
                if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
                {
                    InfoSpriteHelper.addSelfUserBuChuInfo();
                }
                /*
                 * 这里是和手动出牌不一样的地方
                 * */
                bool isDiZhu = false;
                if (deskObject.getDiZhuId() == selfUserObject.getId()) isDiZhu = true;
                CardSpriteHelper.addSelfUserSendCards(deskChuPaiObject.getFirstPreviousUserSendCards(), isDiZhu);
            }

            //显示上一个人出牌动画和声音提示
            bool isFirstPreviousUserMale = false;
            if (deskChuPaiObject.getFirstPreviousUserObject().getGender() == UserObject.Gender.MALE) isFirstPreviousUserMale = true;

            if (deskChuPaiObject.getIsFirstPreviousUserBuYao())
            {
                SoundHelper.playBuYaoSound(isFirstPreviousUserMale);
            }
            else
            {
                if (deskChuPaiObject.getFirstPreviousUserObject().getCardNumber() <= 2)
                {
                    SoundHelper.playCardsLeftSound(isFirstPreviousUserMale, deskChuPaiObject.getFirstPreviousUserObject().getCardNumber());
                }

                if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_HUO_JIAN)
                {
                    SoundHelper.playWangZhaSound(isFirstPreviousUserMale);
                    AnimationHelper.addHuoJianAnimation();
                }
                else if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_ZHA_DAN)
                {
                    SoundHelper.playZhaDanSound(isFirstPreviousUserMale);
                    AnimationHelper.addZhaDanAnimation();
                }
                else if (deskChuPaiObject.getIsFirstPreviousUserDaNi())
                {
                    //播放声音
                    SoundHelper.playDaNiSound(isFirstPreviousUserMale);
                }
                else
                {
                    //飞机
                    if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_FEI_JI)
                    {
                        SoundHelper.playFeiJiSound(isFirstPreviousUserMale);
                        AnimationHelper.addFeiJiAnimation();
                    }
                    //顺子
                    if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_SHUN_ZI)
                    {
                        SoundHelper.playShunZiSound(isFirstPreviousUserMale);
                        AnimationHelper.addShunZiAnimation();
                    }
                    //单张
                    if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_DAN_ZHANG)
                    {
                        int card = deskChuPaiObject.getFirstPreviousUserSendCards()[0];
                        CardInfo cardInfo = Card.getCardInfoFromInteger(card);
                        SoundHelper.playDanZhangSound(isFirstPreviousUserMale, cardInfo.cardNumber);
                    }
                    //对子
                    if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_DUI_ZI)
                    {
                        int card = deskChuPaiObject.getFirstPreviousUserSendCards()[0];
                        CardInfo cardInfo = Card.getCardInfoFromInteger(card);
                        SoundHelper.playDuiZiSound(isFirstPreviousUserMale, cardInfo.cardNumber);
                    }
                    //三张
                    if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_SAN_ZHANG)
                    {
                        SoundHelper.playSanZhangSound(isFirstPreviousUserMale);
                    }
                    //三带一
                    if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_SAN_DAI_YI)
                    {
                        SoundHelper.playSanDaiYiSound(isFirstPreviousUserMale);
                    }
                    //三带二
                    if (deskChuPaiObject.getFirstPreviousUserSendCardsType() == CardInfo.CardPromptType.CARD_PROMPT_SAN_DAI_ER)
                    {
                        SoundHelper.playSanDaiErSound(isFirstPreviousUserMale);
                    }
                }
            }

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

            UserHeadHelper.setLeftUserHead(leftUserObject.getGender(), leftUserObject.getUserType(), leftUserObject.getOnline());
            UserHeadHelper.setRightUserHead(rightUserObject.getGender(), rightUserObject.getUserType(), rightUserObject.getOnline());
            UserHeadHelper.setSelfUserHead(selfUserObject.getGender(), selfUserObject.getUserType(), selfUserObject.getOnline());
        }
    }
}

