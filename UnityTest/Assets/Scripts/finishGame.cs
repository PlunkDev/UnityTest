using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishGame : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject leftdoor;
    public GameObject rightdoor;
    public string nextScene;
    bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.zebranePunkty == playerController.maxPunkty)
        {
            if(!opened)
            {
                leftdoor.transform.Translate(2, 0, 0);
                rightdoor.transform.Translate(-2, 0, 0);
                opened = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Wygra³eœ!");
            SceneManager.LoadScene(nextScene);
        }
    }
}
