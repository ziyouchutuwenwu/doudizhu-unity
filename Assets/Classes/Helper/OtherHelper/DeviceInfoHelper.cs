using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class DeviceInfoHelper : MonoBehaviour
{
    public static string getDeviceName()
    {
        return SystemInfo.deviceModel;
    }

    public static string getOsName()
    {
		string osName = "";
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            osName = "windows";
        }
        if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			osName = "ios";
		}
		if (Application.platform == RuntimePlatform.Android) 
		{
			osName = "android";
		}

		return osName;
    }

    public static string getOsVersion()
    {
		string osNameWithVersion = SystemInfo.operatingSystem;
        string osVersion = osNameWithVersion;

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        {
            string[] words = osNameWithVersion.Split(' ');
            foreach (string splitWord in words)
            {
                Regex reg = new Regex("[0-9.]+");
                Match isMatched = reg.Match(splitWord);
                if (isMatched.Success)
                {
                    if (!splitWord.ToLower().Contains("os") && !splitWord.ToLower().Contains("api"))
                    {
                        osVersion = splitWord;
                        break;
                    }
                }
            }
        }

		return osVersion;
    }

    public static string getAppId()
    {
		return "com.mmcshadow.doudizhu";
//        return Application.bundleIdentifier;
    }

    public static string getAppVersion()
    {
		return "1.0";
//        return Application.version;
    }

    public static string getDeviceId()
    {
        return SystemInfo.deviceUniqueIdentifier;
    }
}