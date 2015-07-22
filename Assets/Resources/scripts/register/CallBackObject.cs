using UnityEngine;
using System.Collections;
using NetworkRequest;
using UnityEngine.UI;

namespace RegisterScene
{
    public class CallBackObject : MonoBehaviour
    {
        public void registerSuccessAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeRegisterSuccessAlertView();

            string userName = GameObject.Find("userNameInputField").GetComponent<InputField>().text;
            string password = GameObject.Find("passwordInputField").GetComponent<InputField>().text;

            LoginTypeHelper.setLocalLoginTypeRegisteredUser();
            LoginTypeHelper.setLocalLoginTypeRegisteredUserName(userName);
            LoginTypeHelper.setLocalLoginTypeRegisteredPassword(password);

            SceneHelper.switchToScene("main");
        }

        public void registerErrorAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeRegisterErrorAlertView();
        }

        public void connectErrorAlertViewOkTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
            RequestSender.doConnectServer();
        }

        public void connectErrorAlertViewCancelTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
        }
    }
}