using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    List<(PieceColor color, Cell cell)> pieces;
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;

    public Board() {
        pieces = new List<(PieceColor, Cell)> {
            (PieceColor.black, Cell.d5),
            (PieceColor.black, Cell.e4),
            (PieceColor.white, Cell.d4),
            (PieceColor.white, Cell.e5)
        };
    }

    public Board(params (PieceColor, Cell)[] pieces ) {
        this.pieces = new List<(PieceColor color, Cell cell)>(pieces);
    }

    #region color
    public PieceColor GetColor(Cell cell) {
        foreach (var piece in pieces)
            if (cell == piece.cell) return piece.color;
        return PieceColor.none;
    }
    public bool IsNone(Cell cell) {
        return GetColor(cell) == PieceColor.none;
    }
    public bool IsBlack(Cell cell) {
        return GetColor(cell) == PieceColor.black;
    }
    public bool IsWhite(Cell cell) {
        return GetColor(cell) == PieceColor.white;
    }
    #endregion

    public bool PutPiece(Cell cell) {
        if (!IsNone(cell)) return false;

        for (var i = 0; i < pieces.Count; i++) {
            var piece = pieces[i];
            if (cell == Cell.d3 && piece.cell == Cell.d4)
                pieces[i] = (PieceColor.black, Cell.d4);
            if (cell == Cell.c5 && piece.cell == Cell.d5)
                pieces[i] = (PieceColor.white, Cell.d5);
            if (cell == Cell.b6 && piece.cell == Cell.c5)
                pieces[i] = (PieceColor.black, Cell.c5);
        }


        pieces.Add((ColorInTurn, cell));
        ColorInTurn = ColorInTurn.Reversed();
        return true;
    }
}
