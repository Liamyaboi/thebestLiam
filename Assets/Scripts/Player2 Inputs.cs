using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2inputs : MonoBehaviour
{

    Carcontrols2 carcontrols;

    private void Awake()
    {
        carcontrols = GetComponent<Carcontrols2>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        inputVector.x = Input.GetAxis("Horizontal2");
        inputVector.y = Input.GetAxis("Vertical2");

        carcontrols.SetInputVector(inputVector);
    }
}
