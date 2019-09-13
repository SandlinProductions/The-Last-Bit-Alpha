using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectableScoring : MonoBehaviour
{
    public GameObject scoreText;
    public float maxScore;
    public static int theScore;
    private float percent;

    private void Start()
    {
        theScore = 0;
    }
    private void Update()
    {
        percent = (theScore / maxScore)*100;
        scoreText.GetComponent<Text>().text = percent.ToString("f1") + "%";
    }
    
}
