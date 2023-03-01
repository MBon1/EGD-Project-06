using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 64;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        
        if (startPosition < 0)
        {
            return 0;
        }
        
        float[] wavData = new float[sampleWindow];
        clip.GetData(wavData, startPosition);

        // Compute Loudness (average amplitude)
        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            // Value of wave data ranges from -1 to 1
            // 0 = No Sound
            totalLoudness += Mathf.Abs(wavData[i]);
        }

        return totalLoudness / sampleWindow;
    }
}
