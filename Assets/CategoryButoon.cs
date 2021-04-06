using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryButoon : MonoBehaviour
{


    public GameObject Camping, Miscellaneous, Plants;

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
            if (gameObject.name =="CampingHit")
            {
                Camping.SetActive(true);
                Miscellaneous.SetActive(false);
                Camping.SetActive(false);
            }
            if (gameObject.name == "MisHit")
            {
                Camping.SetActive(false);
                Miscellaneous.SetActive(true);
                Plants.SetActive(false);
            }
            if (gameObject.name == "PlantsHit")
            {
                Camping.SetActive(false);
                Miscellaneous.SetActive(false);
                Plants.SetActive(true);
            }
            isCreating = false;

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip")
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
