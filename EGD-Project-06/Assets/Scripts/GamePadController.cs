using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Input.GetJoystickNames()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("X: " + Input.GetAxisRaw("Horizontal").ToString("0.00") + " | Y: " + Input.GetAxisRaw("Vertical").ToString("0.00") + " | (1): " + Input.GetButton("Fire1"));
    }
}
