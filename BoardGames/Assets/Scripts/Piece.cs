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
        if (!IsRegal(to)) return false;
        Position = to;
        return true;
    }

    public abstract void Work();
    public virtual bool IsRegal() {
        return board.GetPiece(Position) == null;
    }
    public abstract bool IsRegal(Cell to);

    protected Piece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        if (nextCell == null) return null;
        return board.GetPiece(nextCell);
    }
}