using UnityEngine;
using System.Collections;
using System;
using System.Reflection;


public class Component_Count : MonoBehaviour {

	//定义了零件、金币的数量、时间
	static public int Lingjian;
	private int Coins;
	private int Time_;
	private int Total_time;
	public int TheTimeofGame = 60;
	//显示吃到的金币数量,剩余时间
	public UILabel Text;
	public UILabel time_Label;
	public UISprite uiTime;
	//更改金币数量的开关
	static public bool CoinsSwitch;
	private bool isStart = false;
	public GameObject ReparentTarget;
	public GameObject TimeOut;

	public GameObject bear;
	// Use this for initialization
	void Start () {
		Lingjian = 1;
		Coins = 0;
		Total_time = (int)Time.time + TheTimeofGame;
		string Temp = Coins.ToString();
		Text.text = Temp;
		CoinsSwitch = false;
		StartCoroutine(count());
	}
	
	// Update is called once per frame
	void Update () {

		if(isStart)
		{
			//倒计时
			Time_ = Total_time - (int)Time.time + 3;
			string Temp_time = Time_.ToString();
			if(Time_ >= 0)
			{
				time_Label.text = Temp_time;
			}
			
			if(CoinsSwitch)
			{
				Coins++;
				string Temp = Coins.ToString();
				Text.text = Temp;
				CoinsSwitch = false;
			}
			//Text.text = "";
			
			if(Time_ <= 0)
			{
				
				StartCoroutine(TimeUseUp());
			}
		}
	}

	IEnumerator count()
	{
		uiTime.spriteName = "3";
		yield return new WaitForSeconds(1);
		uiTime.spriteName = "2";	
		yield return new WaitForSeconds(1);
		uiTime.spriteName = "1";
		yield return new WaitForSeconds(1);
		uiTime.spriteName = "go";
		isStart = true;
		Component AComponent = bear.GetComponent("ThirdPersonController");
		FieldInfo fieldInfo = AComponent.GetType().GetField("isPlay");
		fieldInfo.SetValue(AComponent,true);

		yield return new WaitForSeconds(0.5f);
		Destroy (uiTime);
	}

	IEnumerator TimeUseUp()
	{
		NGUITools.AddChild(ReparentTarget, TimeOut);
		PlayerPrefs.SetInt ("CoinsCount",Coins);
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Finish");
	}
}