﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private bool doMovement = true;

	public float panSpeed = 30f;
	public float panBorderThickness = 100f;

	public float scrollSpeend = 5f;
	public float minY = 10f;
	public float maxY = 80f;

	// Update is called once per frame
	void Update () {

		if(GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}

		if(Input.GetKeyDown (KeyCode.Escape))
		{
			doMovement = !doMovement;
		}

		if(!doMovement)
		{
			return;
		}

		if( (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) && gameObject.transform.position.z < -24f)
		{
			transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}

		if( (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThickness) && gameObject.transform.position.z > -100f)
		{
			transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}

		if( (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) && gameObject.transform.position.x < 65f)
		{
			transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

		if( (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThickness) && gameObject.transform.position.x > 6f)
		{
			transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeend * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		transform.position = pos;
		
	}
}
