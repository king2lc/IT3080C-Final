﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingScript : MonoBehaviour
{
    public PostProcessVolume volume;
    private Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        vignette.smoothness.value = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            vignette.smoothness.value = 1f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            vignette.smoothness.value = .6f;
        }
    }
}
