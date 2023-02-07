using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Gem", menuName = "Gem object")]

public class Gem : ScriptableObject
{
    [SerializeField] private TileType tileType;
    [SerializeField] private Sprite _image;
    public Sprite image => _image;
}