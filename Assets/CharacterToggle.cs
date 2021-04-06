using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterToggle : MonoBehaviour
{
     public GameObject[] lObject =  new GameObject[4];
	 public int selectedNum = 0;
	 
	 void Update(){
		 if (Input.GetKeyDown(KeyCode.Keypad0))  selectedNum = 0;
		 if (Input.GetKeyDown(KeyCode.Keypad1))  selectedNum = 1;
		 if (Input.GetKeyDown(KeyCode.Keypad2))  selectedNum = 2;
		 if (Input.GetKeyDown(KeyCode.Keypad3))  selectedNum = 3;
		 
		 SetModel(selectedNum);
		 
	 
	 }
	 
	 void SetModel(int n){
		for (int i = 0; i < lObject.Length; i++) {
			if (i == n) {
				lObject[i].SetActive(true);
			} 
			else {
				lObject[i].SetActive(false);
			}
		}
	 
	 }
}
