using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {

	public Text VictoryText;
	
	void Start()
	{
		VictoryText.text = "";
	}
	
	void Update()
	{
		if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
		{
			VictoryText.text = "Congratulations, Blob! You win!";
		}
	}
}
