using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{

    public static LeaderBoard instance;
    public List<Score> scores = new List<Score>();

    private void Awake()
    {
        if(instance != null && instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
     
    }
    public void AddRecord(string name, float score, int level)
    {
        Score record = new Score();
        record.name = name;
        record.score = score;
        record.level = level;
        scores.Add(record);
        Debug.Log(scores);
    }
    private void SortScores()
    {
        for(int i =0; i < scores.Count-1; i++)
        {
            for(int j = 0; i < scores.Count - 1; j++)
            {
                if (scores[i].score > scores[i + 1].score)
                {
                    Score temp = scores[i];
                    scores[i] = scores[i + 1];
                    scores[i + 1] = temp;
                }
            }

        }

    }





}
