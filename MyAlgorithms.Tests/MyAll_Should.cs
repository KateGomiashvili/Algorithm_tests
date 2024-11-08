using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MyAll_Should
    {
        [Fact]
        public void Return_True_If_Condition_is_true_for_all_Elements()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            var expected = false;
            var actual = intList.MyAll(x=>x>0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
