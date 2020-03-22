﻿using System.Collections;
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
        }

        [Test]
        public void Test5PiecesHasReversed() {
            var board = new Board();
            var blackCells = new Cell[] { Cell.b6, Cell.c5, Cell.d3, Cell.d4, Cell.e4 };
            var whiteCells = new Cell[] { Cell.d5, Cell.e5 };
            Assert.False(board.Check(blackCells, whiteCells));
            board.PutPiece(Cell.d3, Cell.c5, Cell.b6);
            board.PrintBoard();
            Assert.True(board.Check(blackCells, whiteCells));

            board.PutPiece(Cell.d2);
            blackCells = new Cell[] { Cell.b6, Cell.c5, Cell.e4 };
            whiteCells = new Cell[] { Cell.d5, Cell.d4, Cell.d3, Cell.d2, Cell.e5 };
            Assert.True(board.Check(blackCells, whiteCells));
        }

        [Test]
        public void Test6PiecePinchOtherPieces() {
            var board = new Board();
            Assert.False(board.PutPiece(Cell.e3));
            Assert.True(board.PutPiece(Cell.d3));
        }

        [Test]
        public void Test7PassTurn() {
            var board = new Board();
            board.PutPiece(Cell.f5, Cell.f6, Cell.d3, Cell.g5,
                           Cell.h5, Cell.h4, Cell.f7, Cell.h6);
            var blackCells = new Cell[] { Cell.d3, Cell.d4, Cell.d5, Cell.e4, Cell.e5, Cell.f5, Cell.f6, Cell.f7 };
            var whiteCells = new Cell[] { Cell.g5, Cell.h4, Cell.h5, Cell.h6 };
            board.PrintBoard();
            Assert.True(board.Check(blackCells, whiteCells));
            Assert.AreEqual(PieceColor.white, board.ColorInTurn);
        }
    }
}
