using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBoard : Board {
    public ReverseBoard() {
        pieces.Add(new Piece(this, PieceColor.black, Cell.d5));
        pieces.Add(new Piece(this, PieceColor.black, Cell.e4));
        pieces.Add(new Piece(this, PieceColor.white, Cell.d4));
        pieces.Add(new Piece(this, PieceColor.white, Cell.e5));
    }

    public override bool PutPiece(Cell cell) {


        if (cell == Cell.c4 || cell == Cell.d3 ||
            cell == Cell.e6 || cell == Cell.f5)
            return base.PutPiece(cell);
        return false;
    }
}