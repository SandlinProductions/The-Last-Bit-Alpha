using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This contains all the players movement
    public PlayerController PlayerController;
    public float moveVelocity;
    public float moveForce;
    public float maxSpeed;
    public float timeForce;
    //FixedUpdate works best for physics
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");

        // The Speed animator parameter is set to the absolute value of the horizontal input.


        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            // ... add a force to the player.
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (moveVelocity > 0 && !GetComponent<PlayerController>().facingRight)
            // ... flip the player.
            Flip();
        else if (moveVelocity < 0 && GetComponent<PlayerController>().facingRight)
            // ... flip the player.
            Flip();

        if (Input.GetAxis("Horizontal") > 0 && !GetComponent<PlayerController>().facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Input.GetAxis("Horizontal") < 0 && GetComponent<PlayerController>().facingRight)
            // ... flip the player.
            Flip();

        // When Time Slows down, this will move the player faster for a more precise movement.
        if (Time.timeScale == 0.2F)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce * timeForce);
        }


        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, 0f, 1f));

    }
    void Flip()
    {
        // Switch the way the player is labelled as facing.
        GetComponent<PlayerController>().facingRight = !GetComponent<PlayerController>().facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
