using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{    //This Scrip will handle the respawning of the player. It will be the check if the player is alive or not.
    [Header("Respawn Location")]
    [Tooltip("The spot we will the play to be moved to after he has died.")]
    public Vector3 respawn; // The spot we will the play to be moved to after he has died.
    [Header("Respawn Effects")]
    public GameObject deathParticles;// The effect that will be released when the player dies.
    public GameObject respawnParticles;// The effect that will be released when the player comes back to life.
    public GameObject playersRender;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bad Thing")
        {
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(Dead());
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        playersRender.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<PlayerController>().alive = false;
    }
    IEnumerator Dead()
    {
        Debug.Log("I'm dead");
        yield return new WaitForSeconds(1);
        RespawnPlayer();
    }
    void RespawnPlayer()
    {
        transform.position = respawn;
        Instantiate(respawnParticles, transform.position, Quaternion.identity);
        playersRender.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<PlayerController>().alive = true;
    }
}