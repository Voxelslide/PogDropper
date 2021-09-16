using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    public UI ui;
    public AppleSpawner appleSpawner;
    private Vector2 screenBounds;
    public float moveSpeed;
    public float sideBuffer;
    private float speedMod;
    public float speedMax;

    private float timePassed = 0f;
    public float targetTime;

    private void FixedUpdate()
    {

        if (!ui.gameOver)
        {
            speedMod = appleSpawner.pipeSpeedModifier;


            //Increase moveSpeed Here
            if (timePassed >= targetTime && moveSpeed < speedMax && moveSpeed != speedMax)
            {
                if (moveSpeed >= 0) moveSpeed = moveSpeed + speedMod;
                if (moveSpeed < 0) moveSpeed = moveSpeed - speedMod;
                timePassed = 0;
            }
            if (Mathf.Abs(moveSpeed) > speedMax && moveSpeed >0) moveSpeed = speedMax;
            if (Mathf.Abs(moveSpeed) > speedMax && moveSpeed < 0) moveSpeed = -speedMax;

            //Turning around
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            if (transform.position.x < -sideBuffer || transform.position.x > sideBuffer)
            {
                moveSpeed = -moveSpeed;
            }

            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    private void Update()
    {
        timePassed += 0.01f;
    }



}
