using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{

    public static CamControl cam;

    public Transform lookPos;
    public Transform targetPos;
    public Vector3 startPos;
    public bool fast;
    public float lerpSpeed;

    public float time;


    private void Awake()
    {
        cam = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        fast = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(lookPos);



        if (fast)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }

            if (time <= 0)
            {
                fast = false;
            }


            transform.position = Vector3.Lerp(transform.position, targetPos.transform.position, lerpSpeed * Time.deltaTime);
            transform.LookAt(lookPos);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, lerpSpeed * Time.deltaTime);

        }
    }
}
