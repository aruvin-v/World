using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using World.Data;
using World.DTO.Country;
using World.DTO.State;
using World.Models;
using World.Repository;

namespace World.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateRepository _stateRepository;
        private readonly IMapper _mapper;
        public StateController(StateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }
        //To get all the states that are stored in the Database table
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetAll()
        {
            var states = await _stateRepository.GetAll();
            var statesDTO = _mapper.Map<List<StateDTO>>(states);
            if (statesDTO == null)
            {
                return NoContent();
            }
            return Ok(statesDTO);
        }
        //To get the state by StateId
        [HttpGet("{stateId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StateDTO>> Get(int stateId)
        {
            var stateById = await _stateRepository.Get(stateId);
            if (stateById == null)
            {
                return NoContent();
            }
            var stateDTO = _mapper.Map<StateDTO>(stateById);
            return Ok(stateDTO);
        }
        //To create a new state and add it to the database
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<StateDTO>> Create([FromBody] CreateStateDTO stateDTO)
        {
            var stateById = _stateRepository.IsRecordExists(x => x.Name == stateDTO.Name);
            if (stateById)
            {
                return Conflict("State already exists in the database!");
            }

            var state = _mapper.Map<State>(stateDTO);
            await _stateRepository.Create(state);
            return CreatedAtAction("GetByCountryId", new { Id = state.Id }, state);
        }
        //To update an existing State
        [HttpPut("{stateId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<StateDTO>> Update(int stateId, [FromBody] UpdateStateDTO stateDTO)
        {
            if (stateDTO == null || stateId != stateDTO.Id)
            {
                return BadRequest();
            }
            var stateById = _stateRepository.Get(stateId);
            var state = _mapper.Map<State>(stateById);
            if (state == null)
            {
                return NotFound();
            }
            await _stateRepository.Update(state);
            return NoContent();
        }
        //To delete an existing record using ID
        [HttpDelete("{stateId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<State>> DeleteById(int stateId)
        {
            if (stateId == 0)
            {
                return BadRequest();
            }
            var state = await _stateRepository.Get(stateId);
            if (state == null)
            {
                return NotFound();
            }
            await _stateRepository.Delete(state);
            return NoContent();
        }
    }
}
