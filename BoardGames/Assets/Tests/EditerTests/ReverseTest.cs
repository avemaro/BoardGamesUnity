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
        public void Test1_BoardHasInitialized() {
            var board = new Board((PieceColor.black, Cell.d5),
                                  (PieceColor.black, Cell.e4),
                                  (PieceColor.white, Cell.d4),
                                  (PieceColor.white, Cell.e5));
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.d5));
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.e4));
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.d4));
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.e5));
        }

        [Test]
        public void Test2_PutPieceAlternately() {
            var board = new Board();
            Assert.AreEqual(PieceColor.black, board.ColorInTurn);
            board.PutPiece(Cell.d3);
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.d3));
            Assert.AreEqual(PieceColor.white, board.ColorInTurn);
            board.PutPiece(Cell.c5);
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.c5));
            Assert.AreEqual(PieceColor.black, board.ColorInTurn);
        }

        [Test]
        public void Test3_PutPieceOnVacantCell() {
            var board = new Board();
            Assert.False(board.PutPiece(Cell.d4));
            Assert.True(board.PutPiece(Cell.d3));
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.d3));
            Assert.False(board.PutPiece(Cell.e4));
            Assert.True(board.PutPiece(Cell.c5));
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.c5));
        }

        [Test]
        public void Test4_APieceHasReveresed() {
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
