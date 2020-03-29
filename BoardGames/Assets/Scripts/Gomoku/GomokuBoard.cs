using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuBoard: Board {
    protected override void DecideWinner() {
        foreach (var piece in pieces)
            if (piece.IsGameOver) {
                IsGameOver = true;
                Winner = piece.Color;
            }
    }
    protected override Piece CreatePiece(PieceColor color, Cell cell) {
        return new GomokuPiece(this, color, cell);
    }
}