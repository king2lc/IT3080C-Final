using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneSequence : MonoBehaviour
{
    public GameObject cam1;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine (TheSequence ());
    }
    IEnumerator TheSequence ()
    {
        yield return new WaitForSecondsRealtime(4);
        cam1.SetActive(false);
        audioSource.Play();
    }
}
