using UnityEngine;
using System.Collections;

public class AppHelper : MonoBehaviour
{
    public static bool getIsFirstRunning()
    {
        bool val = LocalStorageHelper.getBoolVal("running");
        if (val) return false;

        return true;
    }

    public static void setRunning(bool isRunning)
    {
        LocalStorageHelper.setBoolVal("running", isRunning);
    }
}