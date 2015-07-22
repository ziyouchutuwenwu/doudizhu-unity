using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class VersionUpdateCheckDecoder
    {
        public static void decode(string jsonInfo)
        {
            VersionObject versionObject = ModelManager.shareInstance().getVersionObject();

            Dictionary<string,object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            string platform = (string)data["platform"];
            string url = (string)data["url"];
            
            versionObject.setPlatform(platform);
            versionObject.setUrl(url);
        }
    }
}