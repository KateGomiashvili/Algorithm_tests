using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MyReverse_Should
    {
        [Fact]
        public void Reverse_Argument()
        {
            //Arrange
            List<int> intList = new() { 1,2,3,4,5 };

            //Act
            List<int> expected = new() { 5,4,3,2,1};
            var actual = intList.MyReverse();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
