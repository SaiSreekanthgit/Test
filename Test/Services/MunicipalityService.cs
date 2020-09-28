using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Repository;

namespace Test.Services
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly IMunicipalityRepository _municipalityRepository;

        public MunicipalityService(IMunicipalityRepository municipalityRepository)
        {
            _municipalityRepository = municipalityRepository;
        }

        public async Task<double?> GetTaxByMunicipalityNameAndDate(string name, DateTime fromdate, DateTime todate)
        {
            var result = await _municipalityRepository.GetTaxByMunicipalityNameAndDate(name, fromdate, todate);
            return result;
        }

        public async Task<string> AddTaxForMunicipality(MunicipalityModel municipality)
        {
            var result = await _municipalityRepository.AddTaxForMunicipality(municipality);
            return result;
        }
    }
}
