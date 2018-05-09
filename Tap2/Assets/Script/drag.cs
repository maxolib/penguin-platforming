﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {
	public float moveSpeed;
	public float jumpPower;
	public Rigidbody rb;
	public int score;
	private bool isGrounded;
	public UnityEngine.UI.Text textScore;
	public UnityEngine.UI.Text textHighScore;
	public GameObject pingu;
	public bool live;
	// Use this for initialization
	void Start () {
		moveSpeed = 3f;
		jumpPower = 8f;
		score = 0;
		rb = GetComponent<Rigidbody>();
		live = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(live){
			if (Input.GetKeyDown("space")  && isGrounded == true){
			rb.AddForce(transform.up * jumpPower,ForceMode.Impulse);
			isGrounded = false;
			}
			if (Input.GetKey("left"))
				pingu.transform.Rotate(0, -20, 0);
				print("up arrow key is held left");
			
			if (Input.GetKey("right"))
				
				pingu.transform.Rotate(0, 20, 0);
				print("down arrow key is held right");
			
			transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, 0f);
			textScore.text = score.ToString ();
			}
	}

	void OnCollisionEnter()
 {
     isGrounded = true;
 }
 void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Dead") {
			live = false;
			print("You dead already!!!");
		}
		if (other.gameObject.tag == "Score") {
			score++;
			other.gameObject.SetActive (false);
		}
	}

}
