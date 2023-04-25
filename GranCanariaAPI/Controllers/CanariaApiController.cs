using Azure;
using GranCanariaAPI.Data;
using GranCanariaAPI.Models;
using GranCanariaAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GranCanariaAPI.Controllers
{
    [Route("api/GranCanariaAPI")]

    //Går även att göra såhär
    //[Route("api/[controller]")]

    [ApiController]
    public class CanariaApiController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ApartmentDto>> GetApartment()
        {
            return Ok(ApartmentStore.apartmentList);
        }

        [HttpGet("{id:int}", Name = "GetApartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ApartmentDto> GetApartment(int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest); // 400
            }

            var apartment = ApartmentStore.apartmentList.FirstOrDefault(ap => ap.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound(); // 404
            }

            return Ok(apartment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApartmentDto> CreateApartment([FromBody] ApartmentDto apartmentDto)
        {
            if (apartmentDto == null)
            {
                return BadRequest(apartmentDto);
            }
            if (apartmentDto.ApartmentId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            apartmentDto.ApartmentId = ApartmentStore.apartmentList.OrderByDescending(ap => ap.ApartmentId).FirstOrDefault().ApartmentId + 1;
            ApartmentStore.apartmentList.Add(apartmentDto);
            return CreatedAtRoute("GetApartment", new { id = apartmentDto.ApartmentId }, apartmentDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteApartment(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var apartment = ApartmentStore.apartmentList.FirstOrDefault(ap => ap.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }
            ApartmentStore.apartmentList.Remove(apartment);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateApartment(int id, [FromBody] ApartmentDto apartmentDTO)
        {
            if (apartmentDTO == null || id != apartmentDTO.ApartmentId)
            {
                return BadRequest();
            }
            var apartment = ApartmentStore.apartmentList.FirstOrDefault(ap=>ap.ApartmentId == id);
            apartment.Name = apartmentDTO.Name;
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialApartment(int id, JsonPatchDocument<ApartmentDto> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var apartment = ApartmentStore.apartmentList.FirstOrDefault(ap => ap.ApartmentId == id);
            if (apartment == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(apartment, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
