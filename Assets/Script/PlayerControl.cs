using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] float xThrowSpeed = 10f;
    [SerializeField] float yThrowSpeed = 10f;

    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;



    float xThrow, yThrow;

    void Update()
  {
    ProcessTranslation();
    ProcessRotation();
  }

  void ProcessRotation()
  {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

  }

  void ProcessTranslation()
  {
    xThrow = Input.GetAxis("Horizontal");
    yThrow = Input.GetAxis("Vertical");

    float xOffset = xThrow * Time.deltaTime * xThrowSpeed;
    float rawXPos = transform.localPosition.x + xOffset;
    float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

    float yOffset = yThrow * Time.deltaTime * yThrowSpeed;
    float rawYPos = transform.localPosition.y + yOffset;
    float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

    transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
  }
}
