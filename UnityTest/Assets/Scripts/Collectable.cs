using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI hints;
    public AudioSource playerSounds;
    public AudioClip charging;
    public AudioClip finishedCharging;
    public AudioSource generatorSource;
    public AudioClip generatorSounds;
    public Light generatorLight;
    float chargeLevel = 0;
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
            hints.text = "Hold E to Charge";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                new WaitForSeconds(0.5f);
                if (chargeLevel != 100)
                {
                    generatorSource.pitch = 1+chargeLevel/1000;
                    generatorSource.PlayOneShot(charging, 0.1f);
                    chargeLevel++;
                    hints.text = "Hold E to Charge (" + chargeLevel + "%)";
                }
                else
                {
                    generatorLight.color = Color.green;
                    generatorSource.pitch = 1;
                    generatorSource.PlayOneShot(finishedCharging);
                    generatorSource.loop = true;
                    generatorSource.clip = generatorSounds;
                    generatorSource.Play();
                    playerController.zebranePunkty++;
                    hints.text = "";
                    Destroy(this.gameObject);
                }
            } else
            {
                chargeLevel = 0;
                hints.text = "Hold E to Charge";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hints.text = "";
            chargeLevel = 0;
        }
    }
}
