using Currencyexchange.Models;
using Currencyexchange.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Currencyexchange.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IDataRepository<Transaction> _dataRepository;
        private IExchangService _exchangService;
        private ILogger<TransactionController> _logger;
        public TransactionController(IDataRepository<Transaction> dataRepository, IExchangService exchangService,ILogger<TransactionController> logger)
        {
            _dataRepository = dataRepository;
            _exchangService = exchangService; 
            _logger = logger;
        }

        // GET: api/Transactions
        [Authorize]
        [HttpGet ]
        public IActionResult Get()
        {
            _logger.LogInformation("Get all");
            IEnumerable<Transaction> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        // GET: api/Transaction/5
        [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Reading value for {Id}", id);
            Transaction transaction = _dataRepository.Get(id);
            if (transaction == null)
            {
                return NotFound("The Transaction record couldn't be found.");
            }
            return Ok(transaction);
        }


        // POST: api/Transaction
        [Authorize]
        [HttpPost]
        public async ValueTask<IActionResult> Exchang([FromBody] ExchangRequest exchangRequest)
        {
            _logger.LogDebug("Add transaction");
          var result= await _exchangService.Exchang(exchangRequest);

            return Ok(result);    
        }
    }
}
