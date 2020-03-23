using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    Board board;
    public PieceColor Color { get; private set; }
    public Cell Position { get; private set; }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public void Work() {
        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) continue;
            if (nextPiece.Color == Color) continue;
            var next2Piece = nextPiece.GetNextPiece(direction);
            if (next2Piece == null) continue;
            if (next2Piece.Color != Color) continue;
            nextPiece.Reverse();
        }
    }

    Piece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        return board.GetPiece(nextCell);
    }

    public void Reverse() {
        Color = Color.Reversed();
    }
}
