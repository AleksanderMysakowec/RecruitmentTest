using Microsoft.AspNetCore.Mvc;
using RecruitmentTest.RepositoryDirectory;

namespace RecruitmentTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinderController : ControllerBase
    {
        private readonly IFindOrder _logger;
        public FinderController(IFindOrder findOrderClass)
        {
           this._logger = findOrderClass;
        }

        [HttpGet(Name = "GetOrders")]
        public string GetOrders(string orderNumber, DateTime fromDate, DateTime toDate, string arrayClientCodes)
        {
           return  _logger.FindOrders(orderNumber, fromDate, toDate, arrayClientCodes.Split(','));
        }
    }
}