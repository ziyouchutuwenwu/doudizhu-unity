using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;
using System;

namespace ThreePeoplePlayScene
{
    public class CallBackObject : MonoBehaviour {

        private Transform _buttonCanvs = null;
        private ButtonEventsObject _buttonEventObject = null;

        void Awake()
        {
            _buttonCanvs = GameObject.Find("buttonCanvas").transform;
            _buttonEventObject = GameObject.Find("buttonEventsObject").GetComponent<ButtonEventsObject>();
        }

        //进桌子错误按钮
        public void sitOnDeskErrorOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeSitOnDeskErrorAlertView();
            SceneHelper.switchSceneBack();
        }

        public void timerAlarmCallBack(ClockShakeScript clockShakeScript)
        {
            SoundHelper.playClockAlarmSound();
        }

        public void playAgainButtonTapped()
        {
            InfoCleanerHelper.clearPlayInfo();

            WinLoseViewHelper.removeWinView();
            WinLoseViewHelper.removeLoseView();

            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            UserHeadHelper.setLeftUserHead(leftUserObject.getGender(), leftUserObject.getUserType(), leftUserObject.getOnline());
            UserHeadHelper.setRightUserHead(rightUserObject.getGender(), rightUserObject.getUserType(), rightUserObject.getOnline());
            UserHeadHelper.setSelfUserHead(selfUserObject.getGender(), selfUserObject.getUserType(), selfUserObject.getOnline());

            _buttonEventObject.readyButtonTapped(null);
        }

        public void winLoseViewCloseTapped()
        {
            InfoCleanerHelper.clearPlayInfo();

            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            UserHeadHelper.setLeftUserHead(leftUserObject.getGender(), leftUserObject.getUserType(), leftUserObject.getOnline());
            UserHeadHelper.setRightUserHead(rightUserObject.getGender(), rightUserObject.getUserType(), rightUserObject.getOnline());
            UserHeadHelper.setSelfUserHead(selfUserObject.getGender(), selfUserObject.getUserType(), selfUserObject.getOnline());

            ButtonHelper.addReadyButton(_buttonCanvs, _buttonEventObject.readyButtonTapped);
            ButtonHelper.addChangeDeskButton(_buttonCanvs, _buttonEventObject.changeDeskButtonTapped);
        }

        //设置界面
        public void settingViewInitCallBack(SettingViewScript script)
        {
            float bgMusicVolume = VolumeStorageHelper.getBgMusicVolume();
            SettingViewHelper.setBgMusicVolume(bgMusicVolume);

            float soundVolume = VolumeStorageHelper.getSoundVolume();
            SettingViewHelper.setSoundVolume(soundVolume);

            bool isBgMusicMute = VolumeStorageHelper.getBgMusicMute();
            SettingViewHelper.setBgMusicMute(isBgMusicMute);
            if (isBgMusicMute) BgMusicHelper.setBgVolume(0);

            bool isSoundMute = VolumeStorageHelper.getSoundMute();
            SettingViewHelper.setSoundMute(isSoundMute);
            if (isSoundMute) SoundHelper.setVolume(0);
        }

        public void bgMusicVolumeChangeCallBack(SettingViewScript script,float percent)
        {
            bool isMute = false;
            if (Convert.ToInt32(Math.Abs(percent)) == 0) isMute = true;
            VolumeStorageHelper.setBgMusicVolume(percent);

            VolumeStorageHelper.setBgMusicMute(isMute);
            BgMusicHelper.setBgVolume(percent);
        }

        public void soundVolumeChangeCallBack(SettingViewScript script, float percent)
        {
            bool isMute = false;
            if (Convert.ToInt32(Math.Abs(percent)) == 0) isMute = true;
            VolumeStorageHelper.setSoundVolume(percent);
            VolumeStorageHelper.setSoundMute(isMute);

            SoundHelper.setVolume(percent);
        }

        public void bgMusicMuteSwitchCallBack(SettingViewScript script, bool isMute)
        {
            Debug.Log("isMute " + isMute);
            float volume = 0f;
            VolumeStorageHelper.setBgMusicMute(isMute);
            if (!isMute)
            {
                volume = VolumeStorageHelper.getBgMusicVolume();
            }

            BgMusicHelper.setBgVolume(volume);
        }

        public void soundMuteSwitchCallBack(SettingViewScript script, bool isMute)
        {
            float volume = 0f;
            VolumeStorageHelper.setSoundMute(isMute);
            if (!isMute)
            {
                volume = VolumeStorageHelper.getSoundVolume();
            }

            SoundHelper.setVolume(volume);
        }

        public void settingViewCloseTapped(SettingViewScript script)
        {
            SettingViewHelper.removeSettingView();
        }
        //-------------------------------------------------------

        public void connectErrorAlertViewOkTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
            SceneHelper.switchSceneBack();
        }

        public void connectErrorAlertViewCancelTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
        }
    }
}

