using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MySum_with_Predicate_Should
    {
        [Fact]
        public void Sum_Element_with_Condition()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4, 6, 8 };

            //Act
            var expected = -5;
            var actual = intList.MySum(x=>x<0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
