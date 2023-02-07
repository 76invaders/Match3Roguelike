using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _xGrid;
    [SerializeField] private int _yGrid;

    [SerializeField] private int _tileSpreading = 40;

    [SerializeField] private Tile _tile;

    private Tile[,] _tiles;

    public int tileSpreading => _tileSpreading;
    public Tile[,] tiles => _tiles;

    private void Awake()
    {
        _tiles = new Tile[_xGrid, _yGrid];
        FillTilesGrid();
    }

    private void FillTilesGrid()
    {
        for (int XGrid = 0; XGrid < _xGrid; XGrid++)
        {
            for (int YGrid = 0; YGrid < _yGrid; YGrid++)
            {
                CreateTile(XGrid, YGrid);
                LocateTile(XGrid, YGrid);
            }
        }

        void CreateTile(int x, int y)
        {
            tiles[x, y] = Instantiate(_tile.GetComponent<Tile>(),
                                      transform,
                                      false);
        }

        void LocateTile(int x, int y)
        {
            tiles[x, y].transform.localPosition = new Vector3(x * _tileSpreading+20,
                                                              y * _tileSpreading+20,
                                                              0);
        }
    }
}