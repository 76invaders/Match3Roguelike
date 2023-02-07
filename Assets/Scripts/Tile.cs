using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tile : MonoBehaviour
{
    private Image _sprite;
    private Gem _gem;
    private const float _tweenSpeed = 0.5f;
    private Vector3 _scaleSize = new Vector3(1.2f, 1.2f, 1.2f);

    private void Awake()
    {
        _sprite = GetComponent<Image>();
        SetGemToTile();
    }

    private void SetGemToTile()
    {
        _gem = TilesBank.gems[Random.Range(0, TilesBank.gems.Length)];
        _sprite.sprite = _gem.image;
    }

    internal void SwapTile(Vector3 newPosition)
    {
        transform.DOMove(newPosition, _tweenSpeed, false);
    }

    internal void SelectTile()
    {
        transform.SetAsLastSibling();
        transform.DOScale(_scaleSize, _tweenSpeed);
    }

    internal void UnSelectTile()
    {
        transform.DOScale(new Vector3(1,1,1), _tweenSpeed);
    }
}