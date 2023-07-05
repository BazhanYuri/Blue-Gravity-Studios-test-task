using UnityEngine;

namespace Array2DEditor
{
    [System.Serializable]
    public class Array2DBool : Array2DBase<bool>
    {
        [SerializeField]
        CellRowBool[] cells = new CellRowBool[Consts.defaultGridSize];

        protected override CellRow<bool> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }
}
