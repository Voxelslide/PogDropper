using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public bool gameOver;
    
    public Crate crate;

    
    public Text highScoreText;
    public Text scoreText;
    public int lifeCount;
    public Image life1; //last to go
    public Image life2; //2nd to go
    public Image life3; //first to go


    public bool needToLoseLife;


    // Start is called before the first frame update
    void Start()
    {
        lifeCount = 3;
        Debug.Log("Lives @ the start: " + lifeCount.ToString());
        needToLoseLife = false;

        //Move lives back
        this.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);


        //Hide game over text and high score
        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);

    }

/*    public void SetLoseLifeTrue()
    {
        needToLoseLife = true;
    }*/

    /*void AddToScore()
    {
        //score = score + 10;
        //this.transform.GetChild(1).GetChild(0).GetComponent<Text>() = "" + score;
        //this.transform.GetChild(1).GetComponent<Text>().tex
    }*/

    public void LoseLife()
    {
        
        Debug.Log(lifeCount);
            //remove life
            if (lifeCount == 3)
            {
                this.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

            }
            else if (lifeCount == 2)
                {
                    this.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

                }
            else if (lifeCount == 1)
                {
                    this.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);

                }
           // Debug.Log("Lives before --: " + lifeCount.ToString());
            lifeCount--;
            //Debug.Log("Life Lost");
           // Debug.Log("Lives after --: " + lifeCount.ToString());

        //needToLoseLife = false;
    }


    private void FixedUpdate()
    {
      /*  if (needToLoseLife)
        {
            LoseLife();
            Debug.Log("NEED TO LOSE LIFE MESSAGE RECIEVED");
        }*/
    }


    // Update is called once per frame
    void Update()
    {
        //lifeCount--;
        //Debug.Log("Current lives: " + lifeCount.ToString());
        //Debug.Log("Need To Lose Life: " + needToLoseLife.ToString());
        


        //is game over?
        if (lifeCount <= 0) gameOver = true;

        if (gameOver)
        {
            //highScoreText.text = hi;
            int highScoreTextNumber = PlayerPrefs.GetInt("HighScore", 0);
            if(crate.score > highScoreTextNumber) PlayerPrefs.SetInt("HighScore", crate.score);
            highScoreText.text = highScoreTextNumber.ToString();

            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        }


        //update score 
        if (crate.scoreUpdated)
        {
            scoreText.text = crate.score.ToString();
        }




    }
}
