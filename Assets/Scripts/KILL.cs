using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILL : MonoBehaviour
{
    public UI ui;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ui.LoseLife();
        Debug.Log("KILL SENT");
    }

}
