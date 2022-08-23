using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Interface
{
    public interface ISMSOTPService
    {
        bool SendSMSCode(string smsMessage, string recipientPhoneNumber, string fromPhoneNumber);

        Task CreateOTPCode(OTPInfo otpInfo);

        Task<OTPInfo> GetSentOTPInfo(string uniqueUserName, string otpCode);

        


    }
}
