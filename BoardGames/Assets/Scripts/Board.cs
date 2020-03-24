using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    Dictionary<Cell, PieceColor> pieces = new Dictionary<Cell, PieceColor>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;

    public PieceColor GetColor(Cell cell) {
        PieceColor color;
        if (!pieces.TryGetValue(cell, out color)) return PieceColor.none;
        return color;
    }

    public void PutPiece(Cell cell) {
        if (cell == Cell.d3) pieces.Add(cell, PieceColor.black);
        if (cell == Cell.c5) pieces.Add(cell, PieceColor.white);
        if (ColorInTurn == PieceColor.black) ColorInTurn = PieceColor.white;
        else if (ColorInTurn == PieceColor.white) ColorInTurn = PieceColor.black;
    }
}