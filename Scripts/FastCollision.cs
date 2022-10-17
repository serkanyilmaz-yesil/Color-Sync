using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCollision : MonoBehaviour
{
    public bool sync;
    public float invincibleTime = 3;
    public GameObject enabledModel;


    private void Start()
    {
        sync = false;
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.GetComponent<MeshRenderer>().material.color == gameObject.GetComponent<MeshRenderer>().material.color)
        {
            PlayerControl.ctrl.fastControl++;
            sync = true;


        }
        else
        {
            PlayerControl.ctrl.play = false;
            GameManager.gm.fail = true;
            StartCoroutine(EnabledDisabled(invincibleTime));

        }

        enabledModel = other.gameObject;

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 2);
        }
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
