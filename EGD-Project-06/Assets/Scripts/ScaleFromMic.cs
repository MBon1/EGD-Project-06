using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromMic : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detection;

    public float loudest = 0;

    public float loudnessSensibility = 1;
    public float threshold = 0f;

    
    void FixedUpdate()
    {
        float loudness = detection.GetLoudnessFromMic() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        if (loudness > loudest)
        {
            loudest = loudness;
        }

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);

        //Debug.Log(loudness);
    }
}
