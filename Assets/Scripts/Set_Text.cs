using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Set_Text : MonoBehaviour
{
    private Text text;

    private List<string> explatives = new List<string>() { "BANG!", "WOW!"};

    public float whenToTurnOffText = -1;
    public bool isOnScreen;

    public float timeOnScreen;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }


    public void ChangeTextOnAttack(float startingTime)
    {
        whenToTurnOffText = startingTime + timeOnScreen;
        isOnScreen = true;
        text.transform.localPosition = new Vector3(Random.Range(-250, 250), Random.Range(-150, 150), 0);
        text.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        text.text = explatives[Random.Range(0, explatives.Count)];
        text.fontSize = Random.Range(12, 24);
    }

    public void ResetText()
    {
        text.text = "";
    }

    void Update()
    {
        if (whenToTurnOffText != -1 && isOnScreen)
        {
            if (Time_Record.current_Time > whenToTurnOffText)
            {
                ResetText();
                whenToTurnOffText = -1;
                isOnScreen = false;
            }
        }
    }

    //void FixedUpdate()
    //{
    //    if(frames % 5 == 0)
    //    {
    //        text.transform.localPosition = new Vector3(Random.Range(-250, 250), Random.Range(-150, 150), 0);
    //        text.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
    //        text.text = explatives[Random.Range(0, explatives.Count)];
    //        text.fontSize = Random.Range(12, 24);
    //    }
    //    frames++;
    //}
}
