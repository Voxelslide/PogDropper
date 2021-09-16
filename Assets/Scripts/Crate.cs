using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public UI ui;

    public int score;
    public bool scoreUpdated;
    public float yPosition;

    private void FixedUpdate()
    {

        if (!ui.gameOver)
        {
            Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cameraPosition.x, yPosition);
        }
        //if mouse is out of bounds
        /*if(Input.mousePosition.x < 150)
        {
            Vector2 cameraStuff = Camera.main.ScreenToWorldPoint(new Vector2(150, yPosition));
            transform.position = cameraStuff;
        }
        else if(Input.mousePosition.x < 930)
        {
            Vector2 cameraStuff = Camera.main.ScreenToWorldPoint(new Vector2(930, yPosition));
            transform.position = cameraStuff;
        } else*/


    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (!ui.gameOver)
        {
            //Add to the score
            score = score + 10;
            scoreUpdated = true;
        }

        //Destroy the object
        Destroy(otherObject.gameObject);
    }

    private void Start()
    {
        scoreUpdated = false;
    }

}
