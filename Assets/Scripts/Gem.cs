using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Gem", menuName = "Gem object")]

public class Gem : ScriptableObject
{
    [SerializeField] private TileType _tileType;
    public TileType tileType => _tileType;

    [SerializeField] private Sprite _image;
    public Sprite image => _image;

    [SerializeField] int _points;
    public int points => _points;
}