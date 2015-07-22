using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using ClientSocket.Business;
using NetworkRequest;

namespace MainScene
{
    public class UIInitObject : MonoBehaviour
    {
        void Awake()
        {
            Button fastStartButton = GameObject.Find("fastStartButton").transform.GetComponent<Button>();
            fastStartButton.onClick.AddListener(delegate()
            {
                this.fastStartButtonTapped();
            });

            Button biSaiChangButton = GameObject.Find("biSaiChangButton").transform.GetComponent<Button>();
            biSaiChangButton.onClick.AddListener(delegate()
            {
                this.biSaiChangButtonTapped();
            });

            Button youXiChangButton = GameObject.Find("youXiChangButton").transform.GetComponent<Button>();
            youXiChangButton.onClick.AddListener(delegate()
            {
                this.youXiChangButtonTapped();
            });
        }

        public void fastStartButtonTapped()
        {
            AsyncSocket genSocket = AsyncSocket.shareInstance();
            if (genSocket.isConnected())
            {
                LoadingViewHelper.addLoadingView();
                RequestSender.doUserUserEnterRoomRequest();
            }
        }

        void Start()
        {

        }

        public void biSaiChangButtonTapped()
        {
            
        }

        public void youXiChangButtonTapped()
        {

        }
    }
}