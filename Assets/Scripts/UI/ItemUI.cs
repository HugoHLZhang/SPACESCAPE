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

    public void UpdateSize(Sprite itemIcon, float width, float height)
    {
        icon.rectTransform.sizeDelta = new Vector2(width, height);
    }

    public void UpdateColor(Sprite itemIcon, Color color)
    {
        icon.color = color;
    }
}
