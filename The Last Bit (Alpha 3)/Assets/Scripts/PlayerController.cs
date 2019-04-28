using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //This scripts holds everything that's going on with the player
    public bool finshed;
    public bool grounded;
    public bool candoublejump;
    public bool facingRight;// The Checkbox that tells which way the player is facing
    public bool alive;// The Checkbox that is to tell if the player is alive or not.

    void Start()
    {
        finshed = false;
        alive = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Check if Grounded
    private void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
