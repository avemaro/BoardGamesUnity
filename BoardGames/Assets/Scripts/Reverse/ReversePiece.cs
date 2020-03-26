using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePiece : Piece {
    public bool IsReversible { get; private set; }

    public ReversePiece(Board board, PieceColor color, Cell position)
        : base(board, color, position) {
    }

    public override void Work() {
        CheckReversible();
        ((ReverseBoard)board).Reverse();
    }

    public void CheckReversible() {
        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) continue;
            nextPiece.CheckReversible(Color, direction);
        }
    }

    public new ReversePiece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        if (nextCell == null) return null;
        return (ReversePiece)board.GetPiece(nextCell);
    }

    public void Reset() {
        IsReversible = false;
    }

    public void Reverse() {
        Color = Color.Reverse();
    }


    void CheckReversible(PieceColor color, Direction direction) {
        if (color.IsSame(Color)) {
            var nextPiece = GetNextPiece(direction.Reverse());
            if (nextPiece == null) return;
            nextPiece.MarkReversible(color, direction.Reverse());
        } else if (color.IsOpposite(Color)) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) return;
            nextPiece.CheckReversible(color, direction);
        }
    }

    void MarkReversible(PieceColor color, Direction direction) {
        if (!color.IsOpposite(Color)) return;
        IsReversible = true;
        var nextPiece = GetNextPiece(direction);
        if (nextPiece == null) return;
        nextPiece.MarkReversible(color, direction);
    }
}