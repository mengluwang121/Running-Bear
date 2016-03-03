using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	public GameObject CoinCollectFlash;
	private GameObject Temp;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		Component_Count.CoinsSwitch = true;
		Temp = Instantiate(CoinCollectFlash, this.transform.position, Quaternion.identity) as GameObject;
		Destroy(gameObject);
		Destroy(Temp, 1.0f);
	}

}
