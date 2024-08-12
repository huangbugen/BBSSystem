using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.AreaApp;
using BBSSystem.Contract.AreaApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BBSSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        public IAreaService AreaService { get; set; }

        [HttpGet]
        public async Task<List<AreaDto>> GetAreaDtosAsync(int pageIndex = 1, int pageSize = 30)
        {
            var res = await AreaService.GetAreaDtoAsync(pageIndex, pageSize);
            return res;
        }
    }
}