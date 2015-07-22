using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UpdateCheckEncoder
    {
        public static string encode()
        {
            string deviceName = DeviceInfoHelper.getDeviceName();
            string osName = DeviceInfoHelper.getOsName();
            string osVersion = DeviceInfoHelper.getOsVersion();
            string appId = DeviceInfoHelper.getAppId();
            string deviceId = DeviceInfoHelper.getDeviceId();
            string appVersion = DeviceInfoHelper.getAppVersion();

            Dictionary<string, object> dict = new Dictionary<string, object>();

            dict["deviceName"] = deviceName;
            dict["osName"] = osName;
            dict["osVersion"] = osVersion;
            dict["appId"] = appId;
            dict["appVersion"] = appVersion;
            dict["deviceId"] = deviceId;

            return Json.Serialize(dict);
        }
    }
}