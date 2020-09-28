using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
            _municipalityService = municipalityService;
        }

        [Route("GetTaxByMunicipalityNameAndDate/{name}/{fromdate}/{todate}")]
        [HttpGet]
        public async Task<IActionResult> GetTaxByMunicipalityNameAndDate(string name, DateTime fromdate, DateTime todate)
        {
            try
            {
            var result = await _municipalityService.GetTaxByMunicipalityNameAndDate(name, fromdate, todate);
            if (!result.HasValue)
                return NotFound("No data Found");
            return Ok(result);
        }
            catch(Exception ex)
            {
                return BadRequest("Some Error Occured");
            }
    }

        [Route("AddMunicipalityTax")]
        [HttpPost]

        public async Task<IActionResult> AddTaxForMunicipality([FromBody] MunicipalityModel municipality)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _municipalityService.AddTaxForMunicipality(municipality);
                    if (string.IsNullOrEmpty(result)) return Content("Failed To Insert");

                    return Ok("Inserted Successfully");
                }
                else
                {
                    return Content("Failed To Insert");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Some Error Occured");
            }
        }
    }
}
