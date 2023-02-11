using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Board))]
[RequireComponent(typeof(MatchCheker))]
public class BoardInteractor : MonoBehaviour, IPointerClickHandler
{
    private RectTransform _rect;
    private MatchCheker _matchChecker;
    private Board _board;
    private BaseState _state;
    private Vector2 _selectedPosition;

    public Board board => _board;

    private void Awake()
    {
        _matchChecker = GetComponent<MatchCheker>();
        _board = GetComponent<Board>();
        _rect = GetComponent<RectTransform>();
        Debug.Log(_selectedPosition);
        SwitchState(new FirstSelectState());
    }

    public void OnPointerClick(PointerEventData data)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_rect, data.position, Camera.main, out Vector2 _selectedPosition);
        _state.SelectTile(InterpolateToMatrix(_selectedPosition));
    }

    private Tile RayCastCaller(Vector2 rayCastPoint)
    {
        return _board.tiles[(int)rayCastPoint.x / _board.tileSpreading, (int)rayCastPoint.y / _board.tileSpreading];
    }

    private Vector2 InterpolateToMatrix(Vector2 rayCastPoint)
    {
        return new Vector2((int)rayCastPoint.x / _board.tileSpreading, (int)rayCastPoint.y / _board.tileSpreading);
    }

    internal void SwitchState(BaseState state)
    {
        _state = state;
        _state.SelectBoard(this);
    }

    internal void SwapTiles(Vector2 firstTile, Vector2 secondTile)
    {
        Tile _firstTile = _board.tiles[(int)firstTile.x, (int)firstTile.y];
        Tile _secondTile = _board.tiles[(int)secondTile.x, (int)secondTile.y];

        Vector3 _firstPosition = _firstTile.transform.position; 
        Vector3 _secondPosition = _secondTile.transform.position;

        _firstTile.SwapTile(_secondPosition);
        _secondTile.SwapTile(_firstPosition);

        (_board.tiles[(int)firstTile.x, (int)firstTile.y], _board.tiles[(int)secondTile.x, (int)secondTile.y]) =
            (_board.tiles[(int)secondTile.x, (int)secondTile.y], _board.tiles[(int)firstTile.x, (int)firstTile.y]);

        _matchChecker.Check(firstTile, secondTile);
    }
}