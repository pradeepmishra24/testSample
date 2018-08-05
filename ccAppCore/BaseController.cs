using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ccAppCore
{

    public abstract class BaseController<T> : Controller where T:BaseController<T>
    {


        private ILogger<T> _logger;

        protected ILogger<T> Logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>());

       // protected ILogger<T> Logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>());
    }
}
