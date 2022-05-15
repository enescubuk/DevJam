using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class heroChanger : MonoBehaviour
{
    public GameObject[] heros;
    public int arrayNumber = 1, lastArrayNumber;

    public GameObject cinemachineCam;

    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        whichArray();
        if (arrayNumber == 2)
        {
            heros[2].GetComponent<RabbitController>().isPlayingRabbit = true;
        }
        else
        {
            heros[2].GetComponent<RabbitController>().isPlayingRabbit = false;
        }
    }    
    void whichArray()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lastArrayNumber = arrayNumber;
            arrayNumber--;
            if (arrayNumber == -1)
            {
                arrayNumber = 2;
            }
            else if(arrayNumber == 3)
            {
                arrayNumber = 0;
            }   
            positionController();
        }
            if (Input.GetKeyDown(KeyCode.E))
            {
                lastArrayNumber = arrayNumber;
                arrayNumber++;
                if (arrayNumber == -1)
                {
                    arrayNumber = 2;
                }
                else if(arrayNumber == 3)
                {
                    arrayNumber = 0;
                }
                positionController();
        }
    }

    void positionController()
    {
        currentPos = heros[lastArrayNumber].transform.position;
        heros[lastArrayNumber].SetActive(false);
        heros[arrayNumber].SetActive(true);
        heros[arrayNumber].transform.position = currentPos;
        cinemachineCam.GetComponent<CinemachineVirtualCamera>().m_Follow = heros[arrayNumber].transform;
        bool spriteX;
        if (lastArrayNumber == 0)
        {
            spriteX = heros[lastArrayNumber].transform.GetChild(0).GetComponent<SpriteRenderer>().flipX;
        }
        else
        {
            spriteX = heros[lastArrayNumber].GetComponent<SpriteRenderer>().flipX;
        }
        
        if (arrayNumber == 0)
        {
            heros[arrayNumber].transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = spriteX;

        }
        else
        {
            heros[arrayNumber].GetComponent<SpriteRenderer>().flipX = spriteX;
        }
        
    }
}
