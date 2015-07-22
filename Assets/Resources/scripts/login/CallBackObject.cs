using UnityEngine;
using System.Collections;
using NetworkRequest;
using UnityEngine.UI;

namespace LoginScene
{
    public class CallBackObject : MonoBehaviour
    {
        public void loginSuccessAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeLoginSuccessAlertView();

            string userName = GameObject.Find("userNameInputField").GetComponent<InputField>().text;
            string password = GameObject.Find("passwordInputField").GetComponent<InputField>().text;

            LoginTypeHelper.setLocalLoginTypeRegisteredUser();
            LoginTypeHelper.setLocalLoginTypeRegisteredUserName(userName);
            LoginTypeHelper.setLocalLoginTypeRegisteredPassword(password);

            SceneHelper.switchToScene("main");
        }

        public void loginErrorAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeLoginErrorAlertView();
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