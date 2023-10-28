using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<Material> materials = new List<Material>();
    [SerializeField]
    MeshRenderer mr;
    private float time = 0f;
    private float colorTime = 0f;
    [SerializeField]
    private Light fireFlare;
    [SerializeField]
    private Color firstColor;
    [SerializeField]
    private Color secondColor;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        colorTime += Time.deltaTime;
        int index = (int)(time * 5.0f);
        mr.material = materials[index%5];
        fireFlare.color = Color.Lerp(firstColor, secondColor, colorTime);
        if (colorTime > 1.0f)
        {
            Color temp = secondColor;
            secondColor = firstColor;
            firstColor = temp;
            colorTime = 0.0f;
        }
    }
}
