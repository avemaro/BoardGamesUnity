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

            var canMoveLeftForward = new List<Cell>() { Cell.c6, Cell.e6, Cell.g6 };
            foreach (var piece in board.Pieces) {
                if (piece.Color != PieceColor.black) continue;
                var position = piece.Position;
                var leftForward = position.Next(Direction.left, Direction.up);
                if (leftForward == null) continue;
                if (canMoveLeftForward.Contains(position)) {
                    Assert.True(board.MovePiece(position, (Cell)leftForward));
                    Assert.AreEqual(leftForward, piece.Position);
                } else {
                    Assert.False(board.MovePiece(position, (Cell)leftForward));
                    Assert.AreEqual(position, piece.Position);
                }
            }

            var canMoveRightForward = new List<Cell>() { Cell.a6, Cell.c6, Cell.e6, Cell.g6 };
            foreach (var piece in board.Pieces) {
                if (piece.Color != PieceColor.black) continue;
                var position = piece.Position;
                var rightForward = position.Next(Direction.right, Direction.up);
                if (rightForward == null) continue;
                if (canMoveRightForward.Contains(position)) {
                    Assert.True(board.MovePiece(position, (Cell)rightForward));
                    Assert.AreEqual(rightForward, piece.Position);
                } else {
                    Assert.False(board.MovePiece(position, (Cell)rightForward));
                    Assert.AreEqual(position, piece.Position);
                }
            }
        }

    }
}
