using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.Api.CustomActionFilter;
using NZwalks.Api.Data;
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Models.DTO;
using NZwalks.Api.Repostries;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regionDomain = await _regionRepository.GetAllAsync();
            return Ok(_mapper.Map<List<RegionDTO>>(regionDomain));
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if (regionDomain is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDTO>(regionDomain));
        }
        [HttpPost]
        [ValditeModelAttrubite]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            

                //map dto to domain model
                var regionDomainModel = _mapper.Map<Region>(addRegionRequestDTO);
                //use domain model to create new region
                regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);
                //map domain model back to dto
                var regionDto = _mapper.Map<RegionDTO>(regionDomainModel);

                return CreatedAtAction(nameof(GetByID), new { Id = regionDto.Id }, regionDto);
         

        }

        [HttpPut]
        [Route("{ID:guid}")]
        [ValditeModelAttrubite]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> UpdateRegion([FromRoute] Guid ID, UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //map domain model to DTO

       
                var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDTO);

                regionDomainModel = await _regionRepository.UpdateAsync(ID, regionDomainModel);
                if (regionDomainModel is null)
                {
                    return NotFound();
                }


                var regionDto = _mapper.Map<RegionDTO>(updateRegionRequestDTO);
                return Ok(regionDto);
          

        }

        [HttpDelete]
        [Route("{Id:guid}")]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> DeleteRegion([FromRoute] Guid Id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(Id);
            if (regionDomainModel is null)
            {
                return NotFound();
            }
            return Ok();

        }


    }

}














