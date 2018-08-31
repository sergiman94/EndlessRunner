using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAttack : MonoBehaviour {

    public float speed;
    public float damage;


    private Rigidbody2D myRigidBody2D;
    private BoxCollider2D myBoxCollider;

    Player _player;

	// Use this for initialization
	void Start () {
		
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {

       

	}

    void FixedUpdate(){
        
        myRigidBody2D.velocity = new Vector2(-speed, myRigidBody2D.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player = collision.collider.GetComponent<Player>();

        Physics2D.IgnoreCollision(collision.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        if (_player != null){

            _player.DamagePlayer((int)damage);

        }


        //if (collision.gameObject.tag == "Player"){

        //    //player.DamagePlayer((int)damage);

        //}
    }
}
