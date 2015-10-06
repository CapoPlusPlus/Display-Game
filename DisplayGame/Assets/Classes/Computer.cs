using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour {

	public GameObject PlayButton;

	private int Health = 10;
	
	void Update () {
		if (Health <= 0) {
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			Time.timeScale = 0;
			PlayButton.SetActive(true);
		}
	}

	private bool oneShot = true;
	void OnCollisionStay2D (Collision2D collision) {
		if(oneShot)
			StartCoroutine (TakeDamage ());
		oneShot = false;
	}

	IEnumerator TakeDamage () {
		float timer = 0f;
		while (timer < .25f) {
			Vector3 shake = new Vector3 (Mathf.Sin (Time.time * 1000f) * .05f, 0, 0);
			transform.position += shake;
			timer += Time.deltaTime;
			yield return null;
		}
		oneShot = true;
		Health--;
	}
}
