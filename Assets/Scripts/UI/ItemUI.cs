using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image icon;

    public void UpdateInfo(Sprite itemIcon)
    {
        icon.sprite = itemIcon;
    }
}
