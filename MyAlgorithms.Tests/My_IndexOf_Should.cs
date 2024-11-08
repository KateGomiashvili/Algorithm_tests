using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class My_IndexOf_Should
    {
        [Fact]
        public void Find_First_Index_Of_Element_With_Condition()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            var expected = 1;
            var actual = intList.MyIndexOf(x => x > 0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }

}
