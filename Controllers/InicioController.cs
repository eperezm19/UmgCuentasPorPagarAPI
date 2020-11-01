using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {

            return "API Proyecto Cuentas por Pagar - Grupo 1 - UMG";
        }

    }

}
