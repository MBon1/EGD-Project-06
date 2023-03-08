using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 64;

    [Space(10)]
    int micIndex = 0;
    private AudioClip microphoneClip;

    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[micIndex];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);        // Look more into AudioSettings
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[micIndex]), microphoneClip);
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
