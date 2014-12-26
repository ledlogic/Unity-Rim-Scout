using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float minSpin, maxSpin;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;
	private int score;
	private bool restart;
	private bool gameover;

	// Use this for initialization
	void Start () {
		StartCoroutine( SpawnWaves ());
		score = 0;
		UpdateScore ();
		gameover = false;
		restart = false;

		restartText.text = "";
		gameoverText.text = "";
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	// Spawn a wave of asteroids
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while(true) {
			for (int i=0; i<hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				spawnRotation.eulerAngles.Scale(new Vector3(Random.Range(minSpin, maxSpin), Random.Range(minSpin, maxSpin), Random.Range(minSpin, maxSpin)));
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (gameover) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	// Update the score viewport display
	void UpdateScore() {
		scoreText.text = "Score:\n" + score.ToString ();
	}

	public void IncrScore(int delta) {
		score += delta;
		UpdateScore ();
	}

	public void GameOver() {
		gameoverText.text = "Game Over, Man!";
		gameover = true;
	}
}
