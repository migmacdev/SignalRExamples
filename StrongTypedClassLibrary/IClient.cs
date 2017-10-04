using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongTypedClassLibrary
{
    public interface IClient
    {
        string username { get; set; }

        void ReceiveMsg(ChatMsg msg);
    }
}
