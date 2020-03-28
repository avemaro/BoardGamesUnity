using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    protected Board board;
    public PieceColor Color { get; protected set; }
    public Cell Position { get; protected set; }
    public bool IsGameOver { get; protected set; }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public virtual void Work() {
        foreach (var direction in DirectionExtend.AllCases) {
            var countInRow = 1;
            countInRow += CountSameColorInDirection(direction);
            countInRow += CountSameColorInDirection(direction.Reverse());
            if (countInRow >= 5) IsGameOver = true;
        }
    }

    public virtual bool IsRegal() {
        return board.GetPiece(Position) == null;
    }

    int CountSameColorInDirection(Direction direction) {
        var nextPiece = GetNextPiece(direction);
        if (nextPiece == null) return 0;
        if (nextPiece.Color != Color) return 0;
        return nextPiece.CountSameColorInDirection(direction) + 1;
    }

    protected Piece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        if (nextCell == null) return null;
        return board.GetPiece(nextCell);
    }
}
