﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    up = -8, down = 8, right = 1, left = -1,
    upRight = -7, upLeft = -9, downRight = 9, downLeft = 7
}

public static class DirectionExtend {
    public static Direction[] AllCases = (Direction[])Enum.GetValues(typeof(Direction));

    public static (int x, int y) Pos(this Direction direction) {
        switch (direction) {
            case Direction.up: return (0, -1);
            case Direction.upRight: return (1, -1);
            case Direction.right: return (1, 0);
            case Direction.downRight: return (1, 1);
            case Direction.down: return (0, 1);
            case Direction.downLeft: return (-1, 1);
            case Direction.left: return (-1, 0);
            case Direction.upLeft: return (-1, -1);
        }
        return (0, 0);
    }

    public static Direction? NewDirection(Cell from, Cell to) {
        if (from.GetFile() == to.GetFile()) {
            if (from < to) return Direction.down;
            return Direction.up;
        }
        if (from.GetRank() == to.GetRank()) {
            if (from < to) return Direction.right;
            return Direction.left;
        }

        var indexGap = from - to;
        if (indexGap > 0) {
            if (indexGap % 7 == 0) return Direction.upRight;
            if (indexGap % 9 == 0) return Direction.upLeft;
        } else {
            if (indexGap % 7 == 0) return Direction.downLeft;
            if (indexGap % 9 == 0) return Direction.downRight;
        }
        return null;
    }
}