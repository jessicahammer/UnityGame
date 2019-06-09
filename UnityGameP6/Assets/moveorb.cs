﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorb : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, 4);
        if ((Input.GetKeyDown(moveL)) && (laneNum>1) && (controlLocked == "n"))
        {
            horizVel = -2;
            StartCoroutine (stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }
        if ((Input.GetKeyDown(moveR)) && (laneNum < 3 ) && (controlLocked == "n"))
        {
            horizVel =  2; 
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
                 
        }

        if (other.gameObject.name == "Capsule")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "rampbottomtrigger")
        {
            GM.vertVel = 2;
        }
        if (other.gameObject.name == "ramptoptrigger")
        {
            GM.vertVel = 0;
        }
        if (other.gameObject.name == "exit")
        {
            SceneManager.LoadScene("levelcomplete");
        }
        if (other.gameObject.name == "coin")
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }

    }

    IEnumerator stopSlide ()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = "n";

    }
}
