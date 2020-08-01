using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_detection : MonoBehaviour
{
    public float health = 4f;
    public List<Animator> HealthBubbles;
    public float invincibilityTime = 10f;
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
                health = health -= 1;
                SetBubbles();
                Debug.Log(health);
                for (int i = 0; i < 10; i += 1)
                {
                    invincibilityTime -= Time.deltaTime;
                    if (invincibilityTime < 0)
                    {
                        break;
                    }
                }
            }

        }
    }
    private void SetBubbles()
    {
        for (int i = 0; i < HealthBubbles.Count; i += 1)
        {
            if (i > health - 1) HealthBubbles[i].SetBool("Full", false);
            else HealthBubbles[i].SetBool("Full", true);
        }
    }
}
