using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBrandingStyleWeb.Models;

namespace NewBrandingStyleWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] CompanyModel company)
        {
            return Ok();
        }
    }
}
