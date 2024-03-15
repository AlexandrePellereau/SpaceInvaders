using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _myRigidbody2D;
    
    [Header("Prefabs")]
    public GameObject explosion;

    [Header("Settings")]
    public float speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
      _myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      _myRigidbody2D.velocity = Vector2.up * speed; 
      //Debug.Log("Wwweeeeee");
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
      Destroy(gameObject);
      Destroy(collision.gameObject);
      GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
      go.GetComponent<Renderer>().material.color = collision.gameObject.CompareTag("Enemy") ? 
        collision.gameObject.GetComponent<Enemy>().explosionMaterial.color :
        collision.gameObject.GetComponent<Renderer>().material.color;
    }
}
