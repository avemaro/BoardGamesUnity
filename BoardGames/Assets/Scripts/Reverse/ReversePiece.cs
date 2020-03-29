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

        //foreach (var direction in DirectionExtend.AllCases) {
        //    var nextPiece = (ReversePiece)GetNextPiece(direction);
        //    if (nextPiece == null) continue;
        //    var next2Piece = (ReversePiece)nextPiece.GetNextPiece(direction);
        //    if (next2Piece == null) continue;
        //    if (nextPiece.Color != Color && next2Piece.Color == Color) {   //挟む駒が２つ以上の場合、ここの条件がfalseになる
        //        nextPiece.IsReversible = true;
        //        return true;
        //    }
        //    var next3Piece = next2Piece.GetNextPiece(direction);
        //    if (next3Piece == null) continue;
        //    if (nextPiece.Color != Color && next2Piece.Color != Color
        //        && next3Piece.Color == Color ) {
        //        nextPiece.IsReversible = true;
        //        next2Piece.IsReversible = true;
        //        return true;
        //    }
        //}

        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = (ReversePiece)GetNextPiece(direction);
            if (nextPiece == null) continue;
            nextPiece.CheckReversible(Color, direction);
            if (((ReverseBoard)board).HasReversiblePiece())
                return true;
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