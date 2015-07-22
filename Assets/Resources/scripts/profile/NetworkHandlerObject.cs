using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;

namespace ProfileScene
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

        public void onUserEditProfile()
        {
            UserEditProfileObject userEditProfileObject = ModelManager.shareInstance().getUserEditProfileObject();
            if (userEditProfileObject.getIsError())
            {
                Debug.Log("修改个人信息失败");
                AlertViewHelper.addEditProfileErrorAlertView(_callBackObject.editProfileErrorAlertViewOkTapped);
            }
            else
            {
                Debug.Log("修改个人信息成功");
                AlertViewHelper.addEditProfileSuccessAlertView(_callBackObject.editProfileSuccessAlertViewOkTapped);
            }
        }
    }
}