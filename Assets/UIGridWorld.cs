using System.Collections.Generic;
using UnityEngine;

public class UIGridWorld : MonoBehaviour
{
    [SerializeField] private RectTransform worldContainer;
    [SerializeField] private RectTransform worldPrefab;

    [SerializeField] private float cellSize = 100f;
    [SerializeField] private float spacing = 10f;

    [SerializeField] private Dictionary<Vector2Int, RectTransform> cells = new();

    private RectTransform viewport;


    private void Awake()
    {
        viewport = GetComponent<RectTransform>();

        PopulateGrid(new RectInt(0, 0, 6, 7));
    }

    void PopulateGrid(RectInt region)
    {
        foreach (var p in region.allPositionsWithin)
        {
            if (cells.ContainsKey(p))
            {
                continue;
            }
            else
            {
                var newCell = Instantiate(worldPrefab, worldContainer);
                newCell.anchoredPosition = new Vector2(p.x * (cellSize + spacing), p.y * (cellSize + spacing));
                cells[p] = newCell;
            }
        }
    }
}
