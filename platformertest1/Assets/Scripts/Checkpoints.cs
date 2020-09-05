using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject spawnPoint;
    public SpriteRenderer spriteRenderer;
    public Sprite checkPointOn;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnPoint.transform.Translate(transform.position.x, transform.position.y, 0);
        }
    }

    public void goToCheckpoint()
    {
        player.transform.Translate(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0);
    }
}
