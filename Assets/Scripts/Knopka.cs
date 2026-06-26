using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Knopka : MonoBehaviour, IPointerEnterHandler
{
    public float moveDistance = 100f;
    public float speed = 500f;

    public RectTransform canvasRect; // сюда перетащи Canvas

    private RectTransform rect;
    private Vector2 targetPosition;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        targetPosition = rect.anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 randomMove = new Vector2(
            Random.Range(-moveDistance, moveDistance),
            Random.Range(-moveDistance, moveDistance)
        );

        Vector2 newPosition = targetPosition + randomMove;

        // границы Canvas
        float buttonWidth = rect.rect.width / 2;
        float buttonHeight = rect.rect.height / 2;

        float maxX = canvasRect.rect.width / 2 - buttonWidth;
        float maxY = canvasRect.rect.height / 2 - buttonHeight;

        newPosition.x = Mathf.Clamp(newPosition.x, -maxX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, -maxY, maxY);

        targetPosition = newPosition;
    }

    void Update()
    {
        rect.anchoredPosition = Vector2.MoveTowards(
            rect.anchoredPosition,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}
