using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;
using UnityEngine.UI;

namespace ThreePeoplePlayScene
{
    public class UIInitObject : MonoBehaviour
    {
        private CallBackObject _callBackObject = null;

        public void backButtonClick()
        {
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            if (deskObject.getIsPlaying())
            {
                AlertViewHelper.addDisableLeaveAlertView(disableLeaveAlertViewOkTapped);
            }
            else
            {
                RequestSender.doUserLeaveDeskRequest();
                SceneHelper.switchSceneBack();
            }
        }

        void disableLeaveAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeDisableLeaveAlertView();
        }

        public void settingButtonClick()
        {
            SettingViewHelper.addSettingView(
                _callBackObject.settingViewInitCallBack,
                _callBackObject.bgMusicVolumeChangeCallBack,
                _callBackObject.soundVolumeChangeCallBack,
                _callBackObject.bgMusicMuteSwitchCallBack,
                _callBackObject.soundMuteSwitchCallBack,
                _callBackObject.settingViewCloseTapped
                );
        }

        void Awake()
        {
            _callBackObject = GameObject.Find("callBackObject").GetComponent<CallBackObject>();

            Button backButton = GameObject.Find("backButton").GetComponent<Button>();
            backButton.onClick.AddListener(delegate()
            {
                this.backButtonClick();
            });

            Button settingButton = GameObject.Find("settingButton").GetComponent<Button>();
            settingButton.onClick.AddListener(delegate()
            {
                this.settingButtonClick();
            });
        }

        void Start()
        {
            BgMusicHelper.addBgMusicPlayer();
            BgMusicHelper.playBgMusic();

            SoundHelper.addSoundPlayer();

            if (AppHelper.getIsFirstRunning())
            {
                AppHelper.setRunning(true);

                VolumeStorageHelper.setBgMusicVolume(1.0f);
                VolumeStorageHelper.setSoundVolume(1.0f);
                VolumeStorageHelper.setBgMusicMute(false);
                VolumeStorageHelper.setSoundMute(false);
            }
            float bgMusicVolume = VolumeStorageHelper.getBgMusicVolume();
            BgMusicHelper.setBgVolume(bgMusicVolume);

            float soundVolume = VolumeStorageHelper.getSoundVolume();
            SoundHelper.setVolume(soundVolume);

            bool isBgMusicMute = VolumeStorageHelper.getBgMusicMute();
            if (isBgMusicMute) BgMusicHelper.setBgVolume(0);

            bool isSoundMute = VolumeStorageHelper.getSoundMute();
            if (isSoundMute) SoundHelper.setVolume(0);

            UserHeadHelper.addLeftUserHead();
            UserHeadHelper.addRightUserHead();
            UserHeadHelper.addSelfUserHead();
        }
    }
}