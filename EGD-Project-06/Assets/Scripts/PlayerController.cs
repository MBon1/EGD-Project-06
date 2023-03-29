using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    float horizontalInput;
    float verticalInput;
    float currentMotorForce;
    float currentSteeringAngle;
    float currentBreakForce;

    [Header("Movement Variables")]
    [SerializeField] float motorForce = 5;
    [SerializeField] float breakForce = 5;
    [SerializeField] float maxSteeringAngle;
    [Space(10)]
    [SerializeField] AudioLoudnessDetection detection;
    [Space(10)]
    [SerializeField] bool useBalanceBoardControls = true;

    [Header("Wheels")]
    [SerializeField] WheelCollider frontLeftWheelCollider;
    [SerializeField] WheelCollider frontRightWheelCollider;
    [SerializeField] WheelCollider rearLeftWheelCollider;
    [SerializeField] WheelCollider rearRightWheelCollider;


    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        /*Vector3 move = new Vector3(Input.GetAxisRaw(HORIZONTAL), 0, Input.GetAxisRaw(VERTICAL)).normalized;
        Vector3 velocity = move * motorForce * Time.deltaTime;*/
        GetInput();
        HandleMotor();
        HandleSteering();
    }

    void GetInput()
    {
        if (useBalanceBoardControls)
        {
            horizontalInput = Input.GetAxisRaw(VERTICAL) * -1;
            verticalInput = Input.GetAxisRaw(HORIZONTAL);
        }
        else
        {
            horizontalInput = Input.GetAxisRaw(HORIZONTAL);
            verticalInput = Input.GetAxisRaw(VERTICAL);
        }
    }

    void HandleMotor()
    {
        currentMotorForce = (useBalanceBoardControls ? motorForce : motorForce / 2) * Mathf.Lerp(0, verticalInput, detection.GetLoudnessFromMic());
        frontLeftWheelCollider.motorTorque = currentMotorForce;
        frontRightWheelCollider.motorTorque = currentMotorForce;

        /*rearLeftWheelCollider.motorTorque = currentMotorForce;
        rearRightWheelCollider.motorTorque = currentMotorForce;*/

        // If force is in opposite direction than vertical input, breaking
        //currentBreakForce = 0;

    }

    void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
    }

    void HandleSteering()
    {
        currentSteeringAngle = maxSteeringAngle * horizontalInput;

        frontLeftWheelCollider.steerAngle = currentSteeringAngle;
        frontRightWheelCollider.steerAngle = currentSteeringAngle;
    }

    /// References: 
    ///     https://www.youtube.com/watch?v=F1JRy8nFTb4
    ///     https://www.youtube.com/watch?v=ehDRTdRGd1w
    ///     https://www.google.com/search?q=car+controls+unity&oq=car+controls+unity+&aqs=edge..69i57.2478j0j1&sourceid=chrome&ie=UTF-8#kpvalbx=_-Q8jZIqiH5uqptQP6sOcsAk_30
    ///     https://www.youtube.com/watch?v=IlqcaNkjMRY
    ///     https://www.youtube.com/watch?v=CBgtU9FCEh8
}
