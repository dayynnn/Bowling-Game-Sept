using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIFrame[] frameArray;

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

    public void UpdateFirstThrowOnFrame(int currentFrameIndex, int throwScore)
    {
        frameArray[currentFrameIndex - 1].SetFirstThrowScore(throwScore);
    }
}
