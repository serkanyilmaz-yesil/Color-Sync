using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl ctrl;


    [HideInInspector]
    public GameObject selectedObject;

    public GameObject char1,char2,char3;
    public Vector3 startChar1, startChar2, startChar3;
    public Vector3 activePos;

    public bool tap, left, middle, right, play, wrpEffect, explo, controlReset;

    private float y;

    public int fastControl;
    public GameObject warpEffect,explosion;



    private void Awake()
    {
        ctrl = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        tap = false;
        y = transform.position.y + 0.5f;
        startChar1 = char1.transform.position;
        startChar2 = char2.transform.position;
        startChar3 = char3.transform.position;
        left = false;
        middle = false;
        right = false;
        play = true;
        wrpEffect = false;
        explo = false;
        controlReset = false;
    }

    private void Update()
    {
        if (fastControl == 3)
        {


            CamControl.cam.fast = true;
            CamControl.cam.time = 3f;
            RoadPosition.road.time = 3;
            if (!wrpEffect)
            {
                Instantiate(warpEffect, new Vector3(transform.position.x,transform.position.y,transform.position.z + 20) , Quaternion.identity);
            }

            fastControl = 0;
        }

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Input.GetMouseButton(0)) tap = true;


        if (play )
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (Input.GetMouseButton(0))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        if (selectedObject == null)
                        {
                            selectedObject = hit.collider.gameObject;
                            selectedObject.gameObject.tag = "ActivePlayer";
                        }

                    }

                }
                if (selectedObject != null && !controlReset)
                {
                    selectedObject.transform.position = new Vector3(hit.point.x, y, selectedObject.transform.position.z);

                }


            }

            if (!Input.GetMouseButton(0) && selectedObject != null)
            {
                selectedObject.gameObject.tag = "Player";
            }

            if (Input.GetMouseButtonUp(0))
            {
                selectedObject = null;
            }


        }

        RaycastHit dist;
        if (Physics.Raycast(transform.position, Vector3.forward, out dist, 1000))
        {

            Vector3 distance = dist.collider.transform.position - transform.position;

            if (distance.z < 1.5 && !explo)
            {
                Instantiate(explosion, transform);
                explo = true;
            }
            else
                explo = false;

        }




    }


}
