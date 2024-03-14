using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [Header("Bullet Settings")]
    public GameObject bullet;
    public Transform shottingOffset;
    
    [Header("Movement Settings")]
    public float speed = 3f;
    public float border = 12;
    
    private AudioManager _audioManager;
    
    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            //Debug.Log("Bang!");
            _audioManager.Play("PlayerShoot");

            Destroy(shot, 3f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        
        Vector3 pos = transform.position;
        if (pos.x < -border)
            pos.x = -border;
        if (pos.x > border)
            pos.x = border;
        transform.position = pos;
    }
}
