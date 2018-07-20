using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.VendingMachine
{
    public class Machine : IMachine
    {
        private List<MachineItem> _machineInventory;
        private IBank _bankLink;
        public Machine(IBank bankLink)
        {
            _bankLink = bankLink;
            _machineInventory = new List<MachineItem>();
            InitialiseInventory();
        }

        private void InitialiseInventory()
        {
            _machineInventory.Add(new MachineItem
            {
                Name = "Cans",
                price = 0.50,
                Quantity = 25
            });
        }

        public async Task<bool> BuyCan(int accountNumber, int pin)
        {
            var succesfulPurchase = false;
            var canInventory = _machineInventory.First(c => c.Name == "Cans");

            if (canInventory.Quantity > 0)
            {
                var transcation = await _bankLink.ProcessTransaction(accountNumber, pin, canInventory.price);
                if (transcation)
                {
                    canInventory.Quantity = canInventory.Quantity - 1;
                    succesfulPurchase = true;
                }
            }

            return succesfulPurchase;
        }
    }
}
