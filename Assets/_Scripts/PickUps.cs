using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    //declare diffrent types of prefabs as GameObjects
    public GameObject Capsule;
    public GameObject Coin;
    public GameObject Cube;

    //change how high the pick ups are off the ground
    public float Hover = 0.5f;
    
    //instantiate the pickups by positions
    void Start()
    {
        //say initial position in arrays
        int[] xPos = { -5, 5, 0, 0, 0, 0, -5, 5, 0, -5, 5 };
        int[] zPos = { 0, 0, 12, 16, 20, -5, -5, -5, 30, 26, 26};
        
        //spawn 5 Capsules
        for (int i = 0; i < 5; i++) 
        {
            Instantiate(Capsule, new Vector3(xPos[i], Hover, zPos[i]), Quaternion.Euler(25, 50, 75));
        }
        //spawn 3 Coins
        for (int i = 5; i < 8; i++) 
        {
            Instantiate(Coin, new Vector3(xPos[i], Hover, zPos[i]), Quaternion.Euler(25, 50, 75));
        }
        //spawn 3 Cubes
        for (int i = 8; i < 11; i++) 
        {
            Instantiate(Cube, new Vector3(xPos[i], Hover, zPos[i]), Quaternion.Euler(25, 50, 75));
        }
    }
}
