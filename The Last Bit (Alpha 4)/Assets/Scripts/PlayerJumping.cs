using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    //This contains everything related to jumpinp
    public PlayerController PlayerController;
    public float jump;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public GameObject BigJumpingParticles;

    private void Start()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    void Update()
    {

        if (GetComponent<PlayerController>().alive == true)
        {
            if (Input.GetButtonDown("Jump") && Input.GetAxis("Vertical") > .5 && Input.GetAxis("Horizontal") == 0 && GetComponent<PlayerController>().grounded == true)
            {
                MoveBack();
            }
            else if (Input.GetButtonDown("Jump") & Input.GetAxis("Vertical") < -.5 && Input.GetAxis("Horizontal") == 0 & GetComponent<PlayerController>().grounded == true)
            {
                MoveFront();
            }
            else if (Input.GetButtonDown("Jump"))
            {
                Jumping();
            }

        }
    }
    void MoveBack()
    {
        GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        Debug.Log("am I moving back?");
    }
    void MoveFront()
    {
        GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        Debug.Log("am I moving forwards?");
    }
    void Jumping()
    {
        if (GetComponent<PlayerController>().grounded == true)
        {
            GetComponent<PlayerController>().candoublejump = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jump;
        }
        else
        {
            if (GetComponent<PlayerController>().candoublejump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                Instantiate(BigJumpingParticles, transform.position, Quaternion.identity);
                GetComponent<PlayerController>().candoublejump = false;
            }
        }

        // this part is for the mario type of jumping when the player falls quicker then jumping
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (GetComponent<Rigidbody2D>().velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
