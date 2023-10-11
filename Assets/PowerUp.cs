using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 0.5f;

    //public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup (other));
            Debug.Log("Picked up power Up");
        }

        if (other.CompareTag("Player2"))
        {
                StartCoroutine(Pickup2(other));
                Debug.Log("Picked up power Up");
        }
    }

    IEnumerator Pickup(Collider2D collider2D)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        Carcontrols carControls = collider2D.GetComponent<Carcontrols>();

        carControls.accelerationFactor = 50f;
        Debug.Log("Do we get this far?");
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(3f);

        carControls.accelerationFactor = 10f;

        yield return new WaitForSeconds(duration);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
    }
    IEnumerator Pickup2(Collider2D collider2D)
    {
        Carcontrols2 carControls2 = collider2D.GetComponent<Carcontrols2>();
        
        carControls2.accelerationFactor2 = 50f;
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(3f);

        carControls2.accelerationFactor2 = 10f;

        yield return new WaitForSeconds(duration);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
    }
        
}

