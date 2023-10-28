using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    private float gameTime;
    [SerializeField]
    private TextMeshProUGUI clock;
    void Start()
    {
        gameTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameTime += Time.deltaTime;
        int minutes = (int)gameTime / 60;
        int seconds = (int)gameTime % 60;
        if (minutes < 10) {
            clock.text = "0";
        }
        clock.text += minutes + ":";
        if(seconds % 60 < 10)
        {
            clock.text += "0";
        }
        clock.text += seconds;
    }

    public float getWinTime()
    {
        return gameTime;
    }
}
