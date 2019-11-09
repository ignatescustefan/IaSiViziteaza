using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IaSiViziteaza.BLL.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IaSiViziteaza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationBusiness _business;

        public LocationController(ILocationBusiness bussines)
        {
            _business = bussines;
        }
        //// GET: api/Location/5
        //[HttpGet("{id}", Name = "GetLocationById")]
        //public ActionResult Get(int id)
        //{
        //    return Ok(_business.GetLocationById(id));
        //}
    }
}
