using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected BoardInteractor _board;
    protected Vector2 _firstTile;

    protected readonly IBoardStateSwitcher _stateSwitcher;

    public void SelectBoard(BoardInteractor board)
    {
        _board = board;
    }

    public abstract void SelectTile(Vector2 selectetTile);
}
