using disability_map.DataAnnotations;
using disability_map.Models;


namespace Testy
{
    public class PhoneAnnotationTests
    {
        [Theory]
        [InlineData("66632457343242")]
        [InlineData("666324")]
        [InlineData("66z32w573")]
        public void WrongPhone_returnFalse(string phone)
        {
            //arrange
            var validator = new PhoneAnnotation();

            //act
            bool result = validator.IsValid(phone);

            //assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("48666324463")]
        [InlineData("666324463")]
        [InlineData("666322573")]
        public void CorrectPhone_returnTrue(string phone)
        {
            //arrange
            var validator = new PhoneAnnotation();

            //act
            bool result = validator.IsValid(phone);

            //assert
            Assert.True(result);
        }
    }
}
