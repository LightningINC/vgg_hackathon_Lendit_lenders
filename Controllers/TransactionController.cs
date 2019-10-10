using System.Threading.Tasks;
using lendit.Data;
using lendit.Model;
using Microsoft.AspNetCore.Mvc;

namespace lendit.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public ITransactionRepository TransactionRepo { get; }
        public TransactionController(ITransactionRepository transactionRepo)
        {
            this.TransactionRepo = transactionRepo;
        }


        [HttpPost("pledge/{userhash}/{amount}")]
        public async Task<IActionResult> Pledge(string userhash, int amount, [FromBody] LenderPool lenderPool)
        {
            if (await TransactionRepo.Pledge(userhash, amount, lenderPool))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("deposit/{userhash}/{amount}")]
        public async Task<IActionResult> Deposit([FromBody] Wallet wallet)
        {
            if (await TransactionRepo.Deposit(wallet))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("withdraw/{userhash}/{amount}")]
        public async Task<IActionResult> Withdraw(string userhash, int amount)
        {

            if (await TransactionRepo.Withdraw(userhash, amount))
            {
                return Ok();
            }
            return BadRequest();
        }
    }

}