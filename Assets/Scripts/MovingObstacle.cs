using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed;
    public int movementDirection;
    public bool randomStart;

    void Start()
    {
        if (randomStart)
        {
            float ySize = gameObject.GetComponent<BoxCollider2D>().size.y;
            float limitOnY = -2f + ySize;
            float randomStartingPositionY = Random.Range(limitOnY, 1.8f);
            transform.position = new Vector3(transform.position.x, randomStartingPositionY, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * movementDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "limits")
            movementDirection *= -1;
    }
}
