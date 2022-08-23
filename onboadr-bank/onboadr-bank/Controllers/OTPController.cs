using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onboadr.Infrastructure.Services.Interface;
using onboadr_bank.DTOs.SMSOTP;
using onboadr_bank.Services.Interface;
using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly ISMSOTPService _smsOTPService;
        private readonly IMapper _mapper;


        public OTPController(ISMSOTPService smsOTPService, IMapper mapper)
        {
            _smsOTPService = smsOTPService;
            _mapper = mapper;
        }

        //template, %optcode% will be replaced with OTPCode
        [HttpPost("send")]
        public async Task Send([FromBody] CreateSMSOTPRequestDTO createSMSOTPRequestInfoDTO)
        {
            string optCode = GenerateOTP();

            string msgToSMS = createSMSOTPRequestInfoDTO.Message.Replace("%otpcode%", optCode);

            if (_smsOTPService.SendSMSCode(msgToSMS, createSMSOTPRequestInfoDTO.RecipientPhoneNumber, createSMSOTPRequestInfoDTO.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                var otpInfo = _mapper.Map<OTPInfo>(createSMSOTPRequestInfoDTO);

                await _smsOTPService.CreateOTPCode(otpInfo);
            }
            else
            {
                //TODO: log error
            }
        }

        //[HttpGet("verify")]
        //public bool Verify(string uniqueUserName, string otpCode)
        //{
        //    var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

        //    if (optCodeInfo == null)
        //    {
        //        //TODO: Log error
        //        return false;
        //    }
        //    else
        //    {
        //        if (!IsOTPCodeExpired(optCodeInfo))
        //        {
        //            optCodeInfo.Verified = true;
        //            optCodeInfo.CodeVerifiedAt = DateTime.Now;
        //            _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
        //            return true;
        //        }
        //        else
        //            return false;
        //    }

        //}

        private bool IsOTPCodeExpired(OTPInfo codeInfo)
        {
            DateTime codeGenTime = codeInfo.timeOTPCodeGen;
            int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

            if ((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        }

        
    }
}

