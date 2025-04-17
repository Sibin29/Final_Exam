using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Snake's movement speed
    public string inputAxisHorizontal;      // Input Axis for the snake's horizontal movement
    public string inputAxisVertical;        // Input Axis for the snake's vertical movement
    private const string FoodObject = "FoodObject";
    private const string GroundTag = "Ground";
    private const string SnakeTag = "Player";
    private const string BombTag = "Bomb";
    
    // Explosion Prefab variable
    public GameObject explosionPrefab = null;
    public GameObject explosionInstance = null;

    // Food Collected Audio Prefab variable
    public GameObject foodCollectedAudioPrefab = null;
    public GameObject foodCollectedAudioInstance = null;

    // Private Variables
    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Movement for horizontal axis
        if(Input.GetAxis(inputAxisHorizontal) != 0)
        {
        float moveX = Input.GetAxis(inputAxisHorizontal) * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);
        // Clamp the snakes's position to stay in the screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, -2.55f, 2.55f);
        transform.position = new Vector3( clampedX, transform.position.y, transform.position.z);
        }

        //Movement for vertical axis
        /* if(Input.GetAxis(inputAxisVertical) != 0)
        {
        float moveY = Input.GetAxis(inputAxisVertical) * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
        // Clamp the snakes's position to stay in the screen bounds
        float clampedY = Mathf.Clamp(transform.position.y, 0f, -4.8f);
        transform.position = new Vector3( transform.position.y, clampedY, transform.position.z);
        }*/

    }
        void OnCollisionEnter2D(Collision2D collidedObject)
        {
            //Destroy the collided object
            Destroy(collidedObject.gameObject);
            if(collidedObject.gameObject.CompareTag(FoodObject))
            {
                GameManager.Instance.HandleFoodCollision("Food");
                Debug.Log("Food Detected");
                // Instantiate the food collected prefab
                foodCollectedAudioInstance = Instantiate(foodCollectedAudioPrefab, transform.position, transform.rotation);
                // Destroy the explosion instance after 1 second
                Destroy(foodCollectedAudioInstance, 5f);
            }else if (collidedObject.gameObject.CompareTag(BombTag))
            {
                GameManager.Instance.HandleBombCollision("Bomb");
                Debug.Log("Bomb Detected");
                // Explosion animation
                // Add offset to the explosion position
                Vector3 explosionPosition = new Vector3(transform.position.x-0.1f, transform.position.y+1f, transform.position.z);
                // Instantiate the explosion prefab at the snake's position
                explosionInstance = Instantiate(explosionPrefab, explosionPosition, transform.rotation);
                // Destroy the explosion instance after 1 second
                Destroy(explosionInstance, 5f);
            }
        }
}