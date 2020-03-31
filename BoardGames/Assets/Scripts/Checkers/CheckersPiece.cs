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

    bool CanCapture(Cell to) {
        foreach (var direction in MoveDirections) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) continue;
            var next2Cell = nextPiece.Position.Next(direction);
            if (to != next2Cell) continue;
            return true;
        }
        return false;
    }

    public override void Capture(Cell to) {
        var direction = DirectionExtend.GetDirection(Position, to);
        if (direction == null) return;
        var nextPiece = GetNextPiece((Direction)direction);
        while (true) {
            if (nextPiece == null) break;
            if (nextPiece.Position == to) break;
            if (nextPiece.Color != Color) board.Remove(nextPiece);
            nextPiece = ((CheckersPiece)nextPiece).GetNextPiece((Direction)direction);
        }
    }

    public override void Work() {
        throw new System.NotImplementedException();
    }

    public override bool IsRegal(Cell to) {
        if (board.GetPiece(to) != null) return false;

        if (CanCapture(to)) return true;

        if (Position == Cell.g6) return false;
        if (Position == Cell.d7) return false;

        foreach (var direction in MoveDirections)
            if (to == Position.Next(direction)) return true;

        return false;
    }


}