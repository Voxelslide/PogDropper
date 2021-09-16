using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public UI ui;

    public GameObject objectPrefab;
    private Vector2 screenBounds;
    public Crate crate;


    //adjusts apple speed
    public float appleSpeedModifier;
    public float appleSpeedModifierCap;
    public float percentageOfScoreToAddToAppleSpeed;


    //adjusts pipe speed
    public float pipeSpeedModifier;
    public float pipeSpeedModifierCap;
    public float percentageOfScoreToAddToPipeSpeed;



    //make this based on how much time has passed!!!!!!!!!!!!!!!!!!!!!!!!
    public float spawnTime;
    public float spawnTimeCap;
    public float spawnTimeDecrement;


    // Start is called before the first frame update
    void Start()
    {
        //get screenbounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //starts the process of spawning objects/ "turns on" the object spawner
        StartCoroutine(objectWave());
    }


    public void FixedUpdate()
    {
        //increase apple speed
        if (crate.scoreUpdated && appleSpeedModifier < appleSpeedModifierCap)
        {
            appleSpeedModifier += crate.score * percentageOfScoreToAddToAppleSpeed;
        } if (appleSpeedModifier > appleSpeedModifierCap) appleSpeedModifier = appleSpeedModifierCap;

        //increases pipe speed
        if (crate.scoreUpdated && pipeSpeedModifier < pipeSpeedModifierCap)
        {
            pipeSpeedModifier = crate.score * percentageOfScoreToAddToPipeSpeed;
        } if (pipeSpeedModifier > pipeSpeedModifierCap) pipeSpeedModifier = pipeSpeedModifierCap;
    }

    private void spawnObject() {
        //create new object 
        GameObject apple = Instantiate(objectPrefab) as GameObject;
        apple.transform.position = new Vector2(transform.GetChild(0).position.x, screenBounds.y - 1f);
    }

    IEnumerator objectWave()
    {
        //change this to while the game is still running/ player is "alive"
        while (!ui.gameOver) {
            //wait until we should spawn another object
            yield return new WaitForSeconds(spawnTime);
            if (spawnTime > spawnTimeCap) spawnTime -= spawnTimeDecrement;

            //actually call the spawnObject function
            if(!ui.gameOver) spawnObject();
        }
    }

}
