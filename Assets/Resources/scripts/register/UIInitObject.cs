using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;
using UnityEngine.UI;

namespace RegisterScene
{
    public class UIInitObject : MonoBehaviour
    {
        public void backButtonClick()
        {
            SceneHelper.switchSceneBack();
        }

        public void registerButtonClick()
        {
            string userName = GameObject.Find("userNameInputField").GetComponent<InputField>().text;
            string password = GameObject.Find("passwordInputField").GetComponent<InputField>().text;
            string confirmPasswdInputField = GameObject.Find("confirmPasswdInputField").GetComponent<InputField>().text;

            if (password != confirmPasswdInputField)
            {
                Debug.Log("密码不一致，请重新输入");
                return;
            }

            bool isMale = true;
            Toggle maleToggle = GameObject.Find("maleToggle").GetComponent<Toggle>();
            Toggle femaleToggle = GameObject.Find("femaleToggle").GetComponent<Toggle>();
            if (maleToggle.isOn) isMale = true;
            if ( femaleToggle.isOn ) isMale = false;

            RequestSender.doUserRegisterRequest(userName, password, isMale);
        }

        void Awake()
        {
            Button backButton = GameObject.Find("backButton").GetComponent<Button>();
            backButton.onClick.AddListener(delegate()
            {
                this.backButtonClick();
            });

            Button registerButton = GameObject.Find("registerButton").GetComponent<Button>();
            registerButton.onClick.AddListener(delegate()
            {
                this.registerButtonClick();
            });
        }
    }
}