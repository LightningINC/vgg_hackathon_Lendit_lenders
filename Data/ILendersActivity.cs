using System.Collections.Generic;
using System.Threading.Tasks;
using lendit.Model;

namespace lendit.Data
{
    public interface ILendersActivity
    {
         Task<bool> Approval(string lenderHash, string borrowerHash, int lenderPoolId );
         Task<bool> CancelLend(string lenderHash, int lenderPoolId);
         Task<IEnumerable<User>> GetBorrowerRequestList(string lenderHash, int lenderPoolId);
         Task<IEnumerable<LenderBorrowerTransaction>> GetBorrowerList(string userhash);
    }
}