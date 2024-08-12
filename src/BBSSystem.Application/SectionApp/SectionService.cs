using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Application.Contract.SectionApp.Dto;
using BBSSystem.Contract.SectionApp;
using BBSSystem.Domain.Managers;
using BBSSystem.Domain.PostInfo;
using Volo.Abp.Application.Services;

namespace BBSSystem.Application.SectionApp
{
    public class SectionService : ApplicationService, ISectionService
    {
        private readonly SectionManager _sectionManager;
        public SectionService(SectionManager sectionManager)
        {
            this._sectionManager = sectionManager;
        }
        public async Task<SectionSimpleDto> GetSectionSimpleDtoAsync(string sectionId)
        {
            var res = await _sectionManager.GetSimpleSectionsAsync(sectionId);
            var section = res.section;
            var lords = res.lords;
            var dto = ObjectMapper.Map<Section, SectionSimpleDto>(section);
            dto.SectionLords = lords;
            return dto;
        }
    }
}