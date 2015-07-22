using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;

namespace MainScene
{
    public class NetworkHandlerObject : MonoBehaviour
    {
        private CallBackObject _callBackObject = null;

        void Awake()
        {
            _callBackObject = GameObject.Find("callBackObject").GetComponent<CallBackObject>();
        }

        public void onClientConnected()
        {
            Debug.Log("连接成功");
            RequestSender.doUpdateCheckRequest();

            if (LoginTypeHelper.getIsLocalLoginTypeGuestUser())
            {
                RequestSender.doGuestUserLoginRequest();
            }
            else if (LoginTypeHelper.getIsLocalLoginTypeRegisteredUser())
            {
                string userName = LoginTypeHelper.getLocalLoginTypeRegisteredUserName();
                string password = LoginTypeHelper.getLocalLoginTypeRegisteredPassword();
                RequestSender.doUserLoginRequest(userName, password);
            }
        }

        public void onClientConnectFail()
        {
            AlertViewHelper.addConnectErrorAlertView(_callBackObject.connectErrorAlertViewOkTapped, _callBackObject.connectErrorAlertViewCancelTapped, "连接失败，是否重连？");
            Debug.Log("连接失败");
        }

        public void onClientDisconnected()
        {
            AlertViewHelper.addConnectErrorAlertView(_callBackObject.connectErrorAlertViewOkTapped, _callBackObject.connectErrorAlertViewCancelTapped, "连接断开，是否重连？");
            Debug.Log("和服务器断开连接");
        }

        public void onVersionUpdateCheck()
        {
            VersionObject versionObject = ModelManager.shareInstance().getVersionObject();
            if (versionObject.getUrl().Length > 0)
            {
                AlertViewHelper.addUpdateAlertView(_callBackObject.updateAlertViewOkTapped, _callBackObject.updateAlertViewCancelTapped);
            }
        }

        public void onUserGuestLogin()
        {
            UserLoginObject userLoginObject = ModelManager.shareInstance().getUserLoginObject();
            if (userLoginObject.getIsError())
            {
                Debug.Log("游客登录失败");
                AlertViewHelper.addLoginErrorAlertView(_callBackObject.loginErrorAlertViewOkTapped);
            }
            else
            {
                Debug.Log("游客登录成功");
                RequestSender.doUserCheckResumePlayRequest();
            }
        }

        public void onUserLogin()
        {
            UserLoginObject userLoginObject = ModelManager.shareInstance().getUserLoginObject();
            if (userLoginObject.getIsError())
            {
                Debug.Log("注册用户登录失败");
                AlertViewHelper.addLoginErrorAlertView(_callBackObject.loginErrorAlertViewOkTapped);
            }
            else
            {
                Debug.Log("注册用户登录成功");
                RequestSender.doUserCheckResumePlayRequest();
            }
        }

        public void onUserCheckResumePlay()
        {
            UserCheckResumePlayObject userCheckResumePlayObject = ModelManager.shareInstance().getUserCheckResumePlayObject();
            if (userCheckResumePlayObject.getShouldResumePlay())
            {
                SceneHelper.switchToScene("threePeoplePlay");
            }
        }

        public void onUserEnterRoom()
        {
            SceneHelper.switchToScene("threePeoplePlay"); 
        }
    }
}