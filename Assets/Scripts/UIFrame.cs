using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFrame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI frameNumberText;
    [SerializeField] private TextMeshProUGUI firstThrowText;
    [SerializeField] private TextMeshProUGUI secondThrowText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        firstThrowText.text = "";
        secondThrowText.text = "";
        totalScoreText.text = "";

    }

    public void SetFrameNumber(int frameNum)
    {
        frameNumberText.text = frameNum.ToString();
    }
    public void SetFirstThrowScore(int throwScore)
    {
        firstThrowText.text = throwScore.ToString();

    }
    public void SetSecondThrowScore(int throwScore)
    {
        secondThrowText.text = throwScore.ToString();
    }
    public void SetTotalScore(int totalScore)
    {
        totalScoreText.text = totalScore.ToString();
    }

    public void SetStrikeText()
    {
        firstThrowText.text = "";
        secondThrowText.text = "X";
    }

    public void SetSpareText()
    {
        secondThrowText.text = "/";
    }
}
