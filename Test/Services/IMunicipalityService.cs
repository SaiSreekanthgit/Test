using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    public interface IMunicipalityService
    {
        Task<double?> GetTaxByMunicipalityNameAndDate(string name, DateTime fromdate, DateTime todate);

        Task<string> AddTaxForMunicipality(MunicipalityModel municipality);
    }
}
