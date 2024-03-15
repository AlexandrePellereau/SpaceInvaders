using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _myRigidbody2D;
    private AudioManager _audioManager;
    
    [Header("Prefabs")]
    public GameObject explosion;

    [Header("Settings")]
    public float speed = 5;
    
    // Start is called before the first frame update
    void Start()
    { 
        _audioManager = FindObjectOfType<AudioManager>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
      foreach (GameObject enemy in FindObjectOfType<GameManager>().GetEnemies())
      {
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      _myRigidbody2D.velocity = Vector2.down * speed; 
      //Debug.Log("Wwweeeeee");
    }
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) return;
        Destroy(gameObject);
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<SceneManager>().ShowCredits();
            _audioManager.Play("PlayerDeath");
        }
        GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
        go.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
    }
}
