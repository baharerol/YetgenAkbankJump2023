using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Week_11_1.API.Models;
using Week_11_1.API.Models.Validators;
using Week_11_1.Domain.Entities;
using Week_11_1.Persistence.Contexts;
using Week_11_1.Persistence.Contexts;

namespace Week_11_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        public PerfectAppDbContext _perfectAppDbContext;

        public BankAccountsController(PerfectAppDbContext perfectAppDbContext)
        {
            _perfectAppDbContext = perfectAppDbContext;
        }

        [HttpPost("[action]")]
        public void SetDefaultUsersData()
        {
            List<BankAccount> people = new()
            {
                new BankAccount { Id = Guid.Parse("0d249a24-2c84-4d02-9e5a-cc4c9c3b21b5"), CreatedOn = DateTime.UtcNow,
                  CreatedByUserId = "1", FirstName = "James", LastName = "Smith", PhoneNumber = "5523367351"},
                new BankAccount { Id = Guid.Parse("ec137c01-7ee1-4b29-b0ac-9d3f667c1889"), CreatedOn = DateTime.UtcNow,
                  CreatedByUserId = "2", FirstName = "John", LastName = "Doe", PhoneNumber = "5530012345"},
                new BankAccount { Id = Guid.Parse("bd51cbfb-57c3-4f38-b65c-92d44c1d65e1"), CreatedOn = DateTime.UtcNow,
                  CreatedByUserId = "3", FirstName = "Emily", LastName = "Johnson", PhoneNumber = "5541122334"},
                new BankAccount { Id = Guid.Parse("a3a9f816-1a88-4e08-b99c-d7a2b7d5d120"), CreatedOn = DateTime.UtcNow,
                  CreatedByUserId = "4", FirstName = "Robert", LastName = "Brown", PhoneNumber = "5552233445"},
                new BankAccount { Id = Guid.Parse("8e09b2bf-421b-4155-a179-88949cc96147"), CreatedOn = DateTime.UtcNow,
                  CreatedByUserId = "5", FirstName = "Emma", LastName = "Wilson", PhoneNumber = "5563344556"}

            };
        }

        [HttpGet("[action]/{bankAccountId:guid")]
        public GetBankAccountDataResponseModel GetBankAccountData(Guid bankAccountId)
        {
            var bankAccount = _perfectAppDbContext.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);

            var response = new GetBankAccountDataResponseModel()
            {
                FirstName = bankAccount.FirstName,
                LastName = bankAccount.LastName,
                Balance = bankAccount.Balance,
            };

            return response;

        }

        [HttpPost]
        public IActionResult CreateBankAccount([FromBody] BankAccount bankAccount)
        {
            var validator = new BankAccountValidator();
            var validationResult = validator.Validate(bankAccount);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            return Ok();
        }
    }
}
