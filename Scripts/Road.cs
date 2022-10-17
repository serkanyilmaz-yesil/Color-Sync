using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public bool sync;
    public float invincibleTime = 3;
    private GameObject enabledModel;


    private void Start()
    {
        sync = true;
    }

    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.GetComponent<MeshRenderer>().material.color == other.gameObject.GetComponent<MeshRenderer>().material.color)
            {
                sync = true;
                Destroy(gameObject, 2);
                transform.parent = null;
            }
            else
            {
                sync = false;
                PlayerControl.ctrl.play = false;
                GameManager.gm.fail = true;
                StartCoroutine(EnabledDisabled(invincibleTime));

            }

            Debug.Log(other.gameObject.name);
        }

        enabledModel = other.gameObject;


    }

    IEnumerator EnabledDisabled(float time)
    {


        float timer = 0;
        float enabledTimer = 0.2f;
        float end = 0;

        bool enabled = false;
        yield return new WaitForSeconds(1f);

        while (timer < time)
        {
            enabledModel.SetActive(enabled);
            yield return null;
            timer += Time.deltaTime;
            end += Time.deltaTime;
            if (enabledTimer < end)
            {
                end = 0;
                enabled = !enabled;
            }
        }
        enabledModel.SetActive(true);
    }



}
