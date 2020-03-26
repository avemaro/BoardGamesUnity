﻿using System.Collections;
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
                if (cell == Cell.c4 || cell == Cell.d3 ||
                    cell == Cell.e6 || cell == Cell.f5)
                    Assert.True(board.PutPiece(cell));
                Assert.False(board.PutPiece(cell));
            }
        }
    }
}