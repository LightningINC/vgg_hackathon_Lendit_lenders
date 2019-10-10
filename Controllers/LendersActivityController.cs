using System.Threading.Tasks;
using AutoMapper;
using lendit.Data;
using Microsoft.AspNetCore.Mvc;

namespace lendit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendersActivityController : ControllerBase
    {
        public readonly ILendersActivity _lendersActivity;
        public readonly IMapper _mapper;
        public LendersActivityController(ILendersActivity lendersActivity, IMapper mapper)
        {
            _lendersActivity = lendersActivity;
            _mapper = mapper;

        }
        [HttpGet("getApplications/{userhash}/{lenderPoolId}")]
        public async Task<IActionResult> GetBorrowerRequestList(string userhash,  int lenderPoolId )
        {
            var list = await _lendersActivity.GetBorrowerRequestList(userhash, lenderPoolId);
            if (list != null)
            {
                return Ok(list);
            }
            return BadRequest("better luck next time");
        }
        [HttpPost("Approval/{userhash}/{lenderPoolId}")]
        public async Task<IActionResult> Approval(string userhash, [FromBody] string borrowerhash,  int lenderPoolId )
        {
            if (await _lendersActivity.Approval(userhash, borrowerhash, lenderPoolId))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("cancelLend/{userhash}/{lenderPoolId}")]
        public async Task<IActionResult> CancelLend(string userhash,   int lenderPoolId )
        {
            if (await _lendersActivity.CancelLend(userhash, lenderPoolId))
            {
                return Ok();
            }
            return BadRequest("Better luck next time");
        }
        [HttpPost("borrowersList/{userhash}/")]
        public async Task<IActionResult> borrowersList(string userhash)
        {
            var borrowersList = await _lendersActivity.GetBorrowerList(userhash);
            if(borrowersList != null){
                return Ok(borrowersList);
            }
            
            return BadRequest("Better luck next time");

        }
    }
}