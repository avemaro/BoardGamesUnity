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
    }
}
