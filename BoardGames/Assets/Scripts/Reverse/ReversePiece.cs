using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePiece : Piece
{
    public bool IsReversible { get; protected set; }

    public ReversePiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }

    public override void Work() {
        ((ReverseBoard)board).Reverse();
    }

    public override bool IsRegal() {
        if (!base.IsRegal()) return false;

        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = (ReversePiece)GetNextPiece(direction);
            if (nextPiece == null) continue;
            var next2Piece = nextPiece.GetNextPiece(direction);
            if (next2Piece == null) continue;
            if (nextPiece.Color != Color && next2Piece.Color == Color) {
                nextPiece.IsReversible = true;
                return true;
            }
        }
        return false;
    }

    public void Reverse() {
        Color = Color.Reverse();
    }

    public void Reset() {
        IsReversible = false;
    }
}