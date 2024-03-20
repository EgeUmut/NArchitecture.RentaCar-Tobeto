using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Utilities.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarImageService;

public interface ICarImageService
{
    Task<List<CarImage>> GetList();
    Task<CarImage> GetById(int id);
    Task<CarImage> Add(IFormFile file,CarImage carImage);
    Task<CarImage> Update(IFormFile file,int id);
    Task<CarImage> Delete(int id);
    Task<List<CarImage>> GetImagesByCarId(int carId);
}

public class CarImageManager : ICarImageService
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly CarImageBusinessRules _carImageBusinessRules;
public CarImageManager(ICarImageRepository carImageRepository, CarImageBusinessRules carImageBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _carImageBusinessRules = carImageBusinessRules;
    }

    public async Task<CarImage> Add(IFormFile file, CarImage carImage)
    {
        await _carImageBusinessRules.CarImageCarIdShouldExist(carImage.CarId);
        //await _carImageBusinessRules.CheckIFCarImageNull(carImage.CarId);
        await _carImageBusinessRules.CheckIfCarImageFormat(file);
        await _carImageBusinessRules.CheckIfImageLimit(carImage.CarId);

        carImage.ImagePath = FileHelper.Add(file,"CarImages");
        await _carImageRepository.AddAsync(carImage);
        return carImage;
    }

    public async Task<CarImage> Delete(int id)
    {
        await _carImageBusinessRules.CarImageIdSouldExist(id);

        var image = await _carImageRepository.GetAsync(p => p.Id == id);
        var path = Path.Combine(Directory.GetCurrentDirectory(), image.ImagePath);
        var result = FileHelper.Delete(path);
        await _carImageRepository.DeleteAsync(image);
        return image;
    }

    public async Task<CarImage> GetById(int id)
    {
        await _carImageBusinessRules.CarImageIdSouldExist(id);

        var carImage = await _carImageRepository.GetAsync(p=>p.Id == id);
        return carImage;
    }

    public async Task<List<CarImage>> GetImagesByCarId(int carId)
    {
        await _carImageBusinessRules.CarImageCarIdShouldExist(carId);

        var carImages = await _carImageRepository.GetAllAsync(p => p.CarId == carId);
        return carImages;
    }

    public async Task<List<CarImage>> GetList()
    {
        return await _carImageRepository.GetAllAsync();
    }

    public async Task<CarImage> Update(IFormFile file, int id)
    {
        await _carImageBusinessRules.CarImageIdSouldExist(id);

        var image = await _carImageRepository.GetAsync(p => p.Id == id);

        await _carImageBusinessRules.CheckIfCarImageFormat(file);
        await _carImageBusinessRules.CheckIFCarImageNull(image.CarId);

        
        var path = Path.Combine(Directory.GetCurrentDirectory(), image.ImagePath);
        image.ImagePath = FileHelper.Update(path, file, "CarImages");
        await _carImageRepository.UpdateAsync(image);
        return image;
    }
}