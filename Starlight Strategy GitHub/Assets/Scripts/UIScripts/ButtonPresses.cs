using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresses : MonoBehaviour
{
    public void ActivateSelf()
    {
        gameObject.SetActive(true);
    }
    public void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
    public void OpenUnitMainOptions()
    {
        return;
    }
}
