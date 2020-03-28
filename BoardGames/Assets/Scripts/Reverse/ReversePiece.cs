using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePiece : Piece
{
    public ReversePiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }
    public override bool IsRegal() {
        if (!base.IsRegal()) return false;

        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = (ReversePiece)GetNextPiece(direction);
            if (nextPiece == null) continue;
            var next2Piece = nextPiece.GetNextPiece(direction);
            if (next2Piece == null) continue;
            if (nextPiece.Color != Color && next2Piece.Color == Color) {
                nextPiece.Reverse();
                return true;
            }
        }
        return false;
    }
    void Reverse() {
        Color = Color.Reverse();
    }
}
