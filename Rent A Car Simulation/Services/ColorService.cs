﻿  
using Rent_A_Car_Simulation.DTOs;
using Rent_A_Car_Simulation.Models;
using Rent_A_Car_Simulation.Repository_Interfaces;
using Rent_A_Car_Simulation.Service_Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ColorService : IColorService
{
    private readonly IColorRepository _colorRepository;

    public ColorService(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public async Task<List<ColorDto>> GetAllColorsAsync()
    {
        // Renkleri DTO formatına dönüştür
        var colors = await _colorRepository.GetAllColorsAsync();
        return colors.Select(color => new ColorDto
        {
            Id = color.Id,
            Name = color.Name
        }).ToList();
    }

    public async Task<ColorDto?> GetColorByIdAsync(int id)
    {
        var color = await _colorRepository.GetColorByIdAsync(id);
        if (color == null) return null;

        return new ColorDto
        {
            Id = color.Id,
            Name = color.Name
        };
    }

    public async Task AddColorAsync(ColorDto colorDto)
    {
        var color = new Color
        {
            Name = colorDto.Name
        };
        await _colorRepository.AddAsync(color);
    }

    public async Task UpdateColorAsync(ColorDto colorDto)
    {
        var color = await _colorRepository.GetColorByIdAsync(colorDto.Id);
        if (color != null)
        {
            color.Name = colorDto.Name;
            await _colorRepository.UpdateAsync(color);
        }
    }

    public async Task DeleteColorAsync(int id)
    {
        await _colorRepository.DeleteAsync(id);
    }
}
