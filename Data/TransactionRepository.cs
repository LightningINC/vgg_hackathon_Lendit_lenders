using System.Threading.Tasks;
using lendit.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace lendit.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;
        public TransactionRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<bool> Deposit(Wallet wallet)
        {
            User user = await _context.Users.FirstOrDefaultAsync(finduser => finduser.UserHash.Equals(wallet.UserHash));
            if (user != null)
            {
                await _context.Wallets.AddAsync(wallet);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Withdraw(string userhash, int amount)
        {
            User user = await _context.Users.FirstOrDefaultAsync(finduser => finduser.UserHash.Equals(userhash));
            if (user != null)
            {
                Wallet oldWallet = await _context.Wallets.FirstOrDefaultAsync(x => x.UserHash.Equals(userhash));
                if (int.TryParse(oldWallet.Balance, out int result))
                {
                    oldWallet.Balance = (result - amount).ToString();
                }

                _context.Wallets.Update(oldWallet);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Pledge(string userHash, int Amount, LenderPool lenderPool)
        {
            User user = await _context.Users.FirstOrDefaultAsync(finduser => finduser.UserHash.Equals(userHash));
            if (user != null)
            {
                Wallet oldWallet = await _context.Wallets.FirstOrDefaultAsync(x => x.UserHash.Equals(userHash));
                if (int.TryParse(oldWallet.Balance, out int result))
                {
                    oldWallet.Balance = (result - Amount).ToString();
                }

                _context.Wallets.Update(oldWallet);

                await _context.LenderPools.AddAsync(lenderPool);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

     
    }
}