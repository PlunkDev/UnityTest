using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float speed = 1.0f;
    public int zebranePunkty;
    public int maxPunkty;
    public Rigidbody rigidbody;
    public Transform startPoint;
    public Transform cam;
    public Transform checkpoint;
    public bool isSmall;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSmall)
        {
            rigidbody.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        } else
        {
            rigidbody.transform.localScale = new Vector3(1, 1, 1);
        }

        // MOVEMENT
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {

            Vector3 cameraForward = cam.forward;
            Vector3 cameraRight = cam.right;


            cameraForward.y = 0;
            cameraRight.y = 0;


            cameraForward.Normalize();
            cameraRight.Normalize();


            Vector3 moveDirection = cameraForward * vertical + cameraRight * horizontal;


            rigidbody.AddForce(moveDirection * speed * Time.deltaTime, ForceMode.Impulse);
        }
        //if (transform.position.y < 0)
        //{
        //  transform.position = startPoint.position;
        //rigidbody.velocity = Vector3.zero;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            transform.position = checkpoint.position;
        }
    }
}
