using DIPlayground.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIPlayground.Controllers
{
    public class ValuesController : ApiController
    {
        private MyConsumerService _consumerService;

        public ValuesController(MyConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        // GET api/values
        public string Get()
        {
            string result = _consumerService.MyHandmadeTest();
            return result; 
        }
    }
}
