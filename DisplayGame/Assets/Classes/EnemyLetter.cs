using UnityEngine;
using System.Collections;

public class EnemyLetter : MonoBehaviour {

	public GameObject[] letterMeshes = new GameObject[6];

	private GameObject thisMesh;
	private Vector3 target;
	private int Health = 3; 
	

	void Awake () {
		thisMesh = Instantiate (letterMeshes[Random.Range (0, letterMeshes.Length)] , transform.position, Quaternion.identity) as GameObject;
		thisMesh.transform.parent = transform;
		target = GameObject.Find("Computer").transform.position;
	}

	void Update () {
		moveTowardsTarget ();
	}

	void OnMouseDown() {
		StartCoroutine (TakeDamage ());
	}
	
	IEnumerator TakeDamage() {
		Health--;
		if (Health <= 0) {
			GameObject.Find("Computer").GetComponent<Computer>().Score += 100;
			Destroy (gameObject);
		}
		//Shake animation
		float timer = 0f;
		while (timer < .25f) {
			Vector3 shake = new Vector3 (Mathf.Sin (Time.time * 1000f) * .1f, 0, 0);
			transform.position += shake;
			timer += Time.deltaTime;
			yield return null;
		}
	}
	
	void moveTowardsTarget () {
		transform.position = Vector3.MoveTowards (transform.position, target, Random.Range(1f, 1.25f) * Time.deltaTime);
	}
}
