using System.Threading.Tasks;
using lendit.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace lendit.Data
{
    public class LendersActivity : ILendersActivity
    {
        private const string STATUS_APPROVED = "approved";
        private const string STATUS_NOTPAID = "not paid";
        private readonly DataContext _context;
        public LendersActivity(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Approval(string lenderHash, string borrowerHash, int lenderPoolId)
        {
            User lender = await _context.Users.FirstOrDefaultAsync(finduser => finduser.UserHash.Equals(lenderHash));
            User borrower = await _context.Users.FirstOrDefaultAsync(finduser => finduser.UserHash.Equals(borrowerHash));

            if (lender != null && borrower != null)
            {
                //changing lenderpool status
                LenderPool lenderpool = await _context.LenderPools.FirstOrDefaultAsync(x => x.LenderPoolId == lenderPoolId);
                lenderpool.Status = STATUS_APPROVED;
                _context.LenderPools.Update(lenderpool);

                //adding transaction to lenderborrowertransaction
                LenderBorrowerTransaction lenderborrowertransaction = new LenderBorrowerTransaction()
                {
                    Status = STATUS_NOTPAID,
                    Amount = lenderpool.Amount,
                    LenderHash = lenderHash,
                    BorrowHash = borrowerHash
                };
                await _context.LenderBorrowerTransactions.AddAsync(lenderborrowertransaction);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CancelLend(string lenderHash, int lenderPoolId)
        {
            //check for a user
            User lender = await _context.Users.FirstOrDefaultAsync(finduser => finduser.UserHash.Equals(lenderHash));

            if (lender != null)
            {
                //changing lenderpool status
                LenderPool lenderpool = await _context.LenderPools.FirstOrDefaultAsync(x => x.LenderPoolId == lenderPoolId);
                //remove from lenderpool
                _context.Remove(lenderpool);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<LenderBorrowerTransaction>> GetBorrowerList(string userhash)
        {
            IEnumerable<LenderBorrowerTransaction> transactionList = await 
                _context.LenderBorrowerTransactions
                    .Include(trans => trans.Borrower)
                    .Include(trans => trans.Lender)
                    .Where(transc => transc.LenderHash.Equals(userhash)).ToListAsync();
            if(transactionList.Any()){
                return transactionList;
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetBorrowerRequestList(string lenderHash, int lenderPoolId)
        {
            IEnumerable<User> lenders = await _context.Users
                .Include(user => user.LenderPool)
                .Where(user => user.UserHash.Equals(lenderHash)).ToListAsync();
            if(lenders.Any() ){
                // IEnumerable<LenderBorrowerTransaction> LenderBorrowerTransactionList = await _context.LenderBorrowerTransactions
                //     .Include(x => x.Borrower)
                //     .Where( lbt => lbt.LenderHash.Equals(lenderHash)).ToListAsync();
                return lenders;
            }
            return null;
        }
    }
}
