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

    public void Reverse() {
        if (Color == PieceColor.black) Color = PieceColor.white;
        else if (Color == PieceColor.white) Color = PieceColor.black;
    }
}

public enum PieceColor {
    white, black, none
}