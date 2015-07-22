using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class DeskJiaoDiZhuFinishDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            DeskChuPaiObject deskChuPaiObject = ModelManager.shareInstance().getDeskChuPaiObject();

            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            Dictionary<string, object> data = Json.Deserialize(jsonInfo) as Dictionary<string, object>;
            string deskDiZhuId = Convert.ToString(data["diZhuId"]);

            deskObject.setDiZhuId(deskDiZhuId);

            //设置第一个出牌的人
            if (deskDiZhuId == leftUserObject.getId())
            {
                deskChuPaiObject.setNextUserObject(leftUserObject);
                deskChuPaiObject.setIsNextUserMustChuPai(true);
            }
            if (deskDiZhuId == rightUserObject.getId())
            {
                deskChuPaiObject.setNextUserObject(rightUserObject);
                deskChuPaiObject.setIsNextUserMustChuPai(true);
            }
            if (deskDiZhuId == selfUserObject.getId())
            {
                deskChuPaiObject.setNextUserObject(selfUserObject);
                deskChuPaiObject.setIsNextUserMustChuPai(true);
            }
        }
    }
}