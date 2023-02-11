using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirstSelectState : BaseState
{
    public override void SelectTile(Vector2 selectedTile)
    {
        _board.SwitchState(new SecondSelectState(selectedTile));
        _board.board.tiles[(int)selectedTile.x, (int)selectedTile.y].SelectTile();
    }
}