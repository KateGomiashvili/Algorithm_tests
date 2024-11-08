using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MyReverse_with_Predicate_Should
    {
        [Fact]
        public void Reverse_Elements_with_Condition()
        {
            //Arrange
            List<int> intList = new() { 1,2,3,4,5,6,7,8,9,10 };

            //Act
            List<int> expected = new() { 10,8,6,4,2};
            var actual = intList.MyReverse(x=>x%2==0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
