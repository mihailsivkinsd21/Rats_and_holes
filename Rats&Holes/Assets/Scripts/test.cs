using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Grid<Block> grid { get; private set; }

    [SerializeField]
    private Hole holePrefab;

    private void Awake()
    {
        Vector3 offset = new Vector3(-4f, -3f, 0);
        grid = new Grid<Block>(12, 6, 1f, offset, (Grid<Block> g, int x, int y) => new Block(g, x , y));
    }

    private List<Block> GetFreeBlocks()
    {
        List<Block> blocks = new List<Block>();
        foreach (var item in grid.GetGridObjects())
        {
            if (item.GetHole() == null)
            {
                blocks.Add(item);
            }
        }
        return blocks;
    }

    public void TrySpawnHole()
    {
        if (GetFreeBlocks().Count > 0)
        {
            int r = Random.Range(0, GetFreeBlocks().Count);
            Block targetBlock = GetFreeBlocks()[r];
            if (targetBlock != null)
            {
                Hole hole = Instantiate(holePrefab, grid.GetCenter(targetBlock.x, targetBlock.y), Quaternion.identity);
                targetBlock.SetHole(hole);
            }
        }
    }

}