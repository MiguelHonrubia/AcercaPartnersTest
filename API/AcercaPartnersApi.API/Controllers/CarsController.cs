using Core.DTO.Helpers;
using Core.DTO.Usuarios;
using Core.Helpers;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcercaPartnersApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        /// <summary>
        /// Get All cars
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedList<DtoCar>>> GetAll([FromQuery] DtoFilterPagedList pagedListParams)
        {
            PagedList<DtoCar> listCars = await _carService.GetAllCars(pagedListParams);

            if (listCars == null || !listCars.Any())
            {
                return NotFound();
            }

            return Ok(listCars);
        }

        /// <summary>
        /// Get car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            DtoCar result = await _carService.GetCarId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// New car
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DtoCar>> Create([FromBody] DtoCarCreate car)
        {
            int? result = await _carService.CreateCar(car);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = result.Value }, result);
        }

        /// <summary>
        /// Update car
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoCar>> Update([FromBody] DtoCarUpdate data)
        {
            int? result = await _carService.UpdateCar(data);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _carService.RemoveCar(id);

            return Ok();
        }
    }
}
