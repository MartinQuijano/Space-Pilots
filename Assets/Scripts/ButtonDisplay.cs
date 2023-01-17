using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonDisplay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject buttonText;
    private Vector3 originalPosition;

    void Start()
    {
        buttonText = transform.GetChild(0).gameObject;
        originalPosition = buttonText.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (buttonIsPressed)
        {
            buttonText.transform.position = new Vector3(buttonText.transform.position.x, buttonText.transform.position.y + 10,0);
        }else
        {
            buttonText.transform.position = originalPosition;
        }*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonText.transform.position = new Vector3(buttonText.transform.position.x, buttonText.transform.position.y - 7, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonText.transform.position = originalPosition;
    }
}
