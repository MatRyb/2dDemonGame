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
    [SerializeField]
    private float IntensityLow;
    [SerializeField]
    private float IntensityHigh;

    private float offset;

    private void Start()
    {
        offset = Random.Range(0.0f, 1.0f);
        colorTime += offset;

    }


    // Update is called once per frame
    void Update()
    {
        // the absolute fucking void I must have had in my mind when I made it is impossible to imagine
        time += Time.deltaTime;
        colorTime += Time.deltaTime;
        int index = (int)(time * 5.0f);
        mr.material = materials[index%5];
        fireFlare.color = Color.Lerp(firstColor, secondColor, colorTime);
        fireFlare.intensity = Mathf.Lerp(IntensityLow, IntensityHigh, colorTime);
        if (colorTime > 1.0f)
        {
            Color temp = secondColor;
            secondColor = firstColor;
            firstColor = temp;

            float temp2 = IntensityLow;
            IntensityLow = IntensityHigh;
            IntensityHigh = temp2;


            colorTime = 0.0f;
        }
    }
}
