using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBoard : Board {
    public ReverseBoard() {
        PutPiece(Cell.d5);
        PutPiece(Cell.d4);
        PutPiece(Cell.e4);
        PutPiece(Cell.e5);
    }

    public override bool PutPiece(Cell cell) {
        if (cell == Cell.c4 || cell == Cell.d3 ||
            cell == Cell.e6 || cell == Cell.f5)
            return base.PutPiece(cell);
        return false;
    }
}