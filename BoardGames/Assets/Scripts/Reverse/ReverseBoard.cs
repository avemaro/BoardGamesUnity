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

        var cell = newPiece.Position;
        if (cell == Cell.c4 && IsWhite(Cell.d4) && IsBlack(Cell.e4))
            return true;
        if (cell == Cell.d3 && IsWhite(Cell.d4) && IsBlack(Cell.d5))
            return true;
        if (cell == Cell.e6 && IsWhite(Cell.e5) && IsBlack(Cell.e4))
            return true;
        if (cell == Cell.f5 && IsWhite(Cell.e5) && IsBlack(Cell.d5))
            return true;
        return false;
    }
}