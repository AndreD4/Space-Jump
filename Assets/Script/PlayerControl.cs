using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] float xThrowSpeed = 10f;
    [SerializeField] float yThrowSpeed = 10f;

    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float xThrow = Input.GetAxis("Horizontal");
       float yThrow = Input.GetAxis("Vertical");
      
      float xOffset = xThrow * Time.deltaTime * xThrowSpeed;
      float rawXPos = transform.localPosition.x + xOffset;
      float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

      float yOffset = yThrow * Time.deltaTime * yThrowSpeed;
      float rawYPos = transform.localPosition.y + yOffset;
      float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        
      transform.localPosition = new Vector3 (clampXPos,clampYPos,transform.localPosition.z);
    }
}
