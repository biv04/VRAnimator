using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterToggle : MonoBehaviour
{
     public GameObject[] lObject =  new GameObject[4];
	 public int selectedNum;
	 int currNum = 0;
	public bool debug;
    private void Start()
    {
		SetModel(currNum);
	}
    void Update(){
        if (debug)
        {
			if (Input.GetKeyDown(KeyCode.Keypad0)) selectedNum = 0;
			if (Input.GetKeyDown(KeyCode.Keypad1)) selectedNum = 1;
			if (Input.GetKeyDown(KeyCode.Keypad2)) selectedNum = 2;
			if (Input.GetKeyDown(KeyCode.Keypad3)) selectedNum = 3;
			SetModel(selectedNum);
		}
		
		 
	 
	 }
	 
	 void SetModel(int n){
		for (int i = 0; i < lObject.Length; i++) {
			if (i == n) {
				lObject[i].transform.position = new Vector3(0, lObject[i].transform.position.y, lObject[i].transform.position.z);
			} 
			else {
				lObject[i].transform.position = new Vector3(-1000, lObject[i].transform.position.y, lObject[i].transform.position.z);
			}
		}
	 
	 }

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name == "Hand_IndexTip")
		{
			currNum = selectedNum;
			SetModel(currNum);
		}

	}
}
