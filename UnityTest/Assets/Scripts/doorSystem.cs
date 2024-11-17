using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class doorSystem : MonoBehaviour
{

    public PlayerController playerController;
    public bool is_closed = true;
    public TextMeshProUGUI hints;
    public GameObject leftdoor;
    public GameObject rightdoor;
    // Start is called before the first frame update
    void Start()
    {
        hints.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (is_closed)
                {
                    Debug.Log("Otwiera siê");
                    is_closed = false;
                    leftdoor.transform.Translate(-2, 0, 0);
                    rightdoor.transform.Translate(2, 0, 0);
                }
                else
                {
                    Debug.Log("Zamyka siê");
                    is_closed = true;
                    leftdoor.transform.Translate(2, 0, 0);
                    rightdoor.transform.Translate(-2, 0, 0);
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hints.text = "Press E to Interact (Try it a few times)";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hints.text = "";
        }
    }
}
