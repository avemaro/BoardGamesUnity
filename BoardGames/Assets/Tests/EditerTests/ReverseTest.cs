using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ReverseTest
    {
        [Test]
        public void TestBoardHasInitialized() {
            var board = new Board();
            Assert.AreEqual(board.GetColor(cell: Cell.d5), PieceColor.black);
            Assert.AreEqual(board.GetColor(cell: Cell.e4), PieceColor.black);
            Assert.AreEqual(board.GetColor(cell: Cell.d4), PieceColor.white);
            Assert.AreEqual(board.GetColor(cell: Cell.e5), PieceColor.white);
        }
    }
}
