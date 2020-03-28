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
            nextPiece.CheckReversible(Color, direction);
            CheckReversible(Color, direction);
            foreach (ReversePiece piece in board.pieces)
                if (piece.IsReversible) return true;
        }
        return false;
    }

    public void Reverse() {
        Color = Color.Reverse();
    }

    public void Reset() {
        IsReversible = false;
    }

    void CheckReversible(PieceColor color, Direction direction) {
        if (Color == color) {
            var nextPiece = (ReversePiece)GetNextPiece(direction.Reverse());
            if (nextPiece == null) return;
            nextPiece.MarkReversible(color, direction.Reverse());
        } else if (Color == color.Reverse()) {
            var nextPiece = (ReversePiece)GetNextPiece(direction);
            if (nextPiece == null) return;
            nextPiece.CheckReversible(color, direction);
        }
    }

    void MarkReversible(PieceColor color, Direction direction) {
        if (Color != color.Reverse()) return;
        IsReversible = true;
        var nextPiece = (ReversePiece)GetNextPiece(direction);
        if (nextPiece == null) return;
        nextPiece.MarkReversible(color, direction);
    }
}