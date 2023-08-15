using AutoMapper;
using Azure.Storage.Blobs;
using disability_map;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.PlaceService;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Testy
{
    public class PlaceServiceTest : TestWithSqlite
    {
        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }

        [Fact]
        public async Task PostPlace_ReturnsIdAsync()
        {
            //arange 
            

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var blob = new Mock<BlobServiceClient>();

            //act
            var placeService = new PlaceService(mapper, DbContext, blob.Object);

            var placeDto = new PostPlaceDto()
            {
                Name = "elevator",
                Adress = "filkowa 11/3",
                OpeningHours = "11-12",
                LL = new double[] { 30, 40 },
                Type = PlaceType.blindPlace,
                Phone = "253626734"
            };

            ServiceResponse<string> response = await placeService.CreatePlace(placeDto, 1);

            int places = DbContext.Place.Count();

            ////assert
            Assert.Equal(1, places);
            Assert.True(response.Success);
        }
    }
}
