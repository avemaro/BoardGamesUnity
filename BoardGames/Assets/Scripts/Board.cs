using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    List<Piece> pieces = new List<Piece>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;

    public Board() {
        pieces.Add(new Piece(this, PieceColor.black, Cell.d5));
        pieces.Add(new Piece(this, PieceColor.black, Cell.e4));
        pieces.Add(new Piece(this, PieceColor.white, Cell.d4));
        pieces.Add(new Piece(this, PieceColor.white, Cell.e5));
    }

    public PieceColor GetColor(Cell? cell) {
        var piece = GetPiece(cell);
        if (piece == null) return PieceColor.none;
        return piece.Color;
    }

    public void PutPiece(Cell cell) {
        if (ColorInTurn == PieceColor.black) ColorInTurn = PieceColor.white;
        else if (ColorInTurn == PieceColor.white) ColorInTurn = PieceColor.black;
    }

    Piece GetPiece(Cell? cell) {
        if (cell == null) return null;
        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }
}