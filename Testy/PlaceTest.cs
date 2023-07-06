using AutoMapper;
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
    public class PlaceTest
    {
        [Fact]
        public async void Post_Place_Returns_Id()
        {
            //arange 
            var mock = MockDatabase.GetFakeUsers().BuildMock().BuildMockDbSet();
            var contextMock = new Mock<DbMainContext>();
            contextMock.Setup(x => x.User).Returns(mock.Object);

            var context = contextMock.Object;
                
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();

            //act
            //var placeService = new PlaceService(mapper,context);

            //var placeDto = new PostPlaceDto()
            //{
            //    Name="elevator",
            //    Adress="filkowa 11/3",
            //    OpeningHours="11-12",
            //    LL="30,40",
            //    Type=PlaceType.blindPlace
            //};

            //placeService.CreatePlace(placeDto, 1);

            //int places = await context.Place.CountAsync();

            ////assert
            //Assert.Equal(1,places);
        }



    }
}
