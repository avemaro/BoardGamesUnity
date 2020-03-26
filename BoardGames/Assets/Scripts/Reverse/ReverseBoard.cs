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
        if (cell == Cell.c4 && GetColor(Cell.d4) == PieceColor.white &&
            GetColor(Cell.e4) == PieceColor.black)
            return true;
        if (cell == Cell.d3 && GetColor(Cell.d4) == PieceColor.white &&
            GetColor(Cell.d5) == PieceColor.black)
            return true;
        if (cell == Cell.e6 && GetColor(Cell.e5) == PieceColor.white &&
            GetColor(Cell.e4) == PieceColor.black)
            return true;
        if (cell == Cell.f5 && GetColor(Cell.e5) == PieceColor.white &&
            GetColor(Cell.d5) == PieceColor.black)
            return true;
        return false;
    }
}