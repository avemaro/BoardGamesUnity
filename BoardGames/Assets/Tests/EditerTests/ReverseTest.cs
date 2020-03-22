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
        public void Test1BoardHasInitialized() {
            var board = new Board();
            Assert.AreEqual(board.GetColor(cell: Cell.d5), PieceColor.black);
            Assert.AreEqual(board.GetColor(cell: Cell.e4), PieceColor.black);
            Assert.AreEqual(board.GetColor(cell: Cell.d4), PieceColor.white);
            Assert.AreEqual(board.GetColor(cell: Cell.e5), PieceColor.white);
        }

        [Test]
        public void Test2PutPieceAlternately()
        {
            var board = new Board();
            Assert.AreEqual(board.ColorInTurn, PieceColor.black);
            board.PutPiece(Cell.d3);
            Assert.AreEqual(board.ColorInTurn, PieceColor.white);
            board.PutPiece(Cell.c5);
            Assert.AreEqual(board.ColorInTurn, PieceColor.black);
        }

        [Test]
        public void Test3PutPieceOnVacantCell() {
            var board = new Board();
            Assert.False(board.PutPiece(Cell.d4));
            Assert.True(board.PutPiece(Cell.d3));
            Assert.AreEqual(board.GetColor(Cell.d3), PieceColor.black);
            Assert.False(board.PutPiece(Cell.e4));
            Assert.True(board.PutPiece(Cell.c5));
            Assert.AreEqual(board.GetColor(Cell.c5), PieceColor.white);
        }

        [Test]
        public void Test4APieceHasReveresed() {
            var board = new Board();
            Assert.True(board.PutPiece(Cell.d3));
            Assert.True(board.IsBlack(Cell.d3));
            Assert.True(board.IsBlack(Cell.d4));
            Assert.True(board.PutPiece(Cell.c5));
            Assert.True(board.IsWhite(Cell.c5));
            Assert.True(board.IsWhite(Cell.d5));
            Assert.True(board.PutPiece(Cell.b6));
            Assert.True(board.IsBlack(Cell.b6));
            Assert.True(board.IsBlack(Cell.c5));
        }
    }
}
