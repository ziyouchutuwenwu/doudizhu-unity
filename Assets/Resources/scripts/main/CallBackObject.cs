using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;

namespace MainScene
{
    public class CallBackObject : MonoBehaviour {

        public void connectErrorAlertViewOkTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
            RequestSender.doConnectServer();
        }

        public void connectErrorAlertViewCancelTapped(ActionViewScript script)
        {
            AlertViewHelper.removeConnectErrorAlertView();
            LoadingViewHelper.removeLoadingView();
        }

        public void loginErrorAlertViewOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeLoginErrorAlertView();
        }

        public void updateAlertViewOkTapped(ActionViewScript script)
        {
            VersionObject versionObject = ModelManager.shareInstance().getVersionObject();
            Application.OpenURL(versionObject.getUrl());

            AlertViewHelper.removeUpdateAlertView();
        }

        public void updateAlertViewCancelTapped(ActionViewScript script)
        {
            AlertViewHelper.removeUpdateAlertView();
        }

        public void sitOnDeskErrorOkTapped(AlertViewScript script)
        {
            AlertViewHelper.removeSitOnDeskErrorAlertView();
        }
        
    }
}

