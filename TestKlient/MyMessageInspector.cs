using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace TestKlient
{
    using System.ServiceModel.Dispatcher;
    public class MyMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return request;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            int i = 0;
        }
    }
}
