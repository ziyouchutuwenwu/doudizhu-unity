using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;
using UnityEngine.UI;

namespace WelcomeScene
{
    public class UIInitObject : MonoBehaviour
    {
        public void guestLoginButtonClick()
        {
            RequestSender.doGuestUserLoginRequest();
        }

        public void accountLoginButtonClick()
        {
            SceneHelper.switchToScene("login");
        }

        void Awake()
        {
            Button guestLoginButton = GameObject.Find("guestLoginButton").GetComponent<Button>();
            guestLoginButton.onClick.AddListener(delegate()
            {
                this.guestLoginButtonClick();
            });

            Button accountLoginButton = GameObject.Find("accountLoginButton").GetComponent<Button>();
            accountLoginButton.onClick.AddListener(delegate()
            {
                this.accountLoginButtonClick();
            });
        }
    }
}