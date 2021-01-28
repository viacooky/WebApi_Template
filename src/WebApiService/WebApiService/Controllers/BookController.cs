using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiService.Dto;
using WebApiService.Dto.Book;

namespace WebApiService.Controllers
{
    [ApiController]
    [Route("api/book")]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        private ILogger<BookController> _logger;
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [Route("Add")]
        [HttpPost]
        public DtoAddResult Add(DtoAddInput input)
        {
            _logger.LogDebug("这里是 debug");
            _logger.LogInformation("这里是 Information");
            throw new ArgumentException("ddd");
            return new DtoAddResult
            {
                StateCode = StateCode.Success,
                Message   = "",
                Result = new DtoAddResult.ResultCls
                {
                    Id         = Guid.NewGuid().ToString(),
                    Name       = input.Name,
                    Price      = 10,
                    CreateTime = input.CreateTime
                }
            };
        }
    }
}