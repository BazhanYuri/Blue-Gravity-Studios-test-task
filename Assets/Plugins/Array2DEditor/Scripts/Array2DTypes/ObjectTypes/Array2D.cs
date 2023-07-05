using UnityEngine;

namespace Array2DEditor
{
    [System.Serializable]
    public class Array2D<T> : Array2DBase<T> where T : class
    {
        [SerializeField]
        CellRow<T>[] cells = new CellRow<T>[Consts.defaultGridSize];

        protected override CellRow<T> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }
}
