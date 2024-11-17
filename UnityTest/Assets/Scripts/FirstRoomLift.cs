using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoomLift : MonoBehaviour
{
    public float startPoint;
    public float endPoint;
    public int speed;
    public bool isMoving = true;
    public AudioSource audioSource;
    public AudioSource glados;
    public AudioClip introduce;
    public AudioClip endLifting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(0, 1 * Time.deltaTime * speed, 0);
            if (transform.position.y >= endPoint)
            {
                isMoving = false;
                audioSource.Stop();
                audioSource.PlayOneShot(endLifting, 0.2f);
                glados.PlayOneShot(introduce);
            }
        }
    }
}
