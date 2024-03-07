using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int score;
    
    [Header("Prefabs")]
    public GameObject enemyBullet;
    
    void Start()
    {
        //Invoke(nameof(Shoot), Random.Range(0, 60));
    }
    
    private void Shoot()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
        Invoke(nameof(Shoot), Random.Range(0, 60));
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBullet>() is not null) return;
        
        //Debug.Log("Ouch!");
        FindObjectOfType<GameManager>().AddDestroyedEnemy(gameObject);
        FindObjectOfType<GameManager>().AddScore(score);
        Destroy(gameObject);
    }
}