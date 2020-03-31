using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersPiece : Piece {
    public CheckersPiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }

    public override bool Move(Cell to) {
        if (board.GetPiece(to)!= null) return false;
        if (Position == Cell.a6) {
            if (to == Cell.c4) return false;
            if (to == Cell.b5) {
                Position = to;
                return true;
            }
        }
        if (Position == Cell.d3) {
            if (to == Cell.b5) return false;
            if (to == Cell.c4) {
                Position = to;
                return true;
            }
        }
        return false;
    }

    public override void Work() {
        throw new System.NotImplementedException();
    }
}