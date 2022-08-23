using Onboadr.Infrastructure.Services.Interface;
using System;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;

namespace Onboadr.Infrastructure.Services.Concrete
{
    public class SMSOTPAuth : ISMSOTPAuth
    {
        public SMSOTPAuth(string twilioAccountId, string twilioAuthToken)
        {
            _twilioAccountId = twilioAccountId;
            _twilioAuthToken = twilioAuthToken;
        }

        public bool SendSMSCode
            (string smsMessage, string recipientPhoneNumber, string fromPhoneNumber)
        {
            try
            {
                //TwilioClient.Init(_twilioAccountId, _twilioAuthToken);

                //var message = MessageResource.Create(
                //    body: smsMessage,
                //    from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                //    to: new Twilio.Types.PhoneNumber(recipientPhoneNumber)
                //);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Twilio SMS OTP exception: " + ex.Message);
                return false;
            }
        }

        private string _twilioAccountId;
        private string _twilioAuthToken;
    }
}

