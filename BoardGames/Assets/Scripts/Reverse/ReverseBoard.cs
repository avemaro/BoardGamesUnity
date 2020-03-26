﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBoard : Board {
    public ReverseBoard() {
        pieces.Add(new ReversePiece(this, PieceColor.black, Cell.d5));
        pieces.Add(new ReversePiece(this, PieceColor.black, Cell.e4));
        pieces.Add(new ReversePiece(this, PieceColor.white, Cell.d4));
        pieces.Add(new ReversePiece(this, PieceColor.white, Cell.e5));
    }

    protected override bool IsRegal(Piece newPiece) {
        if (!base.IsRegal(newPiece)) return false;

        foreach (var direction in DirectionExtend.AllCases) {
            var nextCell = newPiece.Position.Next(direction);
            if (nextCell == null) continue;
            if (GetColor((Cell)nextCell) != ColorInTurn.Reverse()) continue;
            var next2Cell = ((Cell)nextCell).Next(direction);
            if (next2Cell == null) continue;
            if (GetColor((Cell)next2Cell) != ColorInTurn) continue;
            return true;
        }
        return false;
    }
}