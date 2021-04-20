using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{
    public Text EndScore;
    public int score;
    
    // Update is called once per frame
    void Update()
    {
        score = healthScore.finalScore;
        EndScore.text = "Final Score: " + score.ToString();
    }
}
