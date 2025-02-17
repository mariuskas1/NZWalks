using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<RegionDTO>>(regionsDomain);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {                                               
                return NotFound();
            }

            var regionDTO = mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionDTO);
        }


        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
                var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);
                return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);

        }


        [HttpPut]
        [Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);
                return Ok(regionDTO);
        }

        [HttpDelete]
        [Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null) 
            {
                return NotFound();
            }

            return Ok();
        }

    }
};
