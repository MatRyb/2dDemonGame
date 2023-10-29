using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public bool deathOnImpact;

    public enum ObstacleType { Block, Swamp, Fog, Village, Farm};
    public ObstacleType obstacleType;
}
