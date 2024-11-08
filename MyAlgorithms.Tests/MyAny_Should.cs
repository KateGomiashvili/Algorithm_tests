using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MyAny_Should
    {
        [Fact]
        public void Return_True_If_Condition_is_True_for_Some_Elements()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            var expected = true;
            var actual = intList.MyAny(x=>x>0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
