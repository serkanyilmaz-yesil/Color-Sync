using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tabtale.TTPlugins;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject greatText;
    public GameObject nicetext;
    public GameObject perfectText;

    public bool finish, text1, text2, text3,fail, finishEff;
    public GameObject  nextButton, restartButton,failText, finishEffect;
    public Transform player;
    public int sceneControl;



    private void Awake()
    {
        TTPCore.Setup();
        gm = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        finish = false;
        nextButton.SetActive(false);
        restartButton.SetActive(false);
        failText.SetActive(false);
        text1 = false;
        text2 = false;
        text3 = false;
        fail = false;
        finishEff = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerControl.ctrl.fastControl == 1 && !text1)
        {
            Instantiate(greatText, new Vector3(player.position.x, player.position.y + 4f, player.position.z + 5f), Quaternion.Euler(40,0,0));
            text1 = true;

        }
        if (PlayerControl.ctrl.fastControl == 2 && !text2)
        {
            Instantiate(nicetext, new Vector3(player.position.x, player.position.y + 4f, player.position.z + 5f), Quaternion.Euler(40, 0, 0));
            text2 = true;

        }
        if (PlayerControl.ctrl.fastControl > 2 && !text3)
        {
            Instantiate(perfectText, new Vector3(player.position.x, player.position.y + 4f, player.position.z + 5f), Quaternion.Euler(40, 0, 0));
            text3 = true;

        }

        if (finish)
        {
            Invoke("NextDelay",3f);
            if (!finishEff)
            {
                Instantiate(finishEffect, transform);
                finishEff = true;
            }

        }

        if (PlayerControl.ctrl.fastControl == 0)
        {
            text1 = false;
            text2 = false;
            text3 = false;

        }

        if (fail)
        {
            failText.SetActive(true);

            Invoke("RestartDelay", 2f);

        }
    }

    void NextDelay()
    {
        nextButton.SetActive(true);
    }

    void RestartDelay()
    {
        restartButton.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void NextLevel()
    {
        sceneControl = Random.Range(0,3);
        SceneManager.LoadScene(sceneControl);


    }




}
