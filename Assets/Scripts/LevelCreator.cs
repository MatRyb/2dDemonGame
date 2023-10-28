using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField]
    private Level level;

    [SerializeField]
    private GameObject firePrefab;
    [SerializeField]
    private GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Vector3 fire in level.firePositions)
        {
            Instantiate(firePrefab, new Vector3(fire.x,fire.y,fire.z), Quaternion.identity);
        }
        foreach (Vector3 obstacle in level.obstaclesPositions)
        {
            Instantiate(obstaclePrefab, new Vector3(obstacle.x, obstacle.y, obstacle.z), Quaternion.identity);
        }
    }

}
