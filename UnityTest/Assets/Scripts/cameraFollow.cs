using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float sensitivity;
    public Transform playerTransform;
    public Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + cameraOffset;
        //float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        //transform.Rotate(Vector3.up, mouseX, Space.World);
    }
}
