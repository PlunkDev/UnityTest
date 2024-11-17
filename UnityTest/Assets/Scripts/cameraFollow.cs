using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float sensitivity;
    public Transform playerTransform;
    public Vector3 cameraOffset;
    private float yaw = 0f;
    private float pitch = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        transform.position = playerTransform.position + cameraOffset;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -40f, 40f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        transform.position = playerTransform.position + rotation * cameraOffset;
        transform.LookAt(playerTransform.position);
    }
}
