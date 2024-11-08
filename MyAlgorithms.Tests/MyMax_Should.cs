﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithms.Tests
{
    public class MyMax_Should
    {
        [Fact]
        public void Return_Element_with_max_Value()
        {
            //Arrange
            List<int> intList = new() { -1, 2, 3, -4 };

            //Act
            var expected = 3;
            var actual = intList.MyMax();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
