using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GomokuTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Test1_a1HasNoCellOnUpOrLeft() {
            var a1 = Cell.a1;
            Assert.IsNull(a1.Next(Direction.up));
            Assert.IsNull(a1.Next(Direction.upRight));
            Assert.IsNotNull(a1.Next(Direction.right));
            Assert.IsNotNull(a1.Next(Direction.downRight));
            Assert.IsNotNull(a1.Next(Direction.down));
            Assert.IsNull(a1.Next(Direction.downLeft));
            Assert.IsNull(a1.Next(Direction.left));
            Assert.IsNull(a1.Next(Direction.upLeft));
        }

        [Test]
        public void Test2_h8HasNoCellOnDownOrRight() {
            var h8 = Cell.h8;
            Assert.IsNotNull(h8.Next(Direction.up));
            Assert.IsNull(h8.Next(Direction.upRight));
            Assert.IsNull(h8.Next(Direction.right));
            Assert.IsNull(h8.Next(Direction.downRight));
            Assert.IsNull(h8.Next(Direction.down));
            Assert.IsNull(h8.Next(Direction.downLeft));
            Assert.IsNotNull(h8.Next(Direction.left));
            Assert.IsNotNull(h8.Next(Direction.upLeft));
        }
    }
}
