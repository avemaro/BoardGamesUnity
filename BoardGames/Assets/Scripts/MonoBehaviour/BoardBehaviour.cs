﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    Board board;
    public CellBehaviour cellPrefab;
    // Start is called before the first frame update
    void Start()
    {
        board = new Board();

        foreach (var cell in CellExtend.AllCases) {
            var cellObject = Instantiate(cellPrefab, transform);
            cellObject.model = cell;
            cellObject.board = board;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
