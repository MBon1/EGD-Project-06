using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            if (player.checkpointIndex == index - 1)
                player.checkpointIndex = index;
            else
                Debug.Log("YOU'RE GOING THE WRONG WAY!!!");
        }
    }
}
