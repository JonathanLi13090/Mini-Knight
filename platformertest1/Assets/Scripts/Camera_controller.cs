using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Camera_controller : MonoBehaviour
{

    public float changeX = 25f;
    public float changeY = 10f;
    public Transform playerPos;
    public Transform cameraPos;
    private float currentPlayerX;
    private float currentPlayerY;
    private float currentCameraX;
    private float currentCameraY;
    public float Smooth = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerX = playerPos.transform.position.x;
        currentPlayerY = playerPos.transform.position.y;
        currentCameraX = cameraPos.transform.position.x;
        currentCameraY = cameraPos.transform.position.y;
        if(currentPlayerX > currentCameraX + 14.5)
        {
           // float x = Mathf.Lerp(currentCameraX + 14.5f, 29, Smooth * Time.deltaTime) - 14.5f;
            transform.Translate(29, 0, 0);
        }
        else if(currentPlayerX < currentCameraX - 14.5)
        {
            transform.Translate(-29, 0, 0);
        }
        else if(currentPlayerY > currentCameraY + 7.5)
        {
            transform.Translate(0, 13, 0);
        }
        else if (currentPlayerY < currentCameraY - 7.5)
        {
            transform.Translate(0, -13, 0);
        }
    }
}
