using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MySelect_Should
    {
        [Fact]
        public void Use_Function_On_Elements_From_Source()
        {
            //Arrange
            List<int> intList = new() { 1, 10, 10, 2 };

            //Act
            List<int> expected = new() { 2, 20, 20, 4 };
            var actual = intList.MySelect(x=>x*2);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
