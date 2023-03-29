using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxesVisualizer : MonoBehaviour
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    float horizontalInput;
    float verticalInput;

    [SerializeField] bool useBalanceBoardControls = true;
    [SerializeField] GameObject knob;

    RectTransform knobTransform;

    float horizontalUnit = 0;
    float verticalUnit = 0;


    private void Start()
    {
        Rect rect = this.GetComponent<RectTransform>().rect;
        horizontalUnit = rect.width / 2;
        verticalUnit = rect.height / 2;

        knobTransform = knob.GetComponent<RectTransform>();

    }

    void FixedUpdate()
    {
        GetInput();

        Vector2 newPos = new Vector2(horizontalInput * horizontalUnit, verticalInput * verticalUnit);

        knobTransform.localPosition = newPos;
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
}
