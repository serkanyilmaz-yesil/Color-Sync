using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPosition : MonoBehaviour
{
    public static RoadPosition road;

    public float speed;
    private float startSpeed;
    public float fastSpeed;

    public float time;
    public float lerpSpeed;



    private void Awake()
    {
        road = this;
    }

    private void Start()
    {
        startSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.ctrl.play && PlayerControl.ctrl.tap)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;

            if (transform.position.z <= -3)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), lerpSpeed * Time.deltaTime);
            }


        }

        if (time > 0)
        {
            time -= Time.deltaTime;
            speed = fastSpeed;
            PlayerControl.ctrl.controlReset = true;
            PlayerControl.ctrl.selectedObject = null;
        }

        if (time <= 0)
        {
            speed = startSpeed;
            PlayerControl.ctrl.controlReset = false;
        }

        if (CharPos.charPosition.finishPos)
        {
            speed = 15f;
            PlayerControl.ctrl.controlReset = true;

        }

        if (GameManager.gm.finish)
        {
            speed = 0;
            PlayerControl.ctrl.play = false;

        }
    }
}
