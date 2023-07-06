using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesManInventoryModel : InventoryModel
{
    public void BlockAllItems()
    {
        for (int i = 0; i < _itemCells.Length; i++) 
        {
            for (int j = 0; j < _itemCells[i].Length; j++)
            {
                if (_itemCells[i][j] != null)
                {
                    _itemCells[i][j].BlockCell();
                    if (_itemCells[i][j].InventoryItem != null)
                    {
                        _itemCells[i][j].InventoryItem.SetAsForStore();
                    }
                }
            }
        }
    }
}
