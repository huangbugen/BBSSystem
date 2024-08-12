using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Application.Contract.SectionApp.Dto;
using BBSSystem.Contract.SectionApp;
using Microsoft.AspNetCore.Mvc;

namespace BBSSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<SectionSimpleDto> GetSectionSimpleDtoAsync(string sectionId)
        {
            return await _sectionService.GetSectionSimpleDtoAsync(sectionId);
        }
    }
}