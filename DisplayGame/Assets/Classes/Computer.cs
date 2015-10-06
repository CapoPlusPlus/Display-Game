using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour {

	private int Health = 10;
	
	void Update () {
		if (Health < 10)
			Destroy (gameObject);
	}

	void OnCollision2D (Collision2D collision) {
		print ("Touched");
		StartCoroutine (TakeDamage ());
	}

	IEnumerator TakeDamage () {
		float timer = 0f;
		while (timer < 3f) {
			Health--;
			timer += Time.deltaTime;
			yield return null;
		}
	}
}
