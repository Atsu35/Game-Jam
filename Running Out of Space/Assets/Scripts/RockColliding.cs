using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColliding : MonoBehaviour
{
    public GameObject sharpStone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Boulder" && col.relativeVelocity.magnitude > 2f)
        {
            Debug.Log("aa");
            Instantiate(sharpStone, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
