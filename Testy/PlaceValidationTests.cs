using AutoMapper;
using Azure.Storage.Blobs;
using disability_map;
using disability_map.Controllers;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.PlaceService;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testy
{
    public class PlaceValidationTests
    {
        [Theory]
        [InlineData("66632457343242")]
        [InlineData("666324")]
        [InlineData("66z32w573")]
        public void PlaceWrongPhone_ThrowArgumentExeception(string phone)
        {
            //act
            Action action = () =>
            {
                new Place()
                {
                    Name = "elevator",
                    Adress = "filkowa 11/3",
                    OpeningHours = "11-12",
                    Cords = new Cords() { Latitude = 30, Longitude = 40 },
                    Type = PlaceType.blindPlace,
                    Phone = phone
                };
            };

            //assert
            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [InlineData("+48 666324463")]
        [InlineData("666324463")]
        [InlineData("666 322 573")]
        public void PlaceCorrectPhone_PassValidation(string phone)
        {

            //act
            var place = new Place()
            {
                Name = "elevator",
                Adress = "filkowa 11/3",
                OpeningHours = "11-12",
                Cords = new Cords() { Latitude = 30, Longitude = 40 },
                Type = PlaceType.blindPlace,
                Phone = phone
            };

            ///assert
            Assert.Equal(place.Phone, phone);
        }
    }
}
