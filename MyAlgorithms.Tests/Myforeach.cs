using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class My_Foreach_Should
    {
        [Fact]
        public void Iterate_On_Entire_Enumerable()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            var expected = intList;
            var actual = intList.MyForeach();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
