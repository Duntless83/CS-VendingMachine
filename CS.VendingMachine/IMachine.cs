using System.Threading.Tasks;

namespace CS.VendingMachine
{
    public interface IMachine
    {
        Task<bool> BuyCan(int accountNumber, int pin);
    }
}
