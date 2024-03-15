using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int score;
    
    [Header("Prefabs")]
    public GameObject enemyBullet;
    
    [Header("Sprites")]
    public Sprite[] sprites;
    
    private int _spriteIndex;
    
    private SpriteRenderer _spriteRenderer;
    private AudioManager _audioManager;
    
    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke(nameof(Shoot), Random.Range(0, 60));
        
        if (sprites.Length == 0) return;
        _spriteIndex = (int)Time.realtimeSinceStartup % sprites.Length;
        _spriteRenderer.sprite = sprites[_spriteIndex];
    }
    
    private void Shoot()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
        _audioManager.Play("EnemyShoot");
        Invoke(nameof(Shoot), Random.Range(0, 60));
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBullet>() is not null) return;
        
        FindObjectOfType<GameManager>().AddDestroyedEnemy(gameObject);
        FindObjectOfType<GameManager>().AddScore(score);
        _audioManager.Play("EnemyDeath");
    }

    private void Update()
    {
        if (sprites.Length == 0) return;
        
        int newSpriteIndex = (int)Time.realtimeSinceStartup % sprites.Length;
        if (newSpriteIndex != _spriteIndex)
        {
            _spriteIndex = newSpriteIndex;
            _spriteRenderer.sprite = sprites[_spriteIndex];
        }
    }
}