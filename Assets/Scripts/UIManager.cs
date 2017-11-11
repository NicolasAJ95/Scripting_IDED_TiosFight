using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;

    public GameObject p1health;
    public GameObject p2health;
    private Image p1healthImage;
    private Image p2healthImage;
    public Text time;

    private float p1healthFloat;
    private float p2healthFloat;
    private float timeFloat = 120;

    public Text p1wins;
    public Text p2wins;
    public Text tie;

    // Use this for initialization
    void Start ()
    {
        p1wins.enabled = false;
        p2wins.enabled = false;
        tie.enabled = false;
        p1 = GameObject.Find("CharacterPlayer1");

         p2 = GameObject.Find("CharacterPlayer2");


        p1healthImage = p1health.GetComponent<Image>();
        p2healthImage = p2health.GetComponent<Image>();
        time = time.GetComponent<Text>();
        for (int i = 0; i < p1.transform.childCount; i++)
        {
            if (p1.transform.GetChild(i).gameObject.activeSelf == true)
            {
                p1healthFloat = p1.transform.GetChild(i).GetComponent<Fighter>().Health;
            }
        }
        for (int i = 0; i < p2.transform.childCount; i++)
        {
            if (p2.transform.GetChild(i).gameObject.activeSelf == true)
            {
                p2healthFloat = p2.transform.GetChild(i).GetComponent<Fighter>().Health;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        updateHealthBars();
        timeFloat -= Time.deltaTime;
        time.text = Convert.ToInt32(timeFloat).ToString();


        p1healthImage.fillAmount = p1healthFloat / 100;
        p2healthImage.fillAmount = p2healthFloat / 100;
        
        if (p1healthFloat < 0)
        {
            Time.timeScale = 0;
            p2wins.enabled = true;
        }
        if (p2healthFloat < 0)
        {
            Time.timeScale = 0;
            p1wins.enabled = true;
        }
        if (timeFloat < 0)
        {
            Time.timeScale = 0;
            tie.enabled = true;
        }
    }

    public void updateHealthBars()
    {
        for (int i = 0; i < p1.transform.childCount; i++)
        {
            if (p1.transform.GetChild(i).gameObject.activeSelf == true)
            {
                p1healthFloat = p1.transform.GetChild(i).GetComponent<Fighter>().Health;
            }
        }
        for (int i = 0; i < p2.transform.childCount; i++)
        {
            if (p2.transform.GetChild(i).gameObject.activeSelf == true)
            {
                p2healthFloat = p2.transform.GetChild(i).GetComponent<Fighter>().Health;
            }
        }
    }
}
