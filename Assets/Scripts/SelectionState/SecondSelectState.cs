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
        CompareTiles(_firstTile, selectedTile);
        ClearTilesData();
        _board.SwitchState(new FirstSelectState());
    }

    public void CompareTiles(Vector2 oldTile, Vector2 newTile)
    {
        if (Vector2.Distance(oldTile, newTile) == 1)
        {
            _board.SwapTiles(oldTile, newTile);
            _board.board.tiles[(int)newTile.x, (int)newTile.y].UnSelectTile();
        }
        else
        {
            _board.board.tiles[(int)oldTile.x, (int)oldTile.y].UnSelectTile();
        }
    }
    void ClearTilesData()
    {
        _firstTile = default;
    }
}
