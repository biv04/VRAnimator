using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoButton : MonoBehaviour
{
    //Prefabs
    public GameObject Prefabs;
    private GameObject hand;


    bool isCreating;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCreating)
        {
            GameObject newItem = Instantiate(Prefabs, hand.transform.position, Quaternion.identity);
            isCreating = false;
            //newItem.transform.parent = gameObject.transform;
           
        } 
    }

  

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggerd" + other.gameObject.name);
        if(other.gameObject.name == "Hand_IndexTip")
        {
            Debug.Log("Initiate at HandPos");

            isCreating = true;
            hand = other.gameObject;

        }

    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(this.gameObject, transform.position, Quaternion.identity);
    }
}
