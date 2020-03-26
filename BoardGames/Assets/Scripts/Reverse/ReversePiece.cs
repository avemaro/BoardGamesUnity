using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePiece : Piece {
    public ReversePiece(Board board, PieceColor color, Cell position)
        : base(board, color, position) {
    }

    public bool CheckReversible() {
        foreach (var direction in DirectionExtend.AllCases) {
            var nextCell = Position.Next(direction);
            if (nextCell == null) continue;
            if (board.GetColor((Cell)nextCell) != Color.Reverse()) continue;
            var next2Cell = ((Cell)nextCell).Next(direction);
            if (next2Cell == null) continue;
            if (board.GetColor((Cell)next2Cell) != Color) continue;
            return true;
        }
        return false;
    }
}