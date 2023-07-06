using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PopUpWindow : MonoBehaviour
{
    public bool IsVisible { get; private set; }

    private void Start()
    {
        Show();
    }

    public virtual void Hide()
    {
        transform.DOScale(0, 0.2f);
        IsVisible = false;
    }
    public virtual void Show()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
        IsVisible = true;
    }

}
