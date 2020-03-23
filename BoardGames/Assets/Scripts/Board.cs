using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public Board(params (PieceColor, Cell)[] pieces ) {

    }

    public PieceColor GetColor(Cell cell) {
        if (cell == Cell.d5) return PieceColor.black;
        if (cell == Cell.e4) return PieceColor.black;
        if (cell == Cell.d4) return PieceColor.white;
        if (cell == Cell.e5) return PieceColor.white;
        return PieceColor.none;
    }
}
