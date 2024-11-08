using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MyMin_Should
    {
        [Fact]
        public void Return_Element_with_min_Value()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            var expected = -4;
            var actual = intList.MyMin();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
