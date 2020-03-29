using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePiece : Piece
{
    public bool IsReversible { get; protected set; }

    public ReversePiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }

    public override void Work() {
        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = (ReversePiece)GetNextPiece(direction);
            if (nextPiece == null) continue;
            nextPiece.CheckReversible(Color, direction);
        }

        //CheckReversible();
        ((ReverseBoard)board).Reverse();
    }

    public override bool IsRegal() {
        if (!base.IsRegal()) return false;
        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = (ReversePiece)GetNextPiece(direction);
            if (nextPiece == null) continue;
            nextPiece.CheckReversible(Color, direction);
            if (((ReverseBoard)board).HasReversiblePiece()) {
                ((ReverseBoard)board).ResetPieceState();
                return true;
            }
        }
        return false;

        var isRegal = CheckReversible();
        ((ReverseBoard)board).ResetPieceState();
        return isRegal;
    }

    public void Reverse() {
        Color = Color.Reverse();
    }

    public void Reset() {
        IsReversible = false;
    }

    bool CheckReversible() {
        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = (ReversePiece)GetNextPiece(direction);
            if (nextPiece == null) continue;
            nextPiece.CheckReversible(Color, direction);
            if (((ReverseBoard)board).HasReversiblePiece())
                return true;
        }
        return false;
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