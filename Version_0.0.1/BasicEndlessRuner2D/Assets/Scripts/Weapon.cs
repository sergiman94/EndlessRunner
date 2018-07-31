using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public int damage = 10;
	public LayerMask whatToHit;

	public Transform bulletTrailPrefab;
	public Transform muzzleFlashPrefab;
	public Transform hitPrefab;

	float timeToSpawnEfect = 0;
	public float effectSpawnRate = 10;


	float timeToFire = 0.05f;
	Transform firePoint;


	void Awake () {
	
		firePoint = transform.Find ("FirePoint");

		if (firePoint == null) {
		
			Debug.Log ("No fire point ? WHAT !?");
		}

	}

	void Start (){



	}

	void Update(){
	
		if (fireRate == 0) {
			if (Input.GetMouseButtonDown (0)) {
			
				Shoot ();
			}
		} else {

			if (Input.GetMouseButtonDown (0) && Time.time > fireRate) {

				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}
	}

	void Shoot(){
	
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);

		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

		Debug.DrawLine (firePointPosition, hit.point, Color.cyan);

		if (hit.collider != null) {

			Debug.DrawLine (firePointPosition, hit.point, Color.red);

		}

		if (Time.time >= timeToSpawnEfect){

			Vector3 hitPos;
			Vector3 hitNormal;

			if (hit.collider == null) {
			
				hitPos = (mousePosition - firePointPosition) * 30;
				hitNormal = new Vector3 (999, 999, 999);
			} else {
			
				hitPos = hit.point;
				hitNormal = hit.normal;
			}

			Effect (hitPos, hitNormal);
			timeToSpawnEfect = Time.time + 1 / effectSpawnRate; 

		}
	
	}

	void Effect (Vector3 hitPos, Vector3 hitNormal) {
		
		Transform trail = Instantiate (bulletTrailPrefab, firePoint.position, firePoint.rotation) as Transform;

		LineRenderer lr = trail.GetComponent<LineRenderer> ();

		if (lr != null) {

			lr.SetPosition (0, firePoint.position);
			lr.SetPosition (1, hitPos);
	
		}

		Destroy (trail.gameObject, 0.04f);

		if (hitNormal != new Vector3 (999, 999, 999)){

			Transform hitParticle = Instantiate (hitPrefab, hitPos, Quaternion.FromToRotation(Vector3.right, hitNormal)) as Transform;
			Destroy(hitParticle.gameObject, 1f);
		}


		Transform clone = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
		clone.parent = firePoint;

		float size = Random.Range (0.099f, 0.099f);

		clone.localScale = new Vector3 (size, size, size);

		Destroy (clone.gameObject, 0.02f);

	}


}
