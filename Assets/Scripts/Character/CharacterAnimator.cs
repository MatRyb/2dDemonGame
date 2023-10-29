using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<Material> materials = new List<Material>();
    [SerializeField]
    MeshRenderer mr;
    private float time = 0f;


    // Update is called once per frame
    void Update()
    {
        // i wish i would remember what i thought when I wrote this code
        // but i dont, it works so i dont give a fuck
        time += Time.deltaTime;
        int index = (int)(time * 2.0f);
        mr.material = materials[index % 2];
    }
}
