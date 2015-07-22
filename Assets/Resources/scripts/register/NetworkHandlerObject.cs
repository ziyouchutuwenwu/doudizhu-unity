using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;
using UnityEngine.UI;

namespace RegisterScene
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

        public void onUserRegister()
        {
            /* 注册成功，则保存登录方式，用户名，密码等数据，以后自动登录
             * 设置本地登录方式为注册用户自动登录模式
             */
            UserLoginObject userLoginObject = ModelManager.shareInstance().getUserLoginObject();
            if (!userLoginObject.getIsError())
            {
                AlertViewHelper.addRegisterSuccessAlertView(_callBackObject.registerSuccessAlertViewOkTapped);
                Debug.Log("注册成功");
            }
            else
            {
                AlertViewHelper.addRegisterErrorAlertView(_callBackObject.registerErrorAlertViewOkTapped);
                Debug.Log("注册失败");
            }
        }
    }
}