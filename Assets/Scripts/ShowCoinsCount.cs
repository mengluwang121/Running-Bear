using UnityEngine;
using System.Collections;

public class ShowCoinsCount : MonoBehaviour {


	public UILabel CoinsCount;
	private int Coins;

	// Use this for initialization
	void Start () {
		Coins = PlayerPrefs.GetInt("CoinsCount");
		string Temp = Coins.ToString();
		CoinsCount.text = Temp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
