using UnityEngine;

namespace Array2DEditor
{
    [System.Serializable]
    public class Array2DExampleEnum : Array2DBase<ExampleEnum>
    {
        [SerializeField]
        CellRowExampleEnum[] cells = new CellRowExampleEnum[Consts.defaultGridSize];

        protected override CellRow<ExampleEnum> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }
    
    [System.Serializable]
    public class CellRowExampleEnum : CellRow<ExampleEnum> { }
}
