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

            var canMoveLeftAndRightForward = new List<Cell>() { Cell.c6, Cell.e6, Cell.g6 };
            var canMoveRightForward = new List<Cell>() { Cell.a6 };


            foreach (var piece in board.Pieces) {
                if (piece.Color != PieceColor.black) continue;
                var position = piece.Position;

                foreach (var direction in DirectionExtend.AllCases) {
                    var to = position.Next(direction);
                    if (to == null) continue;

                    if (canMoveLeftAndRightForward.Contains(position) &&
                        (direction == Direction.upLeft || direction == Direction.upRight)) {
                        Assert.True(board.MovePiece(position, (Cell)to));
                        Assert.AreEqual(to, position);
                    } else if (canMoveRightForward.Contains(position) &&
                               direction == Direction.upRight) {
                        Assert.True(board.MovePiece(position, (Cell)to));
                        Assert.AreEqual(to, piece.Position);
                    } else {
                        Assert.False(board.MovePiece(position, (Cell)to));
                        Assert.AreEqual(position, piece.Position);
                    }

                }
            }
        }
    }
}
