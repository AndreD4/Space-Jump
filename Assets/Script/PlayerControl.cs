using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] float xThrowSpeed = 10f;
    [SerializeField] float yThrowSpeed = 10f;
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
      float newXPos = transform.localPosition.x + xOffset;

      float yOffset = yThrow * Time.deltaTime * yThrowSpeed;
      float newYPos = transform.localPosition.y + yOffset;
        
      transform.localPosition = new Vector3 (newXPos,newYPos,transform.localPosition.z);
    }
}
