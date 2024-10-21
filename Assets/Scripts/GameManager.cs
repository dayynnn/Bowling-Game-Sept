using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   //responsinble for spawning the ball; calculating pins; hiding fallen pins;
    //repositioning pins, respawning ball

    [Header("Game Objects")]
    [SerializeField] private Pin[] pins;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private UIManager ui;

    [Space(10)]
    
    [Header("Game Status")]
    [SerializeField] private int throwCounter;
    [SerializeField] private int maxAmountOfFrames;
    [SerializeField] private int currentFrame;

    [Header("Score Settings")]
    [SerializeField] private int totalScore;
    [SerializeField] private int firstThrowScore;
    [SerializeField] private int secondThrowScore;

    // Start is called before the first frame update
    void Start()
    {
        currentFrame = 1;
        StartThrow();
    }

    public void BallInPit()
    {
        throwCounter++;
        Invoke("StartThrow", 2f);
    }

    public void StartThrow()
    {
        CheckForFallenPins();        
        
        if(throwCounter == 2 || firstThrowScore == 10)
        {
            //STRIKE OR A SPARE DISPLAY IN UI
            StartNewFrame();

            if (currentFrame > maxAmountOfFrames) // if its past the last frame
            {
                return;
            }
        }

        

        Instantiate(ballPrefab, transform.position, transform.rotation);
    }

    void StartNewFrame()
    {
        totalScore += firstThrowScore + secondThrowScore;
        firstThrowScore = 0;
        secondThrowScore = 0;
        
        //DISPLAY TOTAL SCORE

        throwCounter = 0;

        currentFrame++;

        RepositionPins();
    }

    void RepositionPins()
    {
        foreach (Pin p in pins)
        {
            p.gameObject.SetActive(true);
            p.ResetPinToOrigin();
        }
    }

    void CheckForFallenPins()
    {
        int score = 0;

        foreach(Pin p in pins)
        {
            if (p.IsPinFallen() && (p.gameObject.activeInHierarchy))
            {
                //add point
                score += 1;
               
                p.gameObject.SetActive(false);
            }
        }
        if(throwCounter ==1) //UI SHOULD BE UPDATED HERE
        {
            firstThrowScore = score;
            ui.UpdateFirstThrowOnFrame(currentFrame, firstThrowScore);
        }
        else
        {
            secondThrowScore = score;
        }
        Debug.Log(score);
    }

}
