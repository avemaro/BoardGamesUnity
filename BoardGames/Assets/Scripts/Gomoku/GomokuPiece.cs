using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuPiece : Piece {
    public GomokuPiece(Board board, PieceColor color, Cell position)
        : base(board, color, position) {
    }

    public override void Work() {
        foreach (var direction in DirectionExtend.AllCases) {
            var countInRow = 1;
            countInRow += CountSameColorInDirection(direction);
            countInRow += CountSameColorInDirection(direction.Reverse());
            if (countInRow >= 5) IsGameOver = true;
        }
    }

    int CountSameColorInDirection(Direction direction) {
        var nextPiece = GetNextPiece(direction);
        if (nextPiece == null) return 0;
        if (nextPiece.Color != Color) return 0;
        return ((GomokuPiece)nextPiece).CountSameColorInDirection(direction) + 1;
    }
}
