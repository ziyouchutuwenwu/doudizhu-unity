using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;
using UnityEngine.UI;

namespace LoginScene
{
    public class UIInitObject : MonoBehaviour
    {
        public void backButtonClick()
        {
            SceneHelper.switchSceneBack();
        }

        public void loginButtonClick()
        {
            string userName = GameObject.Find("userNameInputField").GetComponent<InputField>().text;
            string password = GameObject.Find("passwordInputField").GetComponent<InputField>().text;
            RequestSender.doUserLoginRequest(userName, password);
        }

        public void registerButtonClick()
        {
            SceneHelper.switchToScene("register");
        }

        void Awake()
        {
            Button backButton = GameObject.Find("backButton").GetComponent<Button>();
            backButton.onClick.AddListener(delegate()
            {
                this.backButtonClick();
            });

            Button loginButton = GameObject.Find("loginButton").GetComponent<Button>();
            loginButton.onClick.AddListener(delegate()
            {
                this.loginButtonClick();
            });

            Button registerButton = GameObject.Find("registerButton").GetComponent<Button>();
            registerButton.onClick.AddListener(delegate()
            {
                this.registerButtonClick();
            });
        }
    }
}