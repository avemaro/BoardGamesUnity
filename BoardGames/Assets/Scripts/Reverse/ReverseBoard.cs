using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBoard : Board {
    public ReverseBoard() {
        Pieces.Add(new ReversePiece(this, PieceColor.black, Cell.d5));
        Pieces.Add(new ReversePiece(this, PieceColor.black, Cell.e4));
        Pieces.Add(new ReversePiece(this, PieceColor.white, Cell.d4));
        Pieces.Add(new ReversePiece(this, PieceColor.white, Cell.e5));
    }

    public void Reverse() {
        foreach (ReversePiece piece in Pieces)
            if (piece.IsReversible) piece.Reverse();
        ResetPieceState();
    }

    public bool HasReversiblePiece() {
        foreach (ReversePiece piece in Pieces)
            if (piece.IsReversible) return true;
        return false;
    }

    public void ResetPieceState() {
        foreach (ReversePiece piece in Pieces)
            piece.Reset();
    }

    protected override void DecideWinner() {
        if (!NoRegalHands(PieceColor.black)) return;
        if (!NoRegalHands(PieceColor.white)) return;
        IsGameOver = true;

        int numberOfblack = 0;
        int numberOfwhite = 0;
        foreach (var piece in Pieces) {
            if (piece.Color == PieceColor.black) numberOfblack++;
            if (piece.Color == PieceColor.white) numberOfwhite++;
        }
        if (numberOfblack > numberOfwhite) Winner = PieceColor.black;
        if (numberOfblack < numberOfwhite) Winner = PieceColor.white;
        if (numberOfblack == numberOfwhite) Winner = PieceColor.none;
    }

    protected override Piece CreatePiece(PieceColor color, Cell cell) {
        return new ReversePiece(this, color, cell);
    }
}