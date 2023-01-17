using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed = 10;

    public GameObject sectionGeneratorGO;
    public SectionGenerator sectionGeneratorScript;

    private bool moveUp;
    private bool moveDown;

    void Start()
    {
        moveUp = false;
        moveDown = false;
        sectionGeneratorGO = GameObject.Find("SectionGenerator");
        sectionGeneratorScript = sectionGeneratorGO.GetComponent<SectionGenerator>();
    }

    void FixedUpdate()
    {
        if (!sectionGeneratorScript.gameEnded)
        {
            if (moveUp && !moveDown)
                GetComponent<Rigidbody2D>().velocity = Vector2.up  * speed;
            if (moveDown && !moveUp)
                GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
            if ((moveUp && moveDown) || (!moveUp && !moveDown))
                GetComponent<Rigidbody2D>().velocity = Vector2.up * 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            sectionGeneratorScript.gameEnded = true;
            sectionGeneratorScript.GameOverStates();
        }
    }

    public void MoveUp()
    {
        moveUp = true;
    }

    public void StopMoveUp()
    {
        moveUp = false;

    } public void MoveDown()
    {
        moveDown = true;
    }

    public void StopMoveDown()
    {
        moveDown = false;
    }

}
