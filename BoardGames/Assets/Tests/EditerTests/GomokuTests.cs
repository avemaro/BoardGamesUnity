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
        public void Test1_a1HasNoCellOnUpAndLeft() {
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
        public void Test2_h8HasNoCellOnUpAndLeft() {
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

        [Test]
        public void Test3_BoardHasInitialized() {
            var board = new Board();
            foreach (var cell in CellExtend.AllCases)
                Assert.AreEqual(PieceColor.none, board.GetColor(cell));
        }

        [Test]
        public void Test4_PutPieceAlternately() {
            var board = new Board();
            Assert.AreEqual(PieceColor.black, board.ColorInTurn);
            board.PutPiece(Cell.d3);
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.d3));
            Assert.AreEqual(PieceColor.white, board.ColorInTurn);
            board.PutPiece(Cell.c5);
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.c5));
            Assert.AreEqual(PieceColor.black, board.ColorInTurn);
        }
    }
}
