using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using World.Data;
using World.DTO.Country;
using World.Models;
using World.Repository;

namespace World.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(CountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        //To get all the countries that are stored in the Database table
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAll()
        {
            var countries = await _countryRepository.GetAll();
            var countriesDTO = _mapper.Map<List<CountryDTO>>(countries);
            if (countriesDTO == null)
            {
                return NoContent();
            }
            return Ok(countriesDTO);
        }
        //To get the country by CountryId
        [HttpGet("{countryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryDTO>> GetByCountryID(int countryId)
        {
            var countryById = await _countryRepository.Get(countryId);
            if (countryById == null)
            {
                return NoContent();
            }
            var countryDTO = _mapper.Map<CountryDTO>(countryById);
            return Ok(countryDTO);
        }
        //To create a new country and add it to the database
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CountryDTO>> Create([FromBody]CreateCountryDTO countryDTO)
        {
            var countryById = _countryRepository.IsRecordExists(x=>x.CountryName == countryDTO.CountryName);
            if (countryById)
            {
                return Conflict("Country already exists in the database!");
            } 

            var country = _mapper.Map<Country>(countryDTO);
            await _countryRepository.Create(country);
            return CreatedAtAction("GetByCountryId", new {countryId = country.CountryId}, country);
        }
        //To update an existing Country
        [HttpPut("{countryId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<CountryDTO>> Update( int countryId, [FromBody] UpdateCountryDTO countryDTO)
        {
            if(countryDTO == null || countryId != countryDTO.CountryId)
            {
                return BadRequest();
            }
            var countryById = _countryRepository.Get(countryId);
            var country = _mapper.Map<Country>(countryById);
            if(country == null)
            {
                return NotFound();
            }
            await _countryRepository.Update(country);
            return NoContent();
        }
        //To delete an existing record using CountryID
        [HttpDelete("{countryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Country>> DeleteById(int countryId)
        {
            if(countryId == 0)
            {
                return BadRequest();
            }
            var country = await _countryRepository.Get(countryId);
            if(country == null)
            {
                return NotFound();
            }
            await _countryRepository.Delete(country);
            return NoContent();
        }


    }
}
