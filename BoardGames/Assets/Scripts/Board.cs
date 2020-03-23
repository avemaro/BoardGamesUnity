using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public Board(params (PieceColor, Cell)[] pieces ) {

    }

    public PieceColor GetColor(Cell cell) {
        return PieceColor.none;
    }
}
