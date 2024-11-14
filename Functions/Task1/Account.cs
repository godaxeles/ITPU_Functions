using System;
using System.Collections.Generic;
using Functions.Task1.ThirdParty;

namespace Functions.Task1
{
    public class Account
    {
        public IPasswordChecker PasswordChecker { get; set; }
        public IAccountManager AccountManager { get; set; }

        public void Register(IAccount account)
        {
            CheckOnValidName(account.GetName());
            CheckOnValidPassword(account.GetPassword());

            account.SetCreatedDate(new DateTime());
            account.SetAddresses(GetAddresses(account));
            AccountManager.CreateNewAccount(account);
        }

        private void CheckOnValidName(string name)
        {
            if (name.Length <= 5)
            {
                throw new WrongAccountNameException();
            }
        }

        private void CheckOnValidPassword(string password)
        {
            if (password.Length > 8 || PasswordChecker.Validate(password) != CheckStatus.Ok)
            {
                throw new WrongPasswordException();
            }
        }

        private List<IAddress> GetAddresses(IAccount account)
        {
            return new List<IAddress>
            {
                account.GetHomeAddress(),
                account.GetWorkAddress(),
                account.GetAdditionalAddress()
            };
        }
    }
}