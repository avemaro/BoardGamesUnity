using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    protected List<Piece> pieces = new List<Piece>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;
    public bool IsGameOver { get; private set; }
    public PieceColor Winner { get; private set; } 

    public Piece GetPiece(Cell? cell) {
        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }

    public PieceColor GetColor(Cell cell) {
        var piece = GetPiece(cell);
        if (piece == null) return PieceColor.none;
        return piece.Color;
    }
    public bool IsBlack(Cell cell) {
        return GetColor(cell) == PieceColor.black;
    }
    public bool IsWhite(Cell cell) {
        return GetColor(cell) == PieceColor.white;
    }
    public bool IsNone(Cell cell) {
        return GetColor(cell) == PieceColor.none;
    }


    public virtual bool PutPiece(Cell cell) {
        if (GetPiece(cell) != null) return false;
        var newPiece = new Piece(this, ColorInTurn, cell);
        pieces.Add(newPiece);

        newPiece.Work();

        DecideWinner();
        ColorInTurn = ColorInTurn.Reverse();

        return true;
    }

    void DecideWinner() {
        foreach (var piece in pieces)
            if (piece.IsGomoku) {
                IsGameOver = true;
                Winner = ColorInTurn;
            }
    }
}