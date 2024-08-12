using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.AreaApp.Dto;
using Volo.Abp.Application.Services;

namespace BBSSystem.Contract.AreaApp
{
    public interface IAreaService : IApplicationService
    {
        Task<List<AreaDto>> GetAreaDtoAsync(int pageIndex, int pageSize);
    }
}