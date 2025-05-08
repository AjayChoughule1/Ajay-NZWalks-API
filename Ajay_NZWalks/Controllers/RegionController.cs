using Ajay_NZWalks.Data;
using Ajay_NZWalks.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ajay_NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        public RegionController(NZWalksDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllRegions()
        {
            var regionDomain = await _context.Regions.ToListAsync();
            var regionsDomain = new List<RegionDto>();
            foreach (var region in regionDomain) {
                regionsDomain.Add(new RegionDto
                {
                    //Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }
            return Ok(regionsDomain);
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var result = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomain = new RegionDto()
            {
                Code = result.Code,
                Name = result.Name,
                RegionImageUrl = result.RegionImageUrl,
            };
            
            return Ok(regionDomain);
        }
    }
}
