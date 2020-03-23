using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    (PieceColor color, Cell cell)[] pieces;

    public Board(params (PieceColor, Cell)[] pieces ) {
        this.pieces = pieces;
    }

    public PieceColor GetColor(Cell cell) {
        foreach (var piece in pieces)
            if (cell == piece.cell) return piece.color;
        return PieceColor.none;
    }
}
