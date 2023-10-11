using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarLapCounter : MonoBehaviour
{
    public Text carPositionText;

     int passedCheckPointNumber = 0;
    float timeAtLastPassedCheckPoint = 0;

    int numberOfPassedCheckpoints = 0;

    int lapsCompleted = 0;
    const int lapsToComplete = 3;

    bool isRaceCompleted = false;

    int carPosition = 0;

    bool isHideRoutineRunning = false;
    float hideUIDelayTime;

    //Events
    public event Action<CarLapCounter> OnPassCheckpoint;

    public void SetCarPosition(int position)
    {
        carPosition = position;
    }


    public int GetNumberOfCheckpointsPassed()
    {
        return numberOfPassedCheckpoints;
    }

    public float GetTimeAtLastCheckPoint()
    {
        return timeAtLastPassedCheckPoint;
    }

    IEnumerator ShowPositionCO(float delayUntilHidePosition)
    {
        hideUIDelayTime += delayUntilHidePosition;

        carPositionText.text = carPosition.ToString();

        carPositionText.gameObject.SetActive(true);

        if (!isHideRoutineRunning )
        {
           isHideRoutineRunning = true;
            
            yield return new WaitForSeconds(hideUIDelayTime);

            carPositionText.gameObject.SetActive(false);

            isHideRoutineRunning = false;
        }

      
    }

     void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("CheckPoint"))
        {
            //Once a car has completed the race we dont need to check any checkpoints or laps
            if (isRaceCompleted)
                return;

            Checkpoint checkPoint = collider2D.GetComponent<Checkpoint>();

            //Make sure that the car is passing the checkpoints in the correct order and that the correct checkpoint has exactly 1 value more then the last
            if (passedCheckPointNumber + 1 == checkPoint.checkPointNumber)

            {
                passedCheckPointNumber = checkPoint.checkPointNumber;

                numberOfPassedCheckpoints++;

               //Store the time at the checkpoint
                timeAtLastPassedCheckPoint = Time.time;

                if (checkPoint.isFinishLine)
                {
                    passedCheckPointNumber = 0;
                    lapsCompleted++;

                    if (lapsCompleted >= lapsToComplete)
                        isRaceCompleted = true;

                    if (lapsCompleted >= 3)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }

                //Invoke the passed checkpoint event 
                OnPassCheckpoint?.Invoke(this);

                //Now show the cars position as it has been calculated 
                if (isRaceCompleted)
                    StartCoroutine(ShowPositionCO(100));
                else StartCoroutine(ShowPositionCO(1.5f));
            }

        }
    }
}
