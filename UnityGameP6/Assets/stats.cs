using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "coinstext")
        {
            GetComponent<TextMesh>().text = "Coins :" + GM.coinTotal;
        }
        if (gameObject.name == "timetext")
        {
            GetComponent<TextMesh>().text = "Time: " + Mathf.Round(GM.timeTotal * 100f) / 100f + "s";
        }
        if (gameObject.name == "runstatus")
        {
            GetComponent<TextMesh>().text = GM.lvlCompStatus;
        }
    }
}
