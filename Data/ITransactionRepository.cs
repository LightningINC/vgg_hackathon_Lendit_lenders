using System.Threading.Tasks;
using lendit.Model;

namespace lendit.Data
{
    public interface ITransactionRepository
    {
        Task<bool> Pledge(string userHash, int Amount, LenderPool lenderPool);
        Task<bool> Deposit(Wallet wallet);
        Task<bool> Withdraw(string userhash, int amount);
    }
}