using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null && player.checkpointIndex == checkpoints.Count)
        {
            player.checkpointIndex = 0;
            player.lapNumber++;

            Debug.Log("Lap " + player.lapNumber + " / " + totalLaps);

            if (player.lapNumber > totalLaps)
            {
                // End Race
                Debug.Log("Race End");
            }
        }
    }
}