using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableUpdating : MonoBehaviour
{
    public AudioClip collectingSound;

    private bool collected;

    public Transform trackingTarget;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;
    [SerializeField]
    float followSpeed;
    public PlayerController playerController;
    public bool isZoomedOout;

    private void Update()
    {
        if(collected == true)
        {
            if (playerController.facingRight == true)
            {
                float xTarget = trackingTarget.position.x + xOffset;
                float yTarget = trackingTarget.position.y + yOffset;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

                transform.position = new Vector3(xNew, yNew, transform.position.z);
            }
            else if (playerController.facingRight == false)
            {
                float xTarget = trackingTarget.position.x + -xOffset;
                float yTarget = trackingTarget.position.y + yOffset;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

                transform.position = new Vector3(xNew, yNew, transform.position.z);
            }

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySingle(collectingSound);
        collected = true;
        CollectableScoring.theScore += 1;
        StartCoroutine(Collected());
    }

    IEnumerator Collected()
    {
        Debug.Log("Starting");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
