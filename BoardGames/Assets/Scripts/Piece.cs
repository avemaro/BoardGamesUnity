using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    Board board;
    public PieceColor Color { get; private set; }
    public Cell Position { get; private set; }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public void Work() {
        if (Position == Cell.d3) GetNextPiece(Direction.down).Reverse();
        if (Position == Cell.c5) GetNextPiece(Direction.right).Reverse();
        if (Position == Cell.b6) GetNextPiece(Direction.upRight).Reverse();
    }

    void Reverse() {
        if (Color == PieceColor.black) Color = PieceColor.white;
        else if (Color == PieceColor.white) Color = PieceColor.black;
    }

    Piece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        return board.GetPiece(nextCell);
    }
}

public enum PieceColor {
    white, black, none
}

public static class PieceColorExtend {
    public static string GetString(this PieceColor pieceColor) {
        switch (pieceColor) {
            case PieceColor.black: return "B";
            case PieceColor.white: return "W";
        }
        return "*";
    }
}