using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Interface
{
    public interface IGetBanksService
    {
        Task<BankDetails> GetBankDetails();

        //Task<Post[]> GetPosts();
        //Task<ComicModel> GetComic();
        //Task<SunResultModel> GetSunRise();
        
        //Task<MailingListResult> GetMailingLists();
    }
}
