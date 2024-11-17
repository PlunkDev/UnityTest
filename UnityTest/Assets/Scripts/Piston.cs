using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Piston : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform piston;
    public int speed;
    public bool isMoving;
    public bool isBack;
    public int xMove;
    public int yMove;
    public int zMove;
    int charge = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            speed = 15;
            piston.Translate(xMove * Time.deltaTime * speed, yMove, zMove);
            if (piston.position.x > endPos.position.x) 
            {
                isMoving = false;
                isBack = true;
            }
        }
        if (isBack)
        {
            speed = 5;
            piston.Translate(-xMove * Time.deltaTime * speed, -yMove, -zMove);
            if (piston.position.x < startPos.position.x) 
            {
                isBack = false;
            }
        }
        if(!isMoving && !isBack) 
        {
            if (charge < 500)
            {
                charge++;
            }
            else
            {
                isMoving = true;
                charge = 0;
            }
        }
    }
}
