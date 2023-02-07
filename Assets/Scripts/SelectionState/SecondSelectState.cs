using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSelectState : BaseState
{
    public SecondSelectState(Vector2 firstTile)
    {
        _firstTile = firstTile;
    }

    public override void SelectTile(Vector2 selectedTile)
    {
        Debug.Log("Переключено на второй статус");
        CompareTiles(_firstTile, selectedTile);
        ClearTilesData();
        _board.SwitchState(new FirstSelectState());
    }

    public void CompareTiles(Vector2 oldTile, Vector2 newTile)
    {
        if (Vector2.Distance(oldTile, newTile) == 1)
        {
            Debug.Log("Сменить тайлы");
            _board.SwapTiles(oldTile, newTile);
            _board.board.tiles[(int)newTile.x, (int)newTile.y].UnSelectTile();
        }
        else
        {
            Debug.Log("Отменить выделение");
            _board.board.tiles[(int)oldTile.x, (int)oldTile.y].UnSelectTile();
        }
    }
    void ClearTilesData()
    {
        _firstTile = default;
    }
}
