using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] Image fill;
    [SerializeField] Text valTxt;

    public HandGrabbing handR;
    public GameObject player;

    Vector3 mousePos;
    Vector3 handPos;

    public bool isDrag;

    private void Update()
    {
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
        //mousePos = Input.mousePosition;
        Vector2 dir = handPos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;
        if(angle<225 || angle >= 315)
        {
            Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
            handle.localRotation = r;
            angle = ((angle >= 315) ? (angle - 360) : angle) + 45;
            fill.fillAmount = 0.75f - (angle / 360f);
            valTxt.text = Mathf.Round((fill.fillAmount * 100) / 0.75f).ToString();
        }
    }
}
