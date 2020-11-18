using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBrandingStyleWeb.Database;
using NewBrandingStyleWeb.Entities;
using NewBrandingStyleWeb.Models;

namespace NewBrandingStyleWeb.Controllers
{
    [ApiController]
    [Route("api/company")]
    public class ApiController : ControllerBase
    {
        private readonly ExchangesDbContext _dbContext;
        public ApiController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
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
                var entity = new ItemEntity
                {
                    Name = company.Name,
                    Description = company.Description,
                    IsVisible = company.IsVisible
                };
                _dbContext.Items.Add(entity);
                _dbContext.SaveChanges();
                //return Ok(response);
                return Ok(_dbContext.Items);
            }
            catch (Exception exception)
            {

                return NotFound(exception);
            }
        }
    }
}
