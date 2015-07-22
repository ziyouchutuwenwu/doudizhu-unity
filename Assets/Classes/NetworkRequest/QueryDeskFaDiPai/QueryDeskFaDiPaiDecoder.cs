using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class QueryDeskFaDiPaiDecoder
    {
        public static void decode(string jsonInfo)
        {
            //和直接发底牌不同，不需要把底牌添加到已有的牌里面，也不需要给别的用户增加牌数
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;

            List<object> diPaiCardsList = data["diPaiCards"] as List<object>;
            List<int> diPaiCards = new List<int>();
            for (int i = 0; i < diPaiCardsList.Count; i++)
            {
                diPaiCards.Add(Convert.ToInt32(diPaiCardsList[i]));
            }
            deskObject.setDiPaiCards(diPaiCards);
        }
    }
}