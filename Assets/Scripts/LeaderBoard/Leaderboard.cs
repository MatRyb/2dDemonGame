using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{

    public static LeaderBoard instance;
    public List<List<Score>> scores;
    private int numberOfLevels = 5;

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
            scores = new List<List<Score>>();
            for(int i = 0; i < numberOfLevels; i++)
            {
                scores.Add(new List < Score >());
            }
        }
     
    }
    public void AddRecord(string name, float score, int level)
    {
        Score record = new Score();
        record.name = name;
        record.score = score;
        scores[level].Add(record);
        Debug.Log(scores);
    }
    public void SortScores()
    {
        for(int level = 0; level < numberOfLevels; level++)
        { 
            for(int i = 0; i < scores[level].Count-1; i++)
            {
                for(int j = 0; j < scores[level].Count - 1; j++)
                {
                    if (scores[level][i].score > scores[level][i + 1].score)
                    {
                        Score temp = scores[level][i];
                        scores[level][i] = scores[level][i + 1];
                        scores[level][i + 1] = temp;
                    }
                }

            }
        }

    }





}
