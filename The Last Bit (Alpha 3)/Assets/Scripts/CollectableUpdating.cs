using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableUpdating : MonoBehaviour
{
    public AudioClip collectingSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySingle(collectingSound);
        CollectableScoring.theScore += 1;
        Destroy(gameObject);
    }
}
