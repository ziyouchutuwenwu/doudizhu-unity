using UnityEngine;
using System.Collections;
using ClientSocket.Business;

namespace ThreePeoplePlayScene
{
    public class CleanerObject : MonoBehaviour
    {
        void OnApplicationQuit()
        {
            AsyncSocket genSocket = AsyncSocket.shareInstance();
            genSocket.disConnect();
        }
    }
}