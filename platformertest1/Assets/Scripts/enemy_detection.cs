using System.Collections.Generic;
using UnityEngine;

public class enemy_detection : MonoBehaviour
{
    public int health = 4;
    public List<Animator> HealthBubbles; //

    // Start is called before the first frame update
    void Start()
    {
        SetBubbles();
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
                health -= 1;
                SetBubbles();
                Debug.Log(health);
            }
            //pyield return new WaitForSeconds(1);
        }
    }

    private void SetBubbles()
    {
        for(int i = 0; i < HealthBubbles.Count; i += 1)
        {
            if(i > health -1) HealthBubbles[i].SetBool("Full", false);
            else HealthBubbles[i].SetBool("Full", true);
        }
    }
}
