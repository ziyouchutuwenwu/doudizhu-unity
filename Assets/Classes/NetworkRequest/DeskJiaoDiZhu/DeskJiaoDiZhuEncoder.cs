using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskJiaoDiZhuEncoder
    {
        public static string encode(bool jiaoDiZhu)
        {
            int jiaoDiZhuInt = 0;
            if (jiaoDiZhu) jiaoDiZhuInt = 1;

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["jiaoDiZhu"] = jiaoDiZhuInt;

            return Json.Serialize(dict);
        }
    }
}