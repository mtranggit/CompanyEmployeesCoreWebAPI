using AutoMapper;
using CompanyEmployees.ModelBinders;
using CompanyEmployeesCoreWebAPI.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployeesCoreWebAPI.Controllers
{
    [ApiVersion("2.0")]
    //[ApiVersion("2.0", Deprecated = true)]
    [Route("api/companies")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompaniesV2Controller(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _repository.Company.GetAllCompaniesAsync(trackChanges: false);
                //var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

                //throw new Exception("Exception");

                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCompanies)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

    }


}
