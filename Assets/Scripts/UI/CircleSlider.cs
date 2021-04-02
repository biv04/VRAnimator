using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] Image fill;
    [SerializeField] Text valTxt, jointName;

    public int LoopNum ;
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

    public GameObject ColliderLeft, ColliderRight;
    private void Start()
    {
        LoopNum = 0;
        frameCubes = new GameObject[24];
        CreateFramesAroundPoint(24, gameObject.transform.position, 0.085f);

        Vector3 eulers = this.transform.rotation.eulerAngles;
        parent.transform.localRotation = Quaternion.Euler(new Vector3(33f, 180f, eulers.z));
    }
    private void Update()
    {
        int tempFrame = frameNum - 24 * LoopNum;
        tempFrame = Clamp(tempFrame);

        for (int i = tempFrame; i<24; i++){

            if (frameCubes[i].GetComponent<MeshRenderer>().material.color  == HightlightMat.color)
            {
				// Debug.Log("PLEASEEEE WORKKKKKKKK " + i);
			}
			else
				DefaultColor(i);
				
		}

       
        for (int i = 0; i<=tempFrame; i++){

			if(frameCubes[i].GetComponent<MeshRenderer>().material.color == HightlightMat.color){
				//Debug.Log("There is a key at frame " + i);
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
        Vector2 dir = handPos - handle.position;
        //Debug.Log("OriginalDir" + dir);
        //dir = dir * 10;
        //Debug.Log("NewDir"+dir);


        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;

        if (angle <= 225 || angle >= 315)
        {
            ColliderLeft.SetActive(true);
            ColliderRight.SetActive(true);
        }

        Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);

            handle.localRotation = r;
            //Debug.Log("ANGLE: " + angle);

            angle = ((angle >= 315) ? (angle - 360) : angle) + 45;

            fill.fillAmount = 1f - (angle / 270);
            frameNum = (int)Mathf.Round((fill.fillAmount * 23) / 1f) + 24 * LoopNum ;
            valTxt.text = (frameNum+1).ToString();

    }


    private void CreateFramesAroundPoint(int num, Vector3 point, float radius)
    {

        for (int i = 0; i < num; i++)
        {


            /* Distance around the circle */
            var radians = 1.5f * Mathf.PI / num * i - Mathf.PI/4;
			//Debug.Log("FrameNum: " + i + "Rad: " + radians);
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
        int tempFrame = frameNum - 24 * LoopNum;
        tempFrame = Clamp(tempFrame);
        frameCubes[frameNum].GetComponent<MeshRenderer>().material = FillMat;
		//Debug.Log("Set Fill color for " + frameCubes[frameNum]);
	}
	
	public void HighlightKey(int frameNum){
        int tempFrame = frameNum - 24 * LoopNum;
        tempFrame = Clamp(tempFrame);

        frameCubes[tempFrame].GetComponent<MeshRenderer>().material = HightlightMat;
	}
	
	public void DefaultColor(int frameNum){
        int tempFrame = frameNum - 24 * LoopNum;
        tempFrame = Clamp(tempFrame);
        
        frameCubes[tempFrame].GetComponent<MeshRenderer>().material = DefaultMat;
	}

    public Color GetColor(int frameNum)
    {
        int tempFrame = frameNum - 24 * LoopNum;
        tempFrame = Clamp(tempFrame);
        return frameCubes[tempFrame].GetComponent<MeshRenderer>().material.color;
    }

    public Color HighLightColor()
    {
        return HightlightMat.color;
    }

    public void SetJointName(string name)
    {
        jointName.text = name;
    }
    public void increaseValue()
    {
        LoopNum++;
    }
    public void DecreaseValue()
    {
        LoopNum--;
    }

    int Clamp(int n)
    {
        if (n < 1)
            n = 1;

        if (n > 23)
            n = 23;

        return n;
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Handle"))
        {

            Debug.Log("Hit Object Name: " + collision.gameObject);
            LoopNum++;

        }
    }
    */
}
