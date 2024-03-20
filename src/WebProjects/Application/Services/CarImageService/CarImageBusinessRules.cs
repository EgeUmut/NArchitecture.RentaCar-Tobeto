using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarImageService;

public class CarImageBusinessRules:BaseBusinessRules
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly ICarRepository _carRepository;

    public CarImageBusinessRules(ICarImageRepository carImageRepository, ICarRepository carRepository)
    {
        _carImageRepository = carImageRepository;
        _carRepository = carRepository;
    }

    public async Task<List<CarImage>> CheckIFCarImageNull(int carId)
    {
        try
        {
            string path = @"\Images\default.jpg";
            var result = _carImageRepository.GetAllAsync(p=>p.CarId == carId);
            if (result != null)
            {
                List<CarImage> carImages = new();
                carImages.Add(new CarImage { CarId = carId,ImagePath= path });
            }
        }
        catch (Exception e)
        {

            throw e;
        }

        return await _carImageRepository.GetAllAsync(p=>p.CarId ==carId);
    }

    public Task CheckIfImageLimit(int carId)
    {
        var carImageCount = _carImageRepository.GetAllAsync(p=>p.CarId==carId).Result.Count();
        if (carImageCount >= 5)
        {
            throw new BusinessException("You exceeded the Image Limit! Current Limit: 5");
        }
        return Task.CompletedTask;
    }

    public Task CheckIfCarImageFormat(IFormFile file)
    {
        string fileExtension = Path.GetExtension(file.FileName).ToLower();
        if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
        {
            throw new BusinessException("You can only add files with .jpg , .png and .jpeg extensions");
        }
        return Task.CompletedTask;
    }

    public async Task CarImageIdSouldExist(int id)
    {
        CarImage? result = await _carImageRepository.GetAsync(p => p.Id == id);
        if (result == null)
        {
            throw new BusinessException("Image does not exist!");
        }
        return;
    }

    public async Task CarImageCarIdShouldExist(int CarId)
    {
        Car? result = await _carRepository.GetAsync(p=>p.Id == CarId);
        if (result == null)
        {
            throw new BusinessException("Car does not exist");
        }
        return;
    }
}
