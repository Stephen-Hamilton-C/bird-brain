using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Inverter : MonoBehaviour
{
    [SerializeField] private GameObject _groundTilemapObj;
    [SerializeField] private TileBase _groundTile;
    [FormerlySerializedAs("_offset")] [SerializeField] private Vector2Int _groundOffset;
    [SerializeField] private TileBase _lavaTile;
    [SerializeField] private GameObject _lavaTilemapObj;
    [SerializeField] private Vector2Int _lavaOffset;

    private Tilemap _groundTilemap;
    private KillBox _groundKillBox;
    private CompositeCollider2D _groundCollider;
    private Tilemap _lavaTilemap;
    private KillBox _lavaKillBox;
    private CompositeCollider2D _lavaCollider;

    private void Start()
    {
        _groundTilemap = _groundTilemapObj.GetComponent<Tilemap>();
        _groundKillBox = _groundTilemapObj.GetComponent<KillBox>();
        _groundCollider = _groundTilemapObj.GetComponent<CompositeCollider2D>();
        _lavaTilemap = _lavaTilemapObj.GetComponent<Tilemap>();
        _lavaKillBox = _lavaTilemapObj.GetComponent<KillBox>();
        _lavaCollider = _lavaTilemapObj.GetComponent<CompositeCollider2D>();
    }

    private void SetTiles(Tilemap tilemap, TileBase newTile, Vector2Int offset)
    {
        var bounds = tilemap.cellBounds;
        var tiles = tilemap.GetTilesBlock(bounds);
        
        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = tiles[x + y * bounds.size.x];
                if (tile != null) {
                    tilemap.SetTile(new Vector3Int(x + offset.x, y + offset.y, 0), newTile);
                }
            }
        }
    }

    public void Invert()
    {
        SetTiles(_groundTilemap, _lavaTile, _groundOffset);
        _groundKillBox.enabled = true;
        _groundCollider.isTrigger = true;
        
        SetTiles(_lavaTilemap, _groundTile, _lavaOffset);
        _lavaKillBox.enabled = false;
        _lavaCollider.isTrigger = false;
    }
}
