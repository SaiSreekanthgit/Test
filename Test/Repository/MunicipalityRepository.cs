using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Repository
{
    public class MunicipalityRepository : IMunicipalityRepository
    {
        protected readonly TestsContext _testsContext;

        public MunicipalityRepository(TestsContext testsContext)
        {
            _testsContext = testsContext;
        }

        public async Task<double?> GetTaxByMunicipalityNameAndDate(string name, DateTime fromdate, DateTime todate)
        {
            if(_testsContext!= null)
            {
                var tax = from m in _testsContext.Municipality
                          join mt in _testsContext.MunicipalityTax on m.MunicipalityId equals mt.MunicipalityId
                          where m.MunicipalityName == name && mt.FromDate == fromdate && mt.ToDate == todate
                          select mt.Tax;
                return tax.FirstOrDefault();
            }
            else
            {
                return null;
            }
            
        }

        public async Task<string> AddTaxForMunicipality(MunicipalityModel municipality)
        {
            if (_testsContext != null)
            {
                Municipality municipalityobj = new Municipality();
                municipalityobj.MunicipalityName = municipality.MunicipalityName;

                 municipalityobj.MunicipalityTax.Add(new MunicipalityTax()
                {
                    FromDate = municipality.FromDate,
                    ToDate = municipality.ToDate,
                    Tax = municipality.Tax
                });

                await _testsContext.AddAsync(municipalityobj);
                await _testsContext.SaveChangesAsync();

                return "Success";
            }
            else
            {
                return null;
            }
        }
    }
}
