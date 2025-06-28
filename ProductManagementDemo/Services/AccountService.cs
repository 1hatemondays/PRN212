using BusinessObjects;
using System.Collections.Generic;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository iAccountRepository;
        public AccountService()
        {
            iAccountRepository = new AccountRepository();
        }
        public AccountMember GetAccountById(string accountId)
        {
            return iAccountRepository.GetAccountById(accountId);
        }
    }
}
