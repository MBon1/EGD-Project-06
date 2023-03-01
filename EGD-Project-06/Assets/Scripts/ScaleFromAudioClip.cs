using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detection;

    public float loudest = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amplitude = detection.GetLoudnessFromAudioClip(source.timeSamples, source.clip);

        if (amplitude > loudest)
        {
            loudest = amplitude;
        }

        transform.localScale = Vector3.Lerp(minScale, maxScale, amplitude);

        Debug.Log(amplitude);
    }
}
