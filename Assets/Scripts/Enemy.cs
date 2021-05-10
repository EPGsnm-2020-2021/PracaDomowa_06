using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int damage;
    public float knockbackForce = 800;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Vector2 vector = new Vector2(0, knockbackForce);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(vector);

            collision.gameObject.GetComponent<PlayerHealth>().Damage(damage);
        }
    }
}
