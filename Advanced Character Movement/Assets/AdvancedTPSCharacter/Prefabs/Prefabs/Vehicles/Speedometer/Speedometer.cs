using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f; // The maximum speed of the target ** IN KM/H **

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public TextMeshProUGUI speedLabel; // The label that displays the speed;
    public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    private void Update()
    {
        // 3.6f to convert in kilometers
        // ** The speed must be clamped by the car controller **
        speed = target.velocity.magnitude * 3.6f;

        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " km/h";
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}
