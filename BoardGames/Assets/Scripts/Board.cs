using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    List<Piece> pieces = new List<Piece>();

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

    Piece GetPiece(Cell? cell) {
        if (cell == null) return null;
        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }
}