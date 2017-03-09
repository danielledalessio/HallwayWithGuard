using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public Transform PauseCanvas;
	public Transform WinCanvas;
	public Transform LoseCanvas;
	public GameObject Player;
	public PlayerController controls;

	void Start(){
		Player = GameObject.FindGameObjectWithTag ("Player");
		controls = Player.GetComponent<PlayerController> ();
	}
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}
	public void Pause () {
		if (PauseCanvas.gameObject.activeInHierarchy == false) {
			AudioListener.pause = true;
			PauseCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			controls.enabled = false;
			Cursor.lockState = CursorLockMode.None;
		} 
		else {
			PauseCanvas.gameObject.SetActive (false);
			AudioListener.pause = false;
			Time.timeScale = 1;
			controls.enabled = true;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
	public void GameWon (){
		if (WinCanvas.gameObject.activeInHierarchy == false) {
			WinCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			controls.enabled = false;
			Cursor.lockState = CursorLockMode.None;
		}
	}
	public void GameLose(){
		if (LoseCanvas.gameObject.activeInHierarchy == false) {
			LoseCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			controls.enabled = false;
			Cursor.lockState = CursorLockMode.None;
		}
	}
	IEnumerator Restarting(){
		Time.timeScale = 1;
		yield return new WaitForSeconds (0.1f);
		Debug.Log ("restarting");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	public void RestartGame(){
		controls.enabled = true;
		StartCoroutine ("Restarting");
	}
	IEnumerator Menu(){
		Time.timeScale = 1;
		yield return new WaitForSeconds (0.1f);
		SceneManager.LoadScene("MainMenu");
	}
	public void toMain(){
		StartCoroutine ("Menu");
	}
}
