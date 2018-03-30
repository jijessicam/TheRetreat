using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{

	public GameObject dialog_center;
	public float interactProximity = 5f;
	public float canvasSpeed = 5f;
	public float canvasDuration = 2f;
	public string[] textList;


	GameObject player;
	PlayerController playerController;
	Vector3 initialScale = new Vector3 (0, 0, 0);
	Vector3 finalScale = new Vector3 (1, 1, 1);
	Text currText;
	int textIndex = 0;
	bool isLerpScaleReady = true;
	bool canvasHidden = true;


	// Use this for initialization
	void Start ()
	{
		dialog_center.transform.localScale = initialScale;
		currText = dialog_center.GetComponentInChildren<Text> ();

		player = GameObject.Find ("Player");
		playerController = player.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update ()
	{
		// check for proximity to player and lerp if ready and the dialog canvas is hidden and dialog key is pressed
		if (Input.GetKeyUp (playerController.talkKey) && Vector3.Distance (player.transform.position, this.transform.position) < interactProximity &&
		    isLerpScaleReady && canvasHidden) {
			isLerpScaleReady = false;
			canvasHidden = false;
			StartCoroutine (LerpScale (dialog_center.transform, initialScale, finalScale, canvasDuration));

			// reset the conversation because it's being reopened
			currText.text = textList [0];
			textIndex = 0;

		} else if (!canvasHidden && Vector3.Distance (player.transform.position, this.transform.position) >= interactProximity) {
			isLerpScaleReady = false;
			canvasHidden = true;
			StartCoroutine (LerpScale (dialog_center.transform, finalScale, initialScale, canvasDuration));
		}

		// advance conversation with dialog advance key
		if (!canvasHidden && Input.GetKeyUp (playerController.nextDialogKey)) {
			textIndex++;
			// conversation over, close text box
			if (textIndex == textList.Length) {
				isLerpScaleReady = false;
				canvasHidden = true;
				StartCoroutine (LerpScale (dialog_center.transform, finalScale, initialScale, canvasDuration));
			} else { // set next text
				currText.text = textList[textIndex];
			}
		}
	}

	public IEnumerator LerpScale (Transform trans, Vector3 initialScale, Vector3 finalScale, float duration)
	{

		float t = 0f;
		float rate = (1.0f / duration) * canvasSpeed;

		while (t < 1) {
			t += Time.deltaTime * rate;
			trans.localScale = Vector3.Lerp (initialScale, finalScale, t);

			isLerpScaleReady = true;
			yield return null;
		}

	}
}
