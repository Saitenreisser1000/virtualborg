using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector2 elementSize;
    public float hoverX = 20;
    public float hoverY = 0;
    public bool isOver = false;

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        elementSize = rectTransform.rect.size;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.sizeDelta = new Vector2(elementSize.x + hoverX, elementSize.y + hoverY);
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.sizeDelta = elementSize;
        isOver = false;
    }
}
