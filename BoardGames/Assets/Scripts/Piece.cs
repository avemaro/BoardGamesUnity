using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece {
    protected Board board;
    public PieceColor Color { get; protected set; }
    public Cell Position { get; protected set; }
    public bool IsGameOver { get; protected set; }


    public bool Move(Cell to) {
        var canMoveLeftForward = new List<Cell>() { Cell.c6, Cell.e6, Cell.g6 };
        var canMoveRightForward = new List<Cell>() { Cell.a6 };

        if (canMoveLeftForward.Contains(Position) &&
            Position.Next(Direction.upLeft) == to) {
            Position = to;
            return true;
        }
        if (canMoveRightForward.Contains(Position) &&
            Position.Next(Direction.upRight) == to) {
            Position = to;
            return true;
        }

        return false;
    }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
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