using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_script : MonoBehaviour
{
    public int value;
    public static int Score;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Score Text").GetComponent<Text>().text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !triggered)
        {
            triggered = true;
            Score = Score + value;
            Debug.Log(Score);
            GameObject.FindGameObjectWithTag("Score Text").GetComponent<Text>().text = Score.ToString();
            Destroy(gameObject);
        }
    }

    public static void ResetScore()
    {
        Score = 0;
    }
}
