using Onboadr.Infrastructure.Services.Interface;
using onboadr_bank.Services.Interface;
using Onboardr.Domain.Entities;
using Onboardr.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Concrete
{
    public class SMSOTPService : ISMSOTPService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISMSOTPAuth _smsOTPAuth;

        public SMSOTPService(IUnitOfWork unitOfWork, ISMSOTPAuth smsOTPAuth)
        {
            _unitOfWork = unitOfWork;
            _smsOTPAuth = smsOTPAuth;

        }

        public bool SendSMSCode(string smsMessage, string recipientPhoneNumber, string fromPhoneNumber)
        {
            return _smsOTPAuth.SendSMSCode(smsMessage, recipientPhoneNumber, fromPhoneNumber);
        }


        public async Task<OTPInfo> GetSentOTPInfo(string uniqueUserName, string otpCode)
        {
            return await _unitOfWork.OTPInfos.Get(q => q.UniqueUserName == uniqueUserName);
        }

        public async Task CreateOTPCode(OTPInfo otpInfo)
        {
            await _unitOfWork.OTPInfos.Insert(otpInfo);
            await _unitOfWork.Save();

        }

    }
}
