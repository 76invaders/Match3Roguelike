using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Board))]
public class MatchCheker : MonoBehaviour
{
    [SerializeField] private int _minSolveValue = 3;
    private Board _board;

    private void Awake()
    {
        _board = GetComponent<Board>();
    }

    internal void Check(in Vector2 firstTile, in Vector2 secondTile)
    {
        CheckVertical(firstTile);
        CheckVertical(secondTile);

        CheckHorisontal(firstTile);
        CheckHorisontal(secondTile);

        void CheckVertical(Vector2 position)
        {
            int topBorder = (int)position.y;
            int downBorder = (int)position.y;

            TileType tileType = _board.tiles[(int)position.x, (int)position.y].gem.tileType;

            while (topBorder < _board.tiles.GetLength(1) &&
                   tileType == _board.tiles[(int)position.x, topBorder].gem.tileType)
            {
                topBorder++;
            }

            while (downBorder >= 0 && tileType ==
                   _board.tiles[(int)position.x, downBorder].gem.tileType)
            {
                downBorder--;
            }
            downBorder++;

            int size = topBorder - downBorder;
        }

        void CheckHorisontal(Vector2 position)
        {
            int rightBorder = (int)position.x;
            int leftBorder = (int)position.x;

            TileType tileType = _board.tiles[(int)position.x, (int)position.y].gem.tileType;

            while (rightBorder < _board.tiles.GetLength(0) &&
                   tileType == _board.tiles[rightBorder, (int)position.y].gem.tileType)
            {
                rightBorder++;
            }

            while (leftBorder >= 0 && tileType ==
                   _board.tiles[leftBorder, (int)position.y].gem.tileType)
            {
                leftBorder--;
            }
            leftBorder++;

            int size = rightBorder - leftBorder;
        }
    }
}