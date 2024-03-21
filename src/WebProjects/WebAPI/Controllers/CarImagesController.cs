using Application.Features.CarImages.Commands.Create;
using Application.Services.CarImageService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : BaseController
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carImageService.GetList();
            return Ok(result);
        }

        [HttpGet("GetByCarId")]
        public async Task<IActionResult> GetByCarId(int carId)
        {
            var result = await _carImageService.GetImagesByCarId(carId);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(IFormFile file, [FromForm] int CarId)
        {
            CarImage carImage = new();
            carImage.CarId = CarId;
            var result = await _carImageService.Add(file, carImage);
            return Ok(result);
        }

        [HttpPost("AddCommand")]
        public async Task<IActionResult> Add([FromForm] CreateCarImageCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _carImageService.Delete(id);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(IFormFile file, int id)
        {
            var result = await _carImageService.Update(file, id);
            return Ok(result);
        }
    }
}
