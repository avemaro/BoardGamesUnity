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

        [Test]
        public void Test3_PiecePinchOtherPieces() {
            ReverseBoard board;
            foreach (var cell in CellExtend.AllCases) {
                board = new ReverseBoard();
                if (cell == Cell.c4 || cell == Cell.d3 || cell == Cell.e6 || cell == Cell.f5)
                    Assert.True(board.PutPiece(cell));
                Assert.False(board.PutPiece(cell));   //Expected: false, But was: true
            }
        }

        [Test]
        public void Test4_APieceHasReveresed() {
            var board = new ReverseBoard();
            Assert.True(board.PutPiece(Cell.d3));
            Assert.True(board.IsBlack(Cell.d3));
            Assert.True(board.IsBlack(Cell.d4));   //Expected: true, But was: false
            Assert.True(board.PutPiece(Cell.c5));
            Assert.True(board.IsWhite(Cell.c5));
            Assert.True(board.IsWhite(Cell.d5));
        }

        [Test]
        public void Test5_PiecesHasReversed() {
            var board = new ReverseBoard();
            var blackCells = new Cell[] { Cell.b6, Cell.c5, Cell.d3, Cell.d4, Cell.e4 };
            var whiteCells = new Cell[] { Cell.d5, Cell.e5 };
            Assert.False(board.Check(blackCells, whiteCells));
            foreach (var cell in new Cell[] { Cell.d3, Cell.c5, Cell.b6 })
                board.PutPiece(cell);
            Assert.True(board.Check(blackCells, whiteCells));

            board.PutPiece(Cell.d2);
            blackCells = new Cell[] { Cell.b6, Cell.c5, Cell.e4 };
            whiteCells = new Cell[] { Cell.d5, Cell.d4, Cell.d3, Cell.d2, Cell.e5 };
            Assert.True(board.Check(blackCells, whiteCells));
        }
    }
}