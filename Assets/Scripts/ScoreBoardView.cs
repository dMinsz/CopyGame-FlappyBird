using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardView : MonoBehaviour
{
    public TMP_Text curScore;
    public TMP_Text bestScore;

    private void OnEnable()
    {
        curScore.text = GameManager.Data.CurScore.ToString();
        bestScore.text = GameManager.Data.BestScore.ToString();
    }
}
