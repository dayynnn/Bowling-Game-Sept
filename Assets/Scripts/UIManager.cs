using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIFrame[] frameArray;
    [SerializeField] private GameObject strikeImage;
    [SerializeField] private GameObject spareImage;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        int frameNum = 1;

        foreach(UIFrame frame in frameArray)
        {
            frame.SetFrameNumber(frameNum);
            frameNum++;
        }
    }

    public void DisplayGameOverScreen(int totalScore)
    {
        totalScoreText.text = "Total Score: " + totalScore.ToString();
        gameOverScreen.SetActive(true); 
    }

    public void UpdateFirstThrowOnFrame(int currentFrameIndex, int throwScore)
    {
        frameArray[currentFrameIndex - 1].SetFirstThrowScore(throwScore);
    }
    
    public void UpdateSecondThrowOnFrame(int currentFrameIndex, int throwScore)
    {
        frameArray[currentFrameIndex - 1].SetSecondThrowScore(throwScore);
    }
    
    public void UpdateTotalThrowOnFrame(int currentFrameIndex, int throwScore)
    {
        frameArray[currentFrameIndex - 1].SetTotalScore(throwScore);
    }

    public void DisplayStrike(int currFrameIndex)
    {
        frameArray[currFrameIndex - 1].SetStrikeText();
        strikeImage.SetActive(true);
        Invoke("HideImages", 3f);
    }

    public void DisplaySpare(int currFrameIndex)
    {
        frameArray[currFrameIndex - 1].SetSpareText();
        spareImage.SetActive(true);
        Invoke("HideImages", 3f);
    }

    private void HideImages()
    {
        strikeImage.SetActive(false);
        spareImage.SetActive(false);
    }

}
