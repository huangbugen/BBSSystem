using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Application.Contract.SectionApp.Dto;
using Volo.Abp.Application.Services;

namespace BBSSystem.Contract.SectionApp
{
    public interface ISectionService : IApplicationService
    {
        Task<SectionSimpleDto> GetSectionSimpleDtoAsync(string sectionId);
    }
}