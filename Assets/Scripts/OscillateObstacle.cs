using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateObstacle : MonoBehaviour
{
    public int verticalDirection;
    public bool randomStart;
    public float startingXPosition;
    public float ySpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        startingXPosition = transform.localPosition.x;
        if (randomStart)
        {
            float ySize = gameObject.GetComponent<BoxCollider2D>().size.y;
            float limitOnY = -2f + ySize;
            float randomStartingPositionY = UnityEngine.Random.Range(limitOnY, 1.8f);
            float randomVerticalDir = UnityEngine.Random.Range(0,2);
            if (randomVerticalDir == 0)
                verticalDirection = 1;
            else verticalDirection = -1;
            transform.localPosition = new Vector3(transform.localPosition.x, randomStartingPositionY, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newY = transform.localPosition.y + (ySpeed * verticalDirection * Time.deltaTime);
        float newX = Mathf.Sin(Time.time * 8);
        transform.localPosition = new Vector3(startingXPosition + newX, newY, 0);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "limits")
            verticalDirection *= -1;
    }
}
