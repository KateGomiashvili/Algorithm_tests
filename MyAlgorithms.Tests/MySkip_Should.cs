using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MySkip_Should
    {
        [Fact]
        public void Skip_Current_amount_of_Values()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            List<int> expected = new() {3,-4};
            var actual = intList.MySkip(2);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
