using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour
{

    public PlayerController playerController;
    public AudioSource audioSource;
    public AudioClip victoryAudio;
    public AudioClip wrongAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerController.zebranePunkty == playerController.maxPunkty)
            {
                audioSource.PlayOneShot(victoryAudio);
                Debug.Log("Zebrano wszystkie monetki! Wygrywasz!");
            }
            else
            {
                audioSource.PlayOneShot(wrongAudio);
                Debug.Log("Brakuje monetek!");
            }
        }
    }
}
