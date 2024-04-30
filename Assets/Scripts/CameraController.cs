//camera controller for the minigame in world 1-2, i wanted to use the code in sidescrolling but it would've messed up the other levels
//used a tutorial for Lerp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if(player.transform.localScale.x >0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        if(player.transform.localScale.y >0f)
        {
            playerPosition = new Vector3(playerPosition.x, playerPosition.y + offset, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x, playerPosition.y - offset, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
