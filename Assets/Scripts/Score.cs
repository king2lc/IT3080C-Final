using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score;

    void OnDestroy()
    {
        score = score + 1;
    }
}
