using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

// https://docs.unity3d.com/2018.4/Documentation/ScriptReference/EventSystems.IPointerClickHandler.html

public class EditableTilemap : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Tile towerTilePrefab;
    [SerializeField] GameObject tower;
    [SerializeField] Coins coins;
    [SerializeField] int towerCost = 5;
    Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {   if(coins.CanSpendcoins(towerCost)){
        coins.Spendcoins(towerCost);
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.pointerCurrentRaycast.screenPosition);
        position.z = 0;
        Vector3Int position3Int = Vector3Int.FloorToInt(position);
        tilemap.SetTile(position3Int, null);
        Instantiate(tower, position3Int + tilemap.cellSize / 2, Quaternion.identity);
        }
    }
}