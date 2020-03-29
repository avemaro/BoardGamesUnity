﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellBehaviour : MonoBehaviour
{
    public Cell model;
    Button button;
    public GameObject blackPiecePrefab;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Select);

        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select() {
        Debug.Log("Cell." + model);
        var piece = Instantiate(blackPiecePrefab, transform);
        piece.GetComponent<Image>().color = Color.white;
    }

    public void SetPosition() {
        var file = model.GetFile();
        var x = 0;
        switch (file) {
            case CellExtend.File.a: x = -350; break;
            case CellExtend.File.b: x = -250; break;
            case CellExtend.File.c: x = -150; break;
            case CellExtend.File.d: x =  -50; break;
            case CellExtend.File.e: x =   50; break;
            case CellExtend.File.f: x =  150; break;
            case CellExtend.File.g: x =  250; break;
            case CellExtend.File.h: x =  350; break;
        }
        var rank = model.GetRank();
        var y = 0;
        switch (rank) {
            case CellExtend.Rank.one: y = 350; break;
            case CellExtend.Rank.two: y = 250; break;
            case CellExtend.Rank.three: y = 150; break;
            case CellExtend.Rank.four: y = 50; break;
            case CellExtend.Rank.five: y = -50; break;
            case CellExtend.Rank.six: y = -150; break;
            case CellExtend.Rank.seven: y = -250; break;
            case CellExtend.Rank.eight: y = -350; break;
        }
        transform.localPosition = new Vector3(x, y);
    }
}
