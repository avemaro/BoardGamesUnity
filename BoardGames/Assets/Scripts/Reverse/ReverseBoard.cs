using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBoard : Board {
    public ReverseBoard() {
        pieces.Add(new ReversePiece(this, PieceColor.black, Cell.d5));
        pieces.Add(new ReversePiece(this, PieceColor.black, Cell.e4));
        pieces.Add(new ReversePiece(this, PieceColor.white, Cell.d4));
        pieces.Add(new ReversePiece(this, PieceColor.white, Cell.e5));
    }

    public override bool PutPiece(Cell cell) {
        var newPiece = new ReversePiece(this, ColorInTurn, cell);

        if (!IsRegal(newPiece)) return false;
        pieces.Add(newPiece);
        newPiece.Work();

        DecideWinner();
        ColorInTurn = ColorInTurn.Reverse();

        return true;
    }

    bool IsRegal(ReversePiece newPiece) {
        if (!base.IsRegal(newPiece)) return false;
        var isRegal = false;
        newPiece.CheckReversible();
        foreach (ReversePiece piece in pieces) {
            if (piece.IsReversible) isRegal = true;
            piece.Reset();
        }
        return isRegal;
    }

    public void Reverse() {
        foreach (ReversePiece piece in pieces) {
            if (piece.IsReversible) piece.Reverse();
            piece.Reset();
        }
    }
}