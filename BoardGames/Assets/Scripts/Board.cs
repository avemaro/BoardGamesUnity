using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    Dictionary<Cell, PieceColor> pieces = new Dictionary<Cell, PieceColor>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;
    public bool IsGameOver { get; private set; }
    public PieceColor Winner { get; private set; } 

    public PieceColor GetColor(Cell cell) {
        pieces.TryGetValue(cell, out PieceColor color);
        return color;
    }

    public bool PutPiece(Cell cell) {
        if (pieces.ContainsKey(cell)) return false;
        pieces.Add(cell, ColorInTurn);
        ColorInTurn = ColorInTurn.Reverse();

        if (GetColor(Cell.d1) == PieceColor.black &&
            GetColor(Cell.d2) == PieceColor.black &&
            GetColor(Cell.d3) == PieceColor.black &&
            GetColor(Cell.d4) == PieceColor.black &&
            GetColor(Cell.d5) == PieceColor.black) {
            IsGameOver = true;
            Winner = PieceColor.black;
        }

        if (GetColor(Cell.a3) == PieceColor.white &&
            GetColor(Cell.b4) == PieceColor.white &&
            GetColor(Cell.c5) == PieceColor.white &&
            GetColor(Cell.d6) == PieceColor.white &&
            GetColor(Cell.e7) == PieceColor.white) {
            IsGameOver = true;
            Winner = PieceColor.white;
        }

        return true;
    }
}