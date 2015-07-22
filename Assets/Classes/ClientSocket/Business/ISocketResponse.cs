using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientSocket.Business
{
    public interface ISocketResponse
    {
        void onReceiveData(short cmd,string response);
    }
}