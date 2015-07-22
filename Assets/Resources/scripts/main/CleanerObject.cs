using UnityEngine;
using System.Collections;
using ClientSocket.Business;

namespace MainScene
{
    public class CleanerObject : MonoBehaviour
    {
        void OnApplicationQuit()
        {
            AsyncSocket genSocket = AsyncSocket.shareInstance();
            genSocket.disConnect();

            //debug use
            LocalStorageHelper.clearAll();
        }
    }
}