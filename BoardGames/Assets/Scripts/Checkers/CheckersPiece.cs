using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersPiece : Piece {
    List<Direction> MoveDirections {
        get {
            if (Color == PieceColor.black)
                return new List<Direction> { Direction.upLeft, Direction.upRight };
            return new List<Direction> { Direction.downLeft, Direction.downRight };
        }
    }

    public CheckersPiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }

    public override void Work() {
        throw new System.NotImplementedException();
    }

    public override bool IsRegal(Cell to) {
        if (board.GetPiece(to) != null) return false;
        foreach (var direction in MoveDirections)
            if (to == Position.Next(direction)) return true;

        foreach (var direction in MoveDirections) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) continue;
            var next2Cell = nextPiece.Position.Next(direction);
            if (to != next2Cell) continue;
            return true;
        }

        return false;
    }
}