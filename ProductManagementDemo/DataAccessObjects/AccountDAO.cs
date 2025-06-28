using BusinessObjects;
namespace DataAccessLayer

{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountId)
        {
            AccountMember accountMember = new AccountMember();
            if(accountId.Equals("PS0001"))//Demonstration
            {
                accountMember.MemberId = accountId;
                accountMember.MemberPassword = "@1";
                accountMember.MemberRole = 1; //Admin
            }
            return accountMember;
        }
    }
}
