using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class OrderBy_Should
    {
        [Fact]
        public void Order_Elements()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            List<int> expected = new() { -4, -1, 2, 3 };
            var actual = intList.MyOrderBy((x,y)=> x<y);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
