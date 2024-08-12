using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.AreaApp;
using BBSSystem.Contract.AreaApp.Dto;
using BBSSystem.Contract.SectionApp.Dto;
using BBSSystem.Domain.Managers;
using BBSSystem.Domain.PostInfo;
using Volo.Abp.Application.Services;

namespace BBSSystem.Application.AreaApp
{
    public class AreaService : ApplicationService, IAreaService
    {
        public AreaManager AreaMgr { get; set; }
        public SectionManager SectionMgr { get; set; }

        public async Task<List<AreaDto>> GetAreaDtoAsync(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            var take = pageSize;
            var areas = await AreaMgr.GetAreasAsync(skip, take);

            var areaDtos = ObjectMapper.Map<List<Area>, List<AreaDto>>(areas);
            var sections = await SectionMgr.GetSectionsAsync(areaDtos.Select(m => m.Id).ToList());

            var sectionDtos = ObjectMapper.Map<List<Section>, List<SectionDto>>(sections);

            areaDtos.ForEach(m =>
            {
                m.Sections = sectionDtos.FindAll(n => n.AreaId == m.Id);
            });

            return areaDtos;
        }
    }
}