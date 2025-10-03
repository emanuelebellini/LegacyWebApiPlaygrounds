using DIPlayground.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DIPlayground.Controllers
{
    public class ValuesController : ApiController
    {
        private IMyConsumerService _consumerService;

        public ValuesController(IMyConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            string result = _consumerService.MyHandmadeTest();
            return Ok(result); 
        }
    }
}
