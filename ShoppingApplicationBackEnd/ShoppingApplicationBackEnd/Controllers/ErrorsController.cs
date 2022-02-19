using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Controllers
{
   
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        [Route("/Errors")]
        public IActionResult Error()
        {
            var httpFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return StatusCode(500, new
            {
                Error = httpFeature.Error.Message,
                InnterException = httpFeature.Error.InnerException,
                StackTrace = httpFeature.Error.StackTrace
            });

        }

    }
}
