using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public AppleSpawner appleSpawner;
    public UI ui;

    public float baseSpeed = 15f;
    private Rigidbody2D rb;
    //private float time;
    private Vector2 screenBounds;

    // Use this for instantiation
    private void Start()
    {
        float speedMod = appleSpawner.appleSpeedModifier;
        //setting up physics
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -(baseSpeed + speedMod));
        //time = 0f;

        //Debug.Log(ui.ToString());

        //getting the boundaries of the screen to know when this reaches out of bounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "KILL") Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.gameOver) rb.velocity = new Vector2(0,0);


        //if it goes out of bounds
        //if(transform.position.y < (-screenBounds.y - 1.5f))
        //{
           // Debug.Log("Apple despawned------------------------");
            //detract from the "lives"
            //ui.SetLoseLifeTrue();
            //ui.LoseLife();
            //ui.needToLoseLife = true;
            //Debug.Log(ui.needToLoseLife.ToString());
            //Debug.Log(ui.lifeCount.ToString());
            //ui.lifeCount = ui.lifeCount -1;
           //Debug.Log(ui.lifeCount.ToString());
            //Destroy(this.gameObject);
           // Debug.Log("Apple destroyed------------------------");


        //}
    }
}
