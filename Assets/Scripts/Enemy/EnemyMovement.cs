using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float border = 5;
    public int direction = 1;
    public float speed = 0.1f;
    
    private double _lastMove;
    private GameManager _gameManager;
    
    void Start()
    {
        _lastMove = Time.timeSinceLevelLoad;
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        if (Time.timeSinceLevelLoad - _lastMove >= 1 - 1 * (0.7 * ((float)_gameManager.GetEnemiesDestroyed() / _gameManager.GetTotalEnemies())))
        {
            //Debug.Log("cooldown : " + (1 - 1 * (0.7 * ((float)_gameManager.GetEnemiesDestroyed() / _gameManager.GetTotalEnemies()))));
            if (transform.position.x > border)
            {
                direction = -1;
                transform.position += new Vector3(0, -1, 0);
            }
            else if (transform.position.x < -border)
            {
                direction = 1;
                transform.position += new Vector3(0, -1, 0);
            }
            transform.position += new Vector3(direction * speed, 0, 0);
            _lastMove = Time.timeSinceLevelLoad;
        }
    }
}
