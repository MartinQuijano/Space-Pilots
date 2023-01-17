using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject spaceship;

    public void OnPointerDown(PointerEventData eventData)
    {
        spaceship.GetComponent<Spaceship>().MoveDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        spaceship.GetComponent<Spaceship>().StopMoveDown();
    }
}
