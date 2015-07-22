using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientSocket.Business;
using UnityEngine;
using MiniJSON;

namespace NetworkRequest
{
    class QueryDeskJiaoDiZhuFinishDecoder
    {
        public static void decode(string jsonInfo)
        {
            DeskJiaoDiZhuFinishDecoder.decode(jsonInfo);

            //补充设置谁是地主
            DeskObject deskObject = ModelManager.shareInstance().getDeskObject();
            UserObject leftUserObject = ModelManager.shareInstance().getLeftUserObject();
            UserObject rightUserObject = ModelManager.shareInstance().getRightUserObject();
            UserObject selfUserObject = ModelManager.shareInstance().getSelfUserObject();

            if (deskObject.getDiZhuId() == leftUserObject.getId())
            {
                leftUserObject.setUserType(UserObject.UserType.LANDOWNER);
                rightUserObject.setUserType(UserObject.UserType.FARMER);
                selfUserObject.setUserType(UserObject.UserType.FARMER);
            }
            if (deskObject.getDiZhuId() == rightUserObject.getId())
            {
                rightUserObject.setUserType(UserObject.UserType.LANDOWNER);
                leftUserObject.setUserType(UserObject.UserType.FARMER);
                selfUserObject.setUserType(UserObject.UserType.FARMER);
            }
            if (deskObject.getDiZhuId() == selfUserObject.getId())
            {
                selfUserObject.setUserType(UserObject.UserType.LANDOWNER);
                leftUserObject.setUserType(UserObject.UserType.FARMER);
                rightUserObject.setUserType(UserObject.UserType.FARMER);
            }
        }
    }
}