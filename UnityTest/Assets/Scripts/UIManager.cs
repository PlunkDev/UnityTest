using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI score;
    public TextMeshProUGUI hints; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = playerController.zebranePunkty+"/"+playerController.maxPunkty;
    }
}
