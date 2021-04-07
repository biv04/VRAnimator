using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHeader : MonoBehaviour
{
    public GameObject LoadPanel, PresetPanel;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip")
        {
            if (gameObject.name == "PresetHit")
            {
                PresetPanel.SetActive(true);
                LoadPanel.SetActive(false);

            }
            if (gameObject.name == "LoadHit")
            {
                PresetPanel.SetActive(false);
                LoadPanel.SetActive(true);

            }
        }

    }
}

