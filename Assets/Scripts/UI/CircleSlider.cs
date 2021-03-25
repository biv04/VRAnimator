using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] Image fill;
    [SerializeField] Text valTxt;
    public int frameNum;

    public HandGrabbing handR;
    public GameObject player;

    Vector3 mousePos;
    Vector3 handPos;

    public bool isDrag;
    public GameObject framePrefab;
    public GameObject parent;

    public GameObject[] frameCubes;
	public Material DefaultMat, FillMat, HightlightMat;
    private void Start()
    {
        frameCubes = new GameObject[24];
        CreateFramesAroundPoint(24, gameObject.transform.position, 0.085f);

        Vector3 eulers = this.transform.rotation.eulerAngles;
        parent.transform.localRotation = Quaternion.Euler(new Vector3(33f, 180f, eulers.z));
    }
    private void Update()
    {
		for(int i = frameNum; i<24; i++){
			if(frameCubes[i].GetComponent<MeshRenderer>().material == HightlightMat){
				 Debug.Log("There is a key at frame " + i);
			}
			else
				DefaultColor(i);
				
		}
		for(int i = 0; i<=frameNum; i++){

			if(frameCubes[i].GetComponent<MeshRenderer>().material == HightlightMat){
				Debug.Log("There is a key at frame " + i);
			}
			else
				HighlightFrame(i);
				
		}
			

        if (isDrag)
        {
            onHandleDrag();
			
        }

        if (handR.isPinch == false)
            isDrag = false;

        //Follow player
        //Debug.Log("Distance between circle and player: " + (this.gameObject.transform.position.z - player.transform.position.z));
        if ((this.gameObject.transform.position.z - player.transform.position.z) > 400)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 200);
        }
		

    }

    public void onHandleDrag()
    {
        handPos = handR.transform.position;
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        //Debug.Log("OriginalDir" + dir);
        //dir = dir * 10;
        //Debug.Log("NewDir"+dir);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;
        if (angle <= 225 || angle >= 315)
        {
            Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);

            handle.localRotation = r;
            //Debug.Log("ANGLE: " + angle);

            angle = ((angle >= 315) ? (angle - 360) : angle) + 45;

            fill.fillAmount = 1f - (angle / 270);
            frameNum = (int)Mathf.Round((fill.fillAmount * 23) / 1f);
            valTxt.text = (frameNum+1).ToString();
        }
    }

    private void CreateFramesAroundPoint(int num, Vector3 point, float radius)
    {

        for (int i = 0; i < num; i++)
        {


            /* Distance around the circle */
            var radians = 1.5f * Mathf.PI / num * i - Mathf.PI/4;
			Debug.Log("FrameNum: " + i + "Rad: " + radians);
			 if(i == 12){

				radians = radians + 0.01f;
				
			}
			
            /* Get the vector direction */
            var vertrical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector3(horizontal, vertrical, 0);
		   
            /* Get the spawn position */
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point
			
           
			/* Now spawn */
            var cube = Instantiate(framePrefab, spawnPos, Quaternion.identity) as GameObject;
			
            /* Rotate the enemy to face towards player */
            cube.transform.LookAt(point);
            cube.transform.name = "Frame" + i;
            cube.transform.SetParent(parent.transform);

            /* Adjust height */
            //cube.transform.Translate(new Vector3(0, cube.transform.localScale.y / 2, 0));
            
			
			frameCubes[i] = cube;
        }
    }

    private void HighlightFrame(int frameNum){
		frameCubes[frameNum].GetComponent<MeshRenderer>().material = FillMat;
		Debug.Log("Set Fill color for " + frameCubes[frameNum]);
	}
	
	public void HighlightKey(int frameNum){
		frameCubes[frameNum].GetComponent<MeshRenderer>().material = HightlightMat;
	}
	
	public void DefaultColor(int frameNum){
		frameCubes[frameNum].GetComponent<MeshRenderer>().material = DefaultMat;
	}
}
