using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionHandler : MonoBehaviour
{
    public List<CarLapCounter> carLapCounters = new List<CarLapCounter>();
    void Start()
    {
        //Get all car lap counters in the scene
        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>();

        //Store the lap counters in a list
        carLapCounters = carLapCounterArray.ToList<CarLapCounter>();

        //Hook up passed checkpoint events
        foreach (CarLapCounter lapCounters in carLapCounters)
            lapCounters.OnPassCheckpoint += OnPassCheckpoint;
    }


    void OnPassCheckpoint(CarLapCounter carLapCounter)
    {
        //Sort the cars positon first based on how many checkpoints they have passed more is always better. Then sort on time where shorter time is better
      carLapCounters = carLapCounters.OrderByDescending(s => s.GetNumberOfCheckpointsPassed()).ThenBy(s => s.GetTimeAtLastCheckPoint()).ToList();

        //Get the Players position
        int carPosition = carLapCounters.IndexOf(carLapCounter) + 1;

        //Tell the lap counter which position the car has
        carLapCounter.SetCarPosition(carPosition);
    }
  
}
