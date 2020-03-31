using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersPiece : Piece {
    public CheckersPiece(Board board, PieceColor color, Cell position) : base(board, color, position) {
    }

    public override void Work() {
        throw new System.NotImplementedException();
    }

    public override bool IsRegal(Cell to) {
        if (board.GetPiece(to) != null) return false;
        if (Position == Cell.a6 && to == Position.Next(Direction.upRight)) return true;
        if (Position == Cell.d3 && to == Position.Next(Direction.downLeft)) return true;
        return false;
    }
}