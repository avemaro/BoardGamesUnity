using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece {
    protected Board board;
    public PieceColor Color { get; protected set; }
    public Cell Position { get; protected set; }
    public bool IsGameOver { get; protected set; }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public bool Move(Cell to) {
        if (Position == Cell.b7) return false;
        if (Position == Cell.a6) {
            if (to == Cell.c4) return false;
            if (to == Cell.b5) {
                Position = to;
                return true;
            }
        }
        if (Position == Cell.e2) return false;
        if (Position == Cell.d3) {
            if (to == Cell.b5) return false;
            if (to == Cell.c4) {
                Position = to;
                return true;
            }
        }
        return false;
    }

    public abstract void Work();
    public virtual bool IsRegal() {
        return board.GetPiece(Position) == null;
    }

    protected Piece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        if (nextCell == null) return null;
        return board.GetPiece(nextCell);
    }
}