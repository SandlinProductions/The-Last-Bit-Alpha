using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestoryEffects : MonoBehaviour
{
    //this is mainy for all the effects to AutoDestory so it doesn't clog up all the memory
    public float delaytime = 0.5f;

    void OnEnable()
    {
        StartCoroutine("CheckIfAlive");
    }

    IEnumerator CheckIfAlive()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaytime);
            if (!GetComponent<ParticleSystem>().IsAlive(true))
                Destroy(gameObject);

        }
    }
}
