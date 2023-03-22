using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMessage : MonoBehaviour
{
    public GameObject stumpMessageObject;
    public GameObject rockMessageObject;
    public GameObject stickMessageObject;
    public GameObject ivyMessageObject;

    private bool stumpMessageDisplayed = false;
    private bool rockMessageDisplayed = false;
    private bool stickMessageDisplayed = false;
    private bool ivyMessageDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClearMessage();
    }

    public void DisplayMessage()
    {
        if (this.gameObject.tag == "Stump" && !stumpMessageDisplayed)
        {
            stumpMessageObject.SetActive(true);
            stumpMessageDisplayed = true;
        }
        else if (this.gameObject.tag == "Rock" && !rockMessageDisplayed)
        {
            rockMessageObject.SetActive(true);
            rockMessageDisplayed = true;
        }
        else if (this.gameObject.tag == "Stick" && !stickMessageDisplayed)
        {
            stickMessageObject.SetActive(true);
            stickMessageDisplayed = true;
        }
        else if (this.gameObject.tag == "Ivy" && !ivyMessageDisplayed)
        {
            ivyMessageObject.SetActive(true);
            ivyMessageDisplayed = true;
        }
    }

    public void ClearMessage()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stumpMessageObject.SetActive(false);
            rockMessageObject.SetActive(false);
            stickMessageObject.SetActive(false);
            ivyMessageObject.SetActive(false);
        }
    }
}
