using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_detection : MonoBehaviour
{
    public float health = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (health < 1)
            {
                Debug.Log("player died");
            }
            else
            {
                health = health -= 1;
                Debug.Log(health);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
