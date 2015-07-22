using UnityEngine;
using System.Collections;

public class LocalStorageHelper : MonoBehaviour
{
    public static void clearAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public static string getStringVal(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public static void setStringVal(string key, string val)
    {
        PlayerPrefs.SetString(key, val);
    }

    public static void removeStringVal(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public static float getFloatVal(string key)
    {
        if (key.Length > 0)
        {
            return PlayerPrefs.GetFloat(key);
        }

        return 0f;
    }

    public static void setFloatVal(string key, float val)
    {
        if (key.Length > 0)
        {
            PlayerPrefs.SetFloat(key, val);
        }
    }

    public static void removeFloatVal(string key)
    {
        if (key.Length > 0)
        {
            PlayerPrefs.DeleteKey(key);
        }
    }

    public static bool getBoolVal(string key)
    {
        if (key.Length > 0)
        {
            int intVal = PlayerPrefs.GetInt(key);

            if (1 == intVal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public static void setBoolVal(string key, bool val)
    {
        if (key.Length > 0)
        {
            if (val)
            {
                PlayerPrefs.SetInt(key, 1);
            }
            else
            {
                PlayerPrefs.SetInt(key, 0);
            }
        }
    }

    public static void removeBoolVal(string key)
    {
        if (key.Length > 0)
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}