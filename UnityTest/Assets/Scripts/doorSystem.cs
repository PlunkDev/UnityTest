using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorSystem : MonoBehaviour
{
    public PlayerController playerController;
    public AudioSource AudioSource;
    public AudioClip clip;
    public bool is_closed = true;
    public TextMeshProUGUI hints;
    public GameObject leftdoor;
    public GameObject rightdoor;
    public GameObject leftOpen;
    public GameObject rightOpen;
    public GameObject leftClosed;
    public GameObject rightClosed;

    bool isOnTrigger = false;

    // Prêdkoœæ przesuwania drzwi
    public float doorSpeed = 1.0f;

    void Start()
    {
        hints.text = "";
    }

    void Update()
    {
        if (isOnTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioSource.PlayOneShot(clip);
                is_closed = !is_closed;
            }
        }

        if (is_closed)
        {
            MoveDoor(leftdoor, leftClosed.transform.position);
            MoveDoor(rightdoor, rightClosed.transform.position);
        }
        else
        {
            MoveDoor(leftdoor, leftOpen.transform.position);
            MoveDoor(rightdoor, rightOpen.transform.position);
        }
    }

    void MoveDoor(GameObject door, Vector3 targetPosition)
    {
        door.transform.position = Vector3.MoveTowards(
            door.transform.position,
            targetPosition,
            doorSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOnTrigger = true;
            hints.text = "Press E to Interact";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOnTrigger = false;
            hints.text = "";
        }
    }
}