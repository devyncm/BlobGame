using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour {

	public int coins;
	
	public Text coinText;
	
	void Update()
	{
		coinText.text = ("Coins: " + coins);
	}
}
