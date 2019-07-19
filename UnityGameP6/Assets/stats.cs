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
            GetComponent<TextMesh>().text = " " + GM.coinTotal;
        }
        if (gameObject.name == "timetext")
        {
            GetComponent<TextMesh>().text = "" + Mathf.Round(GM.timeTotal * 1f) / 1f + "s";
        }
        if (gameObject.name == "runstatus")
        {
            GetComponent<TextMesh>().text = "Ohh no :( Try it again!";
        }
    }
}
