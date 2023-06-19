using BreweryAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System;
using System.Collections;

namespace BreweryAPI.Services
{
    public interface IBeerService
    {
        //POST /beer - Insert a single beer
        Task<Beer> InsertBeer(Beer objBeer);

        //PUT /beer/{id} - Update a beer by Id
        Task<Beer> UpdateBeerById(int BeerId, Beer objBeer);

        // GET /beer? gtAlcoholByVolume = 5.0 & ltAlcoholByVolume = 8.0 - Get all beers with optional filtering query parameters for alcohol content(gtAlcoholByVolume = greater than, ltAlcoholByVolume = less than)
        Task<IEnumerable<Beer>> GetBeer(double gtAlcoholByVolume = 5.0, double ltAlcoholByVolume = 8.0);

        // GET /beer/{id} -Get beer by Id
        Task<Beer> GetBeerById(int BeerId);

    }
}
