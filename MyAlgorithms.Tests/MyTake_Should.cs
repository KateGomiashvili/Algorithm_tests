using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MyTake_Should
    {
        [Fact]
        public void Return_current_Amount_Of_Values()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            List<int> expected = new() { -1,2};
            var actual = intList.MyTake(2);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
