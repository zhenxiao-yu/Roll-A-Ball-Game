using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //declare required variables
    public float speed;
    public Text countText;
    private Rigidbody rb;
    private int count;

    //initialize the player and score 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }
    
    //add controller for the player 
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    //method to collect the pickups and increase the score 
    void OnTriggerEnter(Collider other) 
    {
        //allocate different points to different type of pick ups 
        if (other.gameObject.CompareTag("Capsule"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 2;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count = count + 3;
            SetCountText();
        }
    }
    
    //set the point counter
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        //after each point, check if all the points are collected
        CheckWin();
    }

    //if all the points are collected, restart game
    void CheckWin(){
        if (count >= 20)
        {
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart(){
        //pause ball movement 
        rb.constraints = RigidbodyConstraints.FreezePosition;
        //wait for a few seconds
        yield return new WaitForSeconds(5f);
        //restart the game
        SceneManager.LoadScene("MiniGame");
    }
    
}
