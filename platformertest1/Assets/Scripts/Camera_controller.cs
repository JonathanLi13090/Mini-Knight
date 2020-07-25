using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Camera_controller : MonoBehaviour
{

    public float changeX = 25f;
    public float changeY = 10f;
    public Vector2 WindowSize;
    public Transform playerPos;
    public Transform cameraPos;
    private float currentPlayerX;
    private float currentPlayerY;
    private float currentCameraX;
    private float currentCameraY;
    public float Smooth = 1f;

    private float cameraHalfWidth, cameraHalfHeight;
    // Start is called before the first frame update
    void Start()
    {
        cameraHalfHeight = GetComponent<Camera>().orthographicSize;
        cameraHalfWidth = cameraHalfHeight * ((float)(Screen.width / Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerX = playerPos.transform.position.x;
        currentPlayerY = playerPos.transform.position.y;
        currentCameraX = cameraPos.transform.position.x;
        currentCameraY = cameraPos.transform.position.y;

        float targetX = Mathf.Floor(currentPlayerX / (2 * cameraHalfWidth))*2*cameraHalfWidth + cameraHalfWidth;
        float targetY = Mathf.Floor(currentPlayerY / (2 * cameraHalfHeight))*2*cameraHalfHeight + cameraHalfHeight;

        float x = Mathf.Lerp(currentCameraX, targetX, Smooth * Time.deltaTime);
        float y = Mathf.Lerp(currentCameraY, targetY, Smooth * Time.deltaTime);

        //transform.position = new Vector3(x, y, transform.position.z);
        transform.position = Vector3.MoveTowards(cameraPos.position, new Vector3(x, y, transform.position.z), Smooth * Time.deltaTime);



        //if (currentPlayerX > currentCameraX + 14.5)
        //{
            //transform.position = Vector3.MoveTowards(transform.position, , 0);
        //}
        //else if(currentPlayerX < currentCameraX - 14.5)
        //{
        //    transform.Translate(-29, 0, 0);
        //}
        //else if(currentPlayerY > currentCameraY + 7.5)
        //{
        //    transform.Translate(0, 13, 0);
        //}
        //else if (currentPlayerY < currentCameraY - 7.5)
        //{
        //    transform.Translate(0, -13, 0);
        //}
    }
}
