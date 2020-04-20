using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {

  //  public GameObject btd;
   // public Text countText;
   // public Text winText;
    public int count;

    private void Start()
    {
        count = 0;
       // SetCountText();
      //  winText.text = "";
    }
    // Update is called once per frame
    void Update () {
        if (count >= 1)
        {
            // winText.text = "You Win!";
            Debug.Log("Ayy lmao.");
            Application.Quit();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
        {
            Destroy(collision.gameObject);
         //   Destroy(btd);
            count += 1;
            Application.Quit();
           // SetCountText();
            //Debug.Log("Please sir.");

        }



        //else
        //{
        //    Destroy(btd);
        //}
    }
    /*void SetCountText()
    {
        //countText.text = "Count: " + count.ToString();
        if (count >= 4)
        {
            winText.text = "You Win!";
            Debug.Log("Ayy lmao.");
        }
    }*/


}
