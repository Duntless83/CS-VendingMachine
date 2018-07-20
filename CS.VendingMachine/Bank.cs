using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.VendingMachine
{
    class Bank : IBank
    {
        private List<Account> _accounts;
        public Bank()
        {
            _accounts = new List<Account>();
            InitaliseAccounts();
        }

        private void InitaliseAccounts()
        {
            _accounts.Add(new Account
            {
                Number = 123456789,
                Pin = 0000,
                Balance = 2.0
            });
        }

        public async Task<bool> ProcessTransaction(int accountNumber, int pin, double price)
        {
            var success = false;

            var account = _accounts.FirstOrDefault(a => a.Number == accountNumber);
            if (account != null)
            {
                if (account.Pin == pin)
                {
                    account.Balance = account.Balance - price;
                    success = true;
                }
            }

            return success;
        }
    }
}
