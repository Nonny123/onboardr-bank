using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboardr.Domain;

namespace Onboadr.Infrastructure.Services.Interface
{
    public interface IBankService
    {
        BankDetails GetBankDetails();
    }
}
