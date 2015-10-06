using UnityEngine;
using System.Collections;

public class RunTime : MonoBehaviour {

	public GameObject Enemy;
	private int WaveCount = 0;

	void Awake () {
		Time.timeScale = 1;
		for(int i = 0; i < Random.Range (2,4); i++) {
			Instantiate(Enemy, new Vector3(Random.Range (-10,10), 6, 0), Quaternion.identity);
		}
	}

	void Update () {
		StuffWhileRunning();
	}

	
	private bool oneShot = true;
	void StuffWhileRunning () {
		if(oneShot)
			StartCoroutine(CreateWaves());
		oneShot = false;
	}
	
	IEnumerator CreateWaves () {
		float timer = 0f;
		while (timer < 5f) {
			timer += Time.deltaTime;
			yield return null;
		}
		for(int i = 0; i < Random.Range (3,(WaveCount/2)*Random.Range (3,10)); i++) {
			Instantiate(Enemy, new Vector3(Random.Range (-10,10), 6, 0), Quaternion.identity);
		}
		oneShot = true;
		WaveCount++;
	}
}
