using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ReverseTests {
        [Test]
        public void Test1_BoardHasInitialized() {
            var board = new ReverseBoard();
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.d5));
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.e4));
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.d4));
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.e5));
        }

        [Test]
        public void Test2_PutPieceAlternately() {
            var board = new ReverseBoard();
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