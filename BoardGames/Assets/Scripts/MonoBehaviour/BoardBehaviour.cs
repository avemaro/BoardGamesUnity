using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    Board boardModel;
    public CellBehaviour cellPrefab;
    public GameObject piecePrefab;

    // Start is called before the first frame update
    void Start()
    {
        boardModel = new ReverseBoard();

        foreach (var cell in CellExtend.AllCases) {
            var cellObject = Instantiate(cellPrefab, transform);
            cellObject.cellModel = cell;
            cellObject.board = boardModel;

            var pieceData = boardModel.GetPiece(cell);
            if (pieceData == null) continue;
            cellObject.PutPiece(pieceData.Color);
        }
    }
}
