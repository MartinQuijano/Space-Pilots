using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject spaceship;

    public void OnPointerDown(PointerEventData eventData)
    {
        spaceship.GetComponent<Spaceship>().MoveUp();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        spaceship.GetComponent<Spaceship>().StopMoveUp();
    }
}
