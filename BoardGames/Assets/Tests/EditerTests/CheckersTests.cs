using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CheckersTests
    {
        [Test]
        public void Test1_BoardHasInitialized()
        {
            var board = new CheckersBoard();
            var blackCells = new Cell[] {Cell.a6, Cell.a8, Cell.b7,
                                         Cell.c6, Cell.c8, Cell.d7,
                                         Cell.e6, Cell.e8, Cell.f7,
                                         Cell.g6, Cell.g8, Cell.h7};
            var whiteCells = new Cell[] {Cell.a2, Cell.b1, Cell.b3,
                                         Cell.c2, Cell.d1, Cell.d3,
                                         Cell.e2, Cell.f1, Cell.f3,
                                         Cell.g2, Cell.h1, Cell.h3};
            Assert.True(board.Check(blackCells, whiteCells));
        }

        [Test]
        public void Test2_PiecesMoveDiagonallyForward() {
            var board = new CheckersBoard();

            //b7はどこにも行けない
            foreach (var direction in DirectionExtend.AllCases) {
                var nextCell = (Cell)Cell.b7.Next(direction);
                Assert.False(board.MovePiece(Cell.b7, nextCell));
                Assert.NotNull(board.GetPiece(Cell.b7));
            }
            //a6はc4には行けない、b5に行ける
            Assert.False(board.MovePiece(Cell.a6, Cell.c4));
            Assert.NotNull(board.GetPiece(Cell.a6));
            Assert.True(board.MovePiece(Cell.a6, Cell.b5));
            Assert.Null(board.GetPiece(Cell.a6));
            Assert.NotNull(board.GetPiece(Cell.b5));
            //e2はどこにも行けない
            foreach (var direction in DirectionExtend.AllCases) {
                var nextCell = (Cell)Cell.e2.Next(direction);
                Assert.False(board.MovePiece(Cell.e2, nextCell));
                Assert.NotNull(board.GetPiece(Cell.e2));
            }
            //d3はb5には行けない、c4に行ける
            Assert.False(board.MovePiece(Cell.d3, Cell.b5));
            Assert.NotNull(board.GetPiece(Cell.d3));
            Assert.True(board.MovePiece(Cell.d3, Cell.c4));
            Assert.Null(board.GetPiece(Cell.d3));
            Assert.NotNull(board.GetPiece(Cell.c4));
        }

        [Test]
        public void Test3_MovePieceAlternately() {
            var board = new CheckersBoard();

            Assert.AreEqual(PieceColor.black, board.ColorInTurn);
            board.MovePiece(Cell.a6, Cell.b5);
            Assert.AreEqual(PieceColor.white, board.ColorInTurn);
            board.MovePiece(Cell.d3, Cell.c4);
            Assert.AreEqual(PieceColor.black, board.ColorInTurn);
        }

        [Test]
        public void Test4_PieceCapture() {
            var board = new CheckersBoard();

            Assert.True(board.MovePiece(Cell.a6, Cell.b5));
            Assert.True(board.MovePiece(Cell.d3, Cell.c4));

            Assert.False(board.MovePiece(Cell.e6, Cell.g5));
            Assert.NotNull(board.GetPiece(Cell.e6));
            Assert.Null(board.GetPiece(Cell.g5));

            Assert.True(board.MovePiece(Cell.b5, Cell.d3));
            Assert.NotNull(board.GetPiece(Cell.d3));
            Assert.Null(board.GetPiece(Cell.b5));
        }
    }
}