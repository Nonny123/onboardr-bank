using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboadr.Infrastructure.Services.Interface
{
        public interface ISMSOTPAuth
        {
            bool SendSMSCode(string smsMessage, string recipientPhoneNumber, string fromPhoneNumber);
        }
    
}
