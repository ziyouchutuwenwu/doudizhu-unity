using UnityEngine;
using System.Collections.Generic;


public class LoginTypeHelper : MonoBehaviour
{
    public static bool getIsLocalLoginTypeSet()
    {
        string loginType = LocalStorageHelper.getStringVal("loginType");

        if (loginType == "guestUser" || loginType == "registeredUser")
        {
            return true; 
        }

        return false;
    }

    public static bool getIsLocalLoginTypeGuestUser()
    {
        string loginType = LocalStorageHelper.getStringVal("loginType");

        if (loginType == "guestUser") return true;

        return false; 
    }

    public static bool getIsLocalLoginTypeRegisteredUser()
    {
        string loginType = LocalStorageHelper.getStringVal("loginType");

        if (loginType == "registeredUser") return true;

        return false;
    }

    public static void setLocalLoginTypeGuestUser()
    {
        LocalStorageHelper.setStringVal("loginType", "guestUser");
    }

    public static void setLocalLoginTypeRegisteredUser()
    {
        LocalStorageHelper.setStringVal("loginType", "registeredUser");
    }

    public static string getLocalLoginTypeRegisteredUserName()
    {
        return LocalStorageHelper.getStringVal("userName");
    }

    public static void setLocalLoginTypeRegisteredUserName(string userName)
    {
        LocalStorageHelper.setStringVal("userName", userName);
    }

    public static string getLocalLoginTypeRegisteredPassword()
    {
        return LocalStorageHelper.getStringVal("password");
    }

    public static void setLocalLoginTypeRegisteredPassword(string password)
    {
        LocalStorageHelper.setStringVal("password", password);
    }
}