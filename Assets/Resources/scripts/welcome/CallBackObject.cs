using UnityEngine;
using System.Collections;
using NetworkRequest;

namespace WelcomeScene
{
    public class CallBackObject : MonoBehaviour
    {
        public void connectErrorAlertViewOkTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
            RequestSender.doConnectServer();
        }

        public void connectErrorAlertViewCancelTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
        }

        public void loginErrorAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeLoginErrorAlertView();
        }
    }
}