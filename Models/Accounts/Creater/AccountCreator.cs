using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;

namespace MiniBank.Models
{
    class AccountCreator : IAccountCreator
    {
        public IAccount Create(int id, AccountType type, int userId, double balance = 0)
        {

            switch (type)
            {
                case AccountType.Simple:
                    return new SimpleAccount(id,userId, balance);
                case AccountType.Vip:
                    return new VipAccount(id,userId, balance);
                default:
                    throw new Exception("Invalid account type");
            }

        }
        public IAccount Create(AccountType type, int userId, double balance = 0)
        {
            switch (type)
            {
                case AccountType.Simple:
                    return new SimpleAccount(userId, balance);
                case AccountType.Vip:
                    return new VipAccount(userId, balance);
                default:
                    throw new Exception("Invalid account type");
            }
        }
    }
}