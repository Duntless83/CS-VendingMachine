using System.Threading.Tasks;

namespace CS.VendingMachine
{
    public interface IBank
    {
        Task<bool> ProcessTransaction(int accountNumber, int pin, double price);
    }
}
