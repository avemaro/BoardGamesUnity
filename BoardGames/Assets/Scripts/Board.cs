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
        return true;
    }
}