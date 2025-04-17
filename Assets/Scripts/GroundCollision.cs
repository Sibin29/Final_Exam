using System;
using UnityEditor;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private const string FoodObject = "FoodObject";


    // Private Variables
    private Rigidbody2D rBody;

        private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


        void OnCollisionEnter2D(Collision2D collidedObject)
    {
        //Destroy the collided object
        Destroy(collidedObject.gameObject);
        if(collidedObject.gameObject.CompareTag(FoodObject))
        {
            GameManager.Instance.HandleFoodCollision("ground");
            Debug.Log("Food Detected");
        }
    }
}
