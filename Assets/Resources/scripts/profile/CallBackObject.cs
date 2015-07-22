using UnityEngine;
using System.Collections;
using NetworkRequest;
using UnityEngine.UI;

namespace ProfileScene
{
    public class CallBackObject : MonoBehaviour
    {
        public void editProfileSuccessAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeEditProfileSuccessAlertView();
        }

        public void editProfileErrorAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeEditProfileErrorAlertView();
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