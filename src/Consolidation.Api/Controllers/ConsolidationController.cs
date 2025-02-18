using Consolidation.Application.Interfaces;
using Consolidation.Api.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Consolidation.Api.Controllers
{
    [ApiController]
    [Route("api/consolidations")]
    public class ConsolidationController : ControllerBase
    {
        private readonly IConsolidationService _service;
        private readonly IMapper _mapper;

        public ConsolidationController(IConsolidationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsolidationDto>>> GetAll()
        {
            var consolidations = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ConsolidationDto>>(consolidations));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsolidationDto>> GetById(int id)
        {
            var consolidation = await _service.GetByIdAsync(id);
            if (consolidation == null)
                return NotFound();

            return Ok(_mapper.Map<ConsolidationDto>(consolidation));
        }

        [HttpPost]
        public async Task<ActionResult> Create(ConsolidationDto dto)
        {
            var consolidation = _mapper.Map<Domain.Entities.Consolidation>(dto);
            await _service.AddAsync(consolidation);
            return CreatedAtAction(nameof(GetById), new { id = consolidation.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ConsolidationDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var consolidation = _mapper.Map<Domain.Entities.Consolidation>(dto);
            await _service.UpdateAsync(consolidation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
