using System;
using System.Collections.Generic;
using System.Text;
using Test.Controllers;
using Test.Services;
using NSubstitute;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using System.Threading.Tasks;

namespace Test.Test
{
    
   public class MunicipalityControllerTest
    {

        private readonly IMunicipalityService municipalityService;
            
            public MunicipalityControllerTest()
            {
               
            }
            [Test]
            public async Task Get_WhenCalled_ReturnsOkResult()
            {
                //Arrange
                double tax = 3.0;

                // Act
                var sub = Substitute.For<IMunicipalityService>();
                var data = await sub.GetTaxByMunicipalityNameAndDate("zxcv",new DateTime(2016-03-03),new DateTime(2016-04-03));
                
                // Assert
                Assert.Equals(tax,data.Value);
            }

        [Test]
        public async Task Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            MunicipalityModel testItem = new MunicipalityModel()
            {
                MunicipalityName = "zxcv",
                FromDate = new DateTime(2016 - 03 - 03),
                ToDate = new DateTime(2016 - 04 - 03),
                Tax = 3.0
            };
            // Act
            var sub = Substitute.For<IMunicipalityService>();
            var Response = await sub.AddTaxForMunicipality(testItem);
            // Assert
            Assert.Equals("Success",Response);
        }

        [Test]
        public async Task Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var missingItem = new MunicipalityModel()
            {
                MunicipalityName ="zxcv",
                FromDate = new DateTime(2016 - 03 - 03),
                ToDate = new DateTime(2016 - 03 - 03)
            };

            // Act
            var sub = Substitute.For<IMunicipalityService>();
            var badResponse = await sub.AddTaxForMunicipality(missingItem);
            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(badResponse);
        }
        
    }
    
}
