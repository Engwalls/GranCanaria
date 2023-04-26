using AutoMapper;
using Azure;
using GranCanariaAPI.Data;
using GranCanariaAPI.Models;
using GranCanariaAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GranCanariaAPI.Controllers
{
    [Route("api/GranCanariaAPI")]

    //Går även att göra såhär
    //[Route("api/[controller]")]

    [ApiController]
    public class CanariaApiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CanariaApiController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetApartment()
        {
            IEnumerable<Apartment> apartmentList = await _context.Apartments.ToListAsync();
            return Ok(apartmentList);
        }

        // Get by id
        [HttpGet("{id:int}", Name = "GetApartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApartmentDto>> GetApartment(int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest); // 400
            }

            var apartment = await _context.Apartments.FirstOrDefaultAsync(ap => ap.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound(); // 404
            }

            return Ok(apartment);
        }

        // Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApartmentDto>> CreateApartment([FromBody] ApartmentDto createDto)
        {
            if (await _context.Apartments.FirstOrDefaultAsync(ap => ap.Name.ToLower() == createDto.Name.ToLower()) !=null)
            {
                ModelState.AddModelError("Custom Error", "This apartment already exist");
                return BadRequest(ModelState);
            }
            if (createDto.ApartmentId > 0)
            {
                return BadRequest(createDto);
            }

            Apartment model = _mapper.Map<Apartment>(createDto);
            await _context.Apartments.AddAsync(model);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetApartment", new { id = model.ApartmentId }, model);
        }

        // Delete
        [HttpDelete("{id:int}", Name = "DeleteApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var apartment = await _context.Apartments.FirstOrDefaultAsync(ap => ap.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }
            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Update
        [HttpPut("{id:int}", Name = "UpdateApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateApartment(int id, [FromBody] ApartmentDto updateDto)
        {
            if (updateDto  == null || id != updateDto.ApartmentId)
            {
                return BadRequest();
            }
            //var apartment = _context.Apartments.FirstOrDefault(ap => ap.ApartmentId == id);

            Apartment model = _mapper.Map<Apartment>(updateDto);
            _context.Apartments.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Patch
        [HttpPatch("{id:int}", Name = "UpdatePartialApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialApartment(int id, JsonPatchDocument<ApartmentUpdateDto> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var apartment = await _context.Apartments.AsNoTracking().FirstOrDefaultAsync(ap => ap.ApartmentId == id);
            ApartmentUpdateDto apartmentUpdateDto = _mapper.Map<ApartmentUpdateDto>(apartment);

            if (apartment == null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(apartmentUpdateDto, ModelState);
            Apartment model = _mapper.Map<Apartment>(apartmentUpdateDto);
            _context.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
