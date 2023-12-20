using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemNyawa
{

    public GameObject[] heartColors;

    public Sprite spriteHeartLoss;

    public int heartCount;
    // Start is called before the first frame update
    void Start()
    {
        // heartCount = heartColors.Length;
        for (int i = 0; i < 3; i++)
        {
            decreaseHeart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseHeart()
    {
        if (heartCount > 1)
        {
            heartCount--;
            heartColors[heartCount].GetComponent<Image>().sprite = spriteHeartLoss;
            
        }
    }
}
