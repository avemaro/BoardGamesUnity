using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBoard : Board {
    protected override Piece CreatePiece(PieceColor color, Cell cell) {
        throw new System.NotImplementedException();
    }

    protected override void DecideWinner() {
        throw new System.NotImplementedException();
    }
}
