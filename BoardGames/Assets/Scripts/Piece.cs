using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    public PieceColor Color { get; private set; }
    public Cell Position { get; private set; }

    public Piece(PieceColor color, Cell position) {
        Color = color;
        Position = position;
    }
}
