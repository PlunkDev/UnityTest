using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public PlayerController playerController;
    public bool isTrigger;
    public TextMeshProUGUI hints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                playerController.isSmall = !playerController.isSmall;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTrigger = true;
            hints.text = "Press E to Interact";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTrigger = false;
            hints.text = "";
        }
    }
}
