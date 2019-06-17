using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject finishMenu;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Finish();
        }
    }
    void Finish()
    {
        playerController.finshed = true;
        finishMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
