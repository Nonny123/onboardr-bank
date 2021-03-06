using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Onboadr.Infrastructure.IRepository;
using Onboadr.Infrastructure.Services.Interface;
using Onboardr.Domain;
using Onboardr.Domain.DTOs;

namespace onboadr_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;
        private IAuthFactor _authFactor;
        private IOTPCodeRepository _otpCodeRepo;



        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper, IBankService bankService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _unitOfWork.Customers.GetAll();
                var results = _mapper.Map<IList<CustomerDTO>>(customers);
                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }



        [HttpGet("{id:int}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomer(int id)
        {

            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            var result = _mapper.Map<CusterDTO>(customer);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _mapper.Map<Customer>(customerDTO);
            await _unitOfWork.Customers.Insert(customer);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);

        }

        [HttpGet]
        [Route("get_banks")]
        public async Task<IActionResult> GetBanks()
        {
            try
            {
                var banks =  _bankService.GetBankDetails();
                //var results = _mapper.Map<IList<CustomerDTO>>(banks);
                return Ok(banks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
         [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
                return true;
            else
                return false;
        }

        private string GenerateOTP()
        {
            var generator = new Random();
            String code = generator.Next(0, 999999).ToString("D6");
            return code;
        } [HttpPost("send")]
        public void Send([FromBody]OTPInfo otpInfo)
        {
            string optCode = GenerateOTP();

            string msgToSMS = otpInfo.Message.Replace("%otpcode%", optCode);

            if(_authFactor.SendCode(msgToSMS, otpInfo.RecipientPhoneNumber, otpInfo.FromPhoneNumber))
            {
                DateTime timeOTPCodeGen = DateTime.Now;

                _otpCodeRepo.SaveSendCodeInfo
                    (otpInfo.UniqueUserName, optCode,
                     otpInfo.RecipientPhoneNumber, otpInfo.OTPExpiryInSeconds, timeOTPCodeGen);
            }
            else
            {
                //TODO: log error
            }
        }

        [HttpGet("verify")]
        public bool Verify(string uniqueUserName, string otpCode)
        {
            var optCodeInfo = _otpCodeRepo.GetOTPSentInfo(uniqueUserName, otpCode);

            if(optCodeInfo == null)
            {
                //TODO: Log error
                return false;
            }
            else
            {
                if(!IsOTPCodeExpired(optCodeInfo))
                {
                    optCodeInfo.Verified = true;
                    optCodeInfo.CodeVerifiedAt = DateTime.Now;
                    _otpCodeRepo.UpdateSendCodeInfo(optCodeInfo);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool IsOTPCodeExpired(OTPCodeInfo codeInfo)
        {
           DateTime codeGenTime = codeInfo.OTPCodeGenTime;
           int tokenExpiryInSec = codeInfo.OTPExpiryInSeconds;

           if((DateTime.Now - codeGenTime).TotalSeconds <= tokenExpiryInSec)
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