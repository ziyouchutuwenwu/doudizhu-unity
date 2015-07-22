using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkRequest
{
	public class SocketConst
	{
        public const int CMD_UPDATE_CHECK                           = 1111;
        public const int CMD_USER_GUEST_LOGIN                       = 1122;

        public const int CMD_USER_LOGIN                             = 1211;
        public const int CMD_USER_REGISTER                          = 1222;
        public const int CMD_USER_EDIT_PROFILE                      = 1233;

        public const int CMD_USER_ENTER_ROOM                        = 1133;
        public const int CMD_USER_SIT_ON_DESK                       = 1144;
        public const int CMD_USER_LEAVE_DESK                        = 1155;
        public const int CMD_USER_CHANGE_DESK                       = 1166;
        public const int CMD_USER_PROMPT_READY                      = 1177;
        public const int CMD_USER_READY_TO_PLAY                     = 1188;

        public const int CMD_DESK_FA_PAI                            = 2211;
        public const int CMD_DESK_PROMPT_USER_JIAO_DI_ZHU           = 2222;
        public const int CMD_DESK_JIAO_DI_ZHU                       = 2233;
        public const int CMD_DESK_JIAO_DI_ZHU_FINISH                = 2244;
        public const int CMD_DESK_FA_DI_PAI                         = 2255;
        public const int CMD_DESK_CHU_PAI                           = 2266;
        public const int CMD_DESK_CARDS_VALIDATE                    = 2277;
        public const int CMD_DESK_CRADS_PROMPT                      = 2288;
        public const int CMD_DESK_DA_PAI_END                        = 2299;

        public const int CMD_AUTO_DESK_JIAO_DI_ZHU                  = 3311;
        public const int CMD_AUTO_DESK_CHU_PAI                      = 3322;
        
        public const int CMD_USER_CHECK_RESUME_PLAY                 = 4411;
        public const int CMD_USER_RESUME_PLAY                       = 4422;

        public const int CMD_QUERY_DESK_USERS                       = 5511;
        public const int CMD_QUERY_DESK_FA_PAI                      = 5522;
        public const int CMD_QUERY_DESK_PROMPT_USER_JIAO_DI_ZHU     = 5533;
        public const int CMD_QUERY_DESK_JIAO_DI_ZHU                 = 5544;
        public const int CMD_QUERY_DESK_JIAO_DI_ZHU_FINISH          = 5555;
        public const int CMD_QUERY_DESK_FA_DI_PAI                   = 5566;
        public const int CMD_QUERY_DESK_CHU_PAI                     = 5577;

        public const int CMD_CLIENT_CONNECTED                       = 9911;
        public const int CMD_CLIENT_DISCONNECTED                    = 9922;
        public const int CMD_OTHER_CLIENT_DISCONNECTED              = 9933;

        //客户端自己定义
        public const int CMD_CLIENT_CONNECTED_FAIL                  = 9944;
	}
}