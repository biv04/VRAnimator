using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxToggle : MonoBehaviour
{
	public Material skyBox;
	public Transform environment;
	bool isOn;
	int numOfChildren;
	float exposure;
	float duration = 15f;

    // Start is called before the first frame update
    void Start()
    {
		numOfChildren = environment.childCount;
        RenderSettings.skybox = skyBox;
		RenderSettings.skybox.SetFloat("_Exposure", exposure);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
			if(!isOn){
				//Fade in
				StartCoroutine(FadeIn());
				StartCoroutine(ShowObjects());
				isOn = true;
			}
		
			else{
				//Fade out
				StartCoroutine(FadeOut());
				StartCoroutine(HideObjects());
				isOn = false;
			
			}
			

		}
		
		DynamicGI.UpdateEnvironment();

    }
	
	IEnumerator FadeIn(){
		for(int i = 0; i<7; i++){
			yield return new WaitForSeconds(0.05f);
			exposure += 0.2f;
			RenderSettings.skybox.SetFloat("_Exposure", exposure);

		}
		
	  }

	
	IEnumerator FadeOut(){
		for(int i = 0; i<7; i++){
			yield return new WaitForSeconds(0.05f);
			exposure -= 0.2f;
			RenderSettings.skybox.SetFloat("_Exposure", exposure);
		}
		
	  }
	  
	  IEnumerator ShowObjects(){
		for(float f = 0f; f< 1f; f+= 0.05f){
			for(int i = 0; i< numOfChildren; i++){
				GameObject child = environment.GetChild(i).gameObject;
				for(int j = 0; j < child.GetComponent<MeshRenderer>().materials.Length; j++){
				Color c = child.GetComponent<MeshRenderer>().materials[j].color;
				c.a = f;
				child.GetComponent<MeshRenderer>().materials[j].color = c;
				}

			}
			yield return new WaitForSeconds(0.02f);
	
		}
	  }
	  
	  IEnumerator HideObjects(){
		
		for(float f = 1f; f>= -0.05f; f-= 0.05f){
			for(int i = 0; i< numOfChildren; i++){
				GameObject child = environment.GetChild(i).gameObject;
				for(int j = 0; j < child.GetComponent<MeshRenderer>().materials.Length; j++){
				Color c = child.GetComponent<MeshRenderer>().materials[j].color;
				c.a = f;
				child.GetComponent<MeshRenderer>().materials[j].color = c;
				}
				
				
			}
			yield return new WaitForSeconds(0.02f);

		}
	  }
	  
	 

}
