using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Api.CustomActionFilter;
using NZwalks.Api.Data;
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Models.DTO;
using NZwalks.Api.Repostries;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            _mapper = mapper;
          _walkRepository = walkRepository;
        }



        [HttpPost]
        [ValditeModelAttrubite]
        public async Task<IActionResult> CreateAsync(AddWalkRequestDTO addWalkRequestDTO) 
        {
            //map dto to domain model
            var walkdomainmodel = _mapper.Map<Walk>(addWalkRequestDTO);
            await _walkRepository.CreateAsync(walkdomainmodel);

            //map domain model to dto
            return Ok(_mapper.Map<WalkDTO>(walkdomainmodel));

        
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? FilterOn, [FromQuery] string? FilterQuery
            , string? sortBy, bool isAscending,int PageNumber = 1 , int PageSize = 1000) 
        {
            var WalkDomainModel = await _walkRepository.GetAllAsync(FilterOn,FilterQuery,sortBy,isAscending , PageNumber , PageSize );
            return Ok(_mapper.Map<List<WalkDTO>>(WalkDomainModel));
       }
        [HttpGet]
        [Route("{ID:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid ID)
        { 
        var DomainModel = await _walkRepository.GetByIdAsync(ID);
            if (DomainModel is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDTO>(DomainModel));

        }
        [HttpPut]
        [Route("{ID:guid}")]
        [ValditeModelAttrubite]
        public async Task<IActionResult> UpdateWalkAsync(Guid ID , UpdateWalkRequsetDTO updateWalkRequsetDTO) 
        {
            var WalkDomainModel = _mapper.Map<Walk>(updateWalkRequsetDTO);
            WalkDomainModel = await _walkRepository.UpdateWalkAsync(ID,WalkDomainModel);

            if (WalkDomainModel is null) 
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDTO>(WalkDomainModel));
        }

        [HttpDelete]
        [Route("{ID:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid ID)
        { 
            var Model = await _walkRepository.DeleteWalkAsync(ID);
            if (Model is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDTO>(Model));
            
        }
    }

}





















