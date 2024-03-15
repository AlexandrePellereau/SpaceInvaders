using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Settings")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    [Header("Enemy Spawning Settings")]
    public Vector2 enemySpawnPoint;
    public float distanceBetweenEnemies = 1;
    public int enemiesPerLine = 5;
    public List<GameObject> enemies;
    
    [Header("Barricade Spawning Settings")]
    public Vector2 barricadeSpawnPoint;
    public float distanceBetweenBarricades = 4;
    public GameObject barricade;
    
    [Header("Handlers")]
    public GameObject enemyHandler;
    public GameObject barricadeHandler;

    private List<GameObject> _enemyInstances;
    private int _score;
    
    
    void Start()
    {
        _enemyInstances = new List<GameObject>();
        
        //create a new file call "HighScore" and set the value to 0 if it doesn't exist
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        SpawnEnemies();
        SpawnBarricades();
        
        highScoreText.text = $"High Score : {PlayerPrefs.GetInt("HighScore"):D5}";
    }
    
    private void SpawnEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = 0; j < enemiesPerLine; j++)
            {
                _enemyInstances.Add(Instantiate(enemies[i], new Vector3(enemySpawnPoint.x + j * distanceBetweenEnemies, enemySpawnPoint.y - i * distanceBetweenEnemies, 0), Quaternion.identity, enemyHandler.transform));
            }
        }
    }
    
    private void SpawnBarricades()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(barricade, new Vector3(barricadeSpawnPoint.x + i * distanceBetweenBarricades, barricadeSpawnPoint.y, 0), Quaternion.identity, barricadeHandler.transform);
        }
    }
    
    public void AddDestroyedEnemy(GameObject enemy)
    {
        if (_enemyInstances.Contains(enemy))
        {
            _enemyInstances.Remove(enemy);
        }

        if (_enemyInstances.Count == 0)
        {
            Debug.Log("You win!");
            FindObjectOfType<SceneManager>().ShowCredits();
        }
    }
    
    public void AddScore(int score)
    {
        _score += score;
        scoreText.text = $"Score : {_score:D5}";
        
        if (!(_score > PlayerPrefs.GetInt("HighScore"))) return;
        PlayerPrefs.SetInt("HighScore", _score);
        highScoreText.text = $"High Score : {_score:D5}";
    }
    
    public int GetEnemiesDestroyed()
    {
        return enemies.Count * enemiesPerLine - _enemyInstances.Count;
    }
    
    public int GetTotalEnemies()
    {
        return enemies.Count * enemiesPerLine;
    }
    
    public List<GameObject> GetEnemies()
    {
        return _enemyInstances;
    }
}
