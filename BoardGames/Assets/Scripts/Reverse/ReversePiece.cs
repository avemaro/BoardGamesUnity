using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePiece : Piece {
    public ReversePiece(Board board, PieceColor color, Cell position)
        : base(board, color, position) {
    }

    public bool CheckReversible() {
        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) continue;
            if (nextPiece.Color != Color.Reverse()) continue;
            var next2Piece = nextPiece.GetNextPiece(direction);
            if (next2Piece == null) continue;
            if (next2Piece.Color != Color) continue;
            return true;
        }
        return false;
    }
}