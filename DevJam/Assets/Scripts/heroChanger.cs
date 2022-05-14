using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroChanger : MonoBehaviour
{
    public GameObject[] heros;
    public int arrayNumber = 1, lastArrayNumber;

    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        whichArray();
        
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
    }
}
