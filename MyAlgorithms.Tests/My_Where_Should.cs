using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class My_Where_Should
    {
        [Fact]
        public void Find_Specific_Element_In_IEnumerable()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };


            //Act
            List<int> expected = new() { 2, 3 };
            var actual = intList.MyWhere(x => x>0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
