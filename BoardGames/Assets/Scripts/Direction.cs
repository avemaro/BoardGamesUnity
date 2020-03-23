using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    up = -8, down = 8, right = 1, left = -1,
    upRight = -7, upLeft = -9, downRight = 9, downLeft = 7
}

public static class DirectionExtend {
    public static (int x, int y) Pos(this Direction direction) {
        switch (direction) {
            case Direction.up: return (0, 1);
            case Direction.upRight: return (1, 1);
            case Direction.right: return (1, 0);
            case Direction.downRight: return (1, -1);
            case Direction.down: return (0, -1);
            case Direction.downLeft: return (-1, -1);
            case Direction.left: return (-1, 0);
            case Direction.upLeft: return (-1, 1);
        }
        return (0, 0);
    }

    public static Direction Reverse(this Direction direction) {
        switch (direction) {
            case Direction.up: return Direction.down;
            case Direction.upRight: return Direction.downLeft;
            case Direction.right: return Direction.left;
            case Direction.downRight: return Direction.upLeft;
            case Direction.down: return Direction.up;
            case Direction.downLeft: return Direction.upRight;
            case Direction.left: return Direction.right;
            default: return Direction.downRight;
        }
    }
}
