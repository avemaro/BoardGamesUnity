using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    (PieceColor color, Cell cell)[] pieces;
    public PieceColor ColorInTurn { get; private set; }

    public Board() {
        pieces = new (PieceColor, Cell)[] {
            (PieceColor.black, Cell.d5),
            (PieceColor.black, Cell.e4),
            (PieceColor.white, Cell.d4),
            (PieceColor.white, Cell.e5)
        };
    }

    public Board(params (PieceColor, Cell)[] pieces ) {
        this.pieces = pieces;
    }

    public PieceColor GetColor(Cell cell) {
        foreach (var piece in pieces)
            if (cell == piece.cell) return piece.color;
        return PieceColor.none;
    }

    public void PutPiece(Cell cell) {
    }
}
