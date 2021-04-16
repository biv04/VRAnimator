using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoButton : MonoBehaviour
{
    //Prefabs
    public GameObject Prefabs;
    public GameObject grid;
    public GameObject spawnPoint;
    GameObject plane;


    bool isCreating;


    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("SmallPlane");
    }

    // Update is called once per frame
    void Update()
    {
        if (isCreating)
        {

            GameObject newItem = Instantiate(Prefabs, spawnPoint.transform.position, Quaternion.identity);
            isCreating = false;
        } 
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hand_IndexTip")
        {
            Debug.Log("Initiate at HandPos");

            isCreating = true;
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
