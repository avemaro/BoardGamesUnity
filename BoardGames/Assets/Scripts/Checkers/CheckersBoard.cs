using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBoard : Board {
    public CheckersBoard() {
        var blackCells = new Cell[] {Cell.a6, Cell.a8, Cell.b7,
                                         Cell.c6, Cell.c8, Cell.d7,
                                         Cell.e6, Cell.e8, Cell.f7,
                                         Cell.g6, Cell.g8, Cell.h7};
        var whiteCells = new Cell[] {Cell.a2, Cell.b1, Cell.b3,
                                         Cell.c2, Cell.d1, Cell.d3,
                                         Cell.e2, Cell.f1, Cell.f3,
                                         Cell.g2, Cell.h1, Cell.h3};
        foreach (var cell in blackCells)
            Pieces.Add(new CheckersPiece(this, PieceColor.black, cell));
        foreach (var cell in whiteCells)
            Pieces.Add(new CheckersPiece(this, PieceColor.white, cell));

    }

    public bool ExistMoveWithCapture() {
        foreach (CheckersPiece piece in Pieces) {
            if (piece.Color != ColorInTurn) continue;
            if (piece.CanCapture()) return true;
        }
        return false;
    }


    protected override Piece CreatePiece(PieceColor color, Cell cell) {
        throw new System.NotImplementedException();
    }

    protected override void DecideWinner() {
        throw new System.NotImplementedException();
    }
}
