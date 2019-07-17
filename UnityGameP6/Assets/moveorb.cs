using System.Collections;
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

    public Transform boomObj;

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
        if (gameObject.name == "Player")
        {
            transform.Rotate(3, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "lethal")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            Destroy(gameObject);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.lvlCompStatus = "Fail";

        }

        if (other.gameObject.name == "Capsule")
        {
            FindObjectOfType<AudioManager>().Play("PowerUp");
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
            GM.lvlCompStatus = "Success!";
            SceneManager.LoadScene("levelcomplete");
        }
        if (other.gameObject.name == "coin")
        {
            FindObjectOfType<AudioManager>().Play("CoinSound");
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
