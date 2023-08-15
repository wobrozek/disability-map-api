using disability_map.DataAnnotations;
using disability_map.Dtos;
using disability_map.Models;
using System.ComponentModel.DataAnnotations;

namespace Testy
{
    public class FutureAnnotationTests
    {
        [Fact]    
        public void correctDate_passValidation()
        {
            //arrange
            long newtime = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds();
            var validator = new FutureAnnotation();

            //act
            bool result = validator.IsValid(newtime);

            //assertions
            Assert.True(result);
        }


        [Theory]
        [InlineData(1597507045)]
        [InlineData(335203045)]
        public void pastDate_returnFalse(long unixTimestamp)
        {
            //arrange
            var validator = new FutureAnnotation();

            //act
            var result = validator.IsValid(unixTimestamp);

            //assertions
            Assert.False(result);
        }


        [Fact]
        public void currentDate_returnFalse()
        {
            //arrange
            var validator = new FutureAnnotation();
            long newtime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            //act
            var result = validator.IsValid(newtime);

            //assertions
            Assert.False(result);
        }
    }
}
