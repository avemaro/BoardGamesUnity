using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersPiece : Piece {
    public CheckersPiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }

    public override void Work() {
        throw new System.NotImplementedException();
    }

    public override bool IsRegal(Cell to) {
        if (Position == Cell.b7) return false;
        if (Position == Cell.a6) {
            if (to == Cell.c4) return false;
            if (to == Cell.b5) return true;
        }
        if (Position == Cell.e2) return false;
        if (Position == Cell.d3) {
            if (to == Cell.b5) return false;
            if (to == Cell.c4) return true;
        }
        return false;
    }
}