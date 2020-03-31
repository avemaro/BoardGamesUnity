using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersPiece : Piece {
    public CheckersPiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }

    public override void Work() {
        throw new System.NotImplementedException();
    }
}