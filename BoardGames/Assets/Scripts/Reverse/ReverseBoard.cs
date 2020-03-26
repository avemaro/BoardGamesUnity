using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBoard : Board {
    public ReverseBoard() {
        pieces.Add(new ReversePiece(this, PieceColor.black, Cell.d5));
        pieces.Add(new ReversePiece(this, PieceColor.black, Cell.e4));
        pieces.Add(new ReversePiece(this, PieceColor.white, Cell.d4));
        pieces.Add(new ReversePiece(this, PieceColor.white, Cell.e5));
    }

    protected override bool IsRegal(Piece newPiece) {
        if (!base.IsRegal(newPiece)) return false;

        if (ColorInTurn == PieceColor.white) return true;

        if (newPiece.Position == Cell.c4 ||
            newPiece.Position == Cell.d3 ||
            newPiece.Position == Cell.e6 ||
            newPiece.Position == Cell.f5)
            return true;
        return false;
    }
}