using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;

    public PieceColor GetColor(Cell cell) {
        if (cell == Cell.d3) return PieceColor.black;
        if (cell == Cell.c5) return PieceColor.white;
        return PieceColor.none;
    }

    public void PutPiece(Cell cell) {
    }
}