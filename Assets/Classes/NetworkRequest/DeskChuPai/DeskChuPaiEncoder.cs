using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskChuPaiEncoder
    {
        public static string encode(List<int> cards)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["cards"] = cards;

            return Json.Serialize(dict);
        }
    }
}