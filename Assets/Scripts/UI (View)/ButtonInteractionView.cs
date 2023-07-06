using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionView : PopUpWindow
{
    public override void Hide()
    {
        base.Hide();
        Destroy(gameObject);
    }
}
