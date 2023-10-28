using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    public List<Vector3> firePositions;
    [SerializeField]
    public List<Vector3> obstaclesPositions;
    [SerializeField]
    public Vector2 playingArea;





    
}
