using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBrandingStyleWeb.Models;

namespace NewBrandingStyleWeb.Controllers
{
    [ApiController]
    [Route("api/company")]
    public class ApiController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] CompanyModel company)
        {
            try
            {
                CompanyAddedViewModel response = new CompanyAddedViewModel
                {
                    NumberOfCharsInName = company.Name.Length,
                    NumberOfCharsInDescription = company.Description.Length,
                    IsHidden = !company.IsVisible
                };

                return Ok(response);
            }
            catch (Exception exception)
            {

                return NotFound(exception);
            }
        }
    }
}
