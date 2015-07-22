using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class UserCheckResumePlayEncoder
    {
        public static string encode()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            return Json.Serialize(dict);
        }
    }
}