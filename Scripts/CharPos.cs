using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPos : MonoBehaviour
{

    public static CharPos charPosition;
    public GameObject particle;

    public Vector3 startPos;
    public Vector3 nullPos;
    public float lerpSpeed;

    public bool change,leftPos,rightPos,middlePos,finishPos;

    public Transform left, middle, right;

    private Animator anim;

    public GameObject stickModel, ballModel1;

    private void Awake()
    {
        charPosition = this;
    }
    private void Start()
    {
        startPos = transform.position;
        nullPos = transform.position;
        change = false;
        leftPos = false;
        middlePos = false;
        rightPos = false;
        particle.SetActive(false);
        finishPos = false;
        anim = GetComponentInChildren<Animator>();

        stickModel.SetActive(true);
        ballModel1.SetActive(false);
    }

    private void Update()
    {
        if (PlayerControl.ctrl.play && PlayerControl.ctrl.tap)
        {
            particle.SetActive(true);
            anim.SetBool("idle", false);
            anim.SetBool("run", true);

        }
        else
        {
            particle.SetActive(false);
            anim.SetBool("idle", true);
            anim.SetBool("run", false);

        }


    }

    private void FixedUpdate()
    {
        if (!GameManager.gm.finish)
        {
            if (CamControl.cam.fast)
            {
                stickModel.SetActive(false);
                ballModel1.SetActive(true);

            }
            else
            {
                stickModel.SetActive(true);
                ballModel1.SetActive(false);

            }

        }

        else 
        {
            stickModel.SetActive(true);
            ballModel1.SetActive(false);

            anim.SetBool("idle", false);
            anim.SetBool("run", false);
            anim.SetBool("dance", true);

        }





        if (!GameManager.gm.finish)
        {
            if (change)
            {
                transform.position = Vector3.Lerp(transform.position, nullPos, lerpSpeed * Time.deltaTime);
                if (Input.GetMouseButtonUp(0))
                {
                    change = false;
                }
            }

            if (change && gameObject.tag != "ActivePlayer")
            {

                transform.position = Vector3.Lerp(transform.position, nullPos, lerpSpeed * Time.deltaTime);

            }

            if (!Input.GetMouseButton(0) && !change)
            {
                transform.position = Vector3.Lerp(transform.position, startPos, lerpSpeed * Time.deltaTime);

            }

        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left"))
        {
            startPos = other.transform.position;
        }
        if (other.CompareTag("Middle"))
        {
            startPos = other.transform.position;

        }
        if (other.CompareTag("Right"))
        {
            startPos = other.transform.position;

        }

        if (other.CompareTag("ActivePlayer"))
        {
            change = true;
            if (PlayerControl.ctrl.left)
            {
                nullPos = left.transform.position;
            }
            if (PlayerControl.ctrl.middle)
            {
                nullPos = middle.transform.position;
            }
            if (PlayerControl.ctrl.right)
            {
                nullPos = right.transform.position;
            }

        }

        if (other.CompareTag("FinishPos"))
        {
            finishPos = true;
            CamControl.cam.time = 6;
            RoadPosition.road.time = 6;

        }

        if (other.CompareTag("Finish"))
        {
            GameManager.gm.finish = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Left"))
        {
            PlayerControl.ctrl.left = true;
            PlayerControl.ctrl.middle = false;
            PlayerControl.ctrl.right = false;
        }
        if (other.CompareTag("Middle"))
        {
            PlayerControl.ctrl.left = false;
            PlayerControl.ctrl.middle = true;
            PlayerControl.ctrl.right = false;
        }
        if (other.CompareTag("Right"))
        {
            PlayerControl.ctrl.left = false;
            PlayerControl.ctrl.middle = false;
            PlayerControl.ctrl.right = true;

        }


    }





}
