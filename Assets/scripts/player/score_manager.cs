using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_manager : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI text_score;
    void Start()
    {
        
    }
    public void Add_score(int k)
    {
        score += k;
    }
    public void Get_score(ref int k)
    {
        k = score;
    }

    void Update()
    {
        text_score.text = ""+score;
    }
}
