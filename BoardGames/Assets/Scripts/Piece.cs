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
        if (Position == Cell.d3) board.GetPiece(Cell.d4).Reverse();
        if (Position == Cell.c5) board.GetPiece(Cell.d5).Reverse();
        if (Position == Cell.b6) board.GetPiece(Cell.c5).Reverse();
    }

    public void Reverse() {
        Color = Color.Reversed();
    }
}
