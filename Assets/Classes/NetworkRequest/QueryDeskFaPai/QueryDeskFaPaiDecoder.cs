using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class QueryDeskFaPaiDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskFaPaiDecoder.decode(jsonInfo);
        }
    }
}