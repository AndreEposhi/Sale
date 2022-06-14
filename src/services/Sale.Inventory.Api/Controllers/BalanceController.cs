using Microsoft.AspNetCore.Mvc;
using Sale.Core.Controller;
using Sale.Inventory.Application.Balance.Command;
using Sale.Inventory.Application.Balance.Services;
using System.Threading.Tasks;

namespace Sale.Inventory.Api.Controllers
{
    [Route("api/balances")]
    public class BalanceController : MainController
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBalance(AddBalanceCommand command)
            => CustomResponse(await _balanceService.AddBalance(command));

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBalance(UpdateBalanceCommand command)
            => CustomResponse(await _balanceService.UpdateBalance(command));
    }
}