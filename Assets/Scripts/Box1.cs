using UnityEngine;
using System.Collections;

public class Box1 : MonoBehaviour {

	//定义三种零件的Prefab
	public GameObject Obj1;
	public GameObject Obj2;
	public GameObject Obj3;
	//Prefab导入到UIRoot中的位置
	public GameObject ReparentTarget;
	//临时存放对象
	private GameObject Component;
	private Animator Anim;
//	enum Lingjian
//	{
//		Lingjian1,
//		Lingjian2,
//		Lingjian3
//	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	

	}

	//void OnTriggerEnter(Collider So)
	void OnTriggerEnter()
	{
		switch(Component_Count.Lingjian)
		{
		case 1:
			Debug.Log("碰撞触发，Obj1");
			Component = NGUITools.AddChild(ReparentTarget , Obj1);
			Anim = Component.GetComponent<Animator>();
			Anim.SetBool("Lingjian1Play", true);
			Destroy(gameObject);
			Component_Count.Lingjian++;
			PlayerPrefs.SetInt("LingjianCount", 1);
			break;
		case 2:
			Debug.Log("碰撞触发，Obj2");
			Component = NGUITools.AddChild(ReparentTarget , Obj2);
			Anim = Component.GetComponent<Animator>();
			Anim.SetBool("Lingjian2Play", true);
			Destroy(gameObject);
			Component_Count.Lingjian++;
			PlayerPrefs.SetInt("LingjianCount", 2);
			break;
		case 3:
			Debug.Log("碰撞触发，Obj3");
			Component = NGUITools.AddChild(ReparentTarget , Obj3);
			Anim = Component.GetComponent<Animator>();
			Anim.SetBool("Lingjian3Play", true);
			Destroy(gameObject);
			Component_Count.Lingjian++;
			PlayerPrefs.SetInt("LingjianCount", 3);
			break;
		case 4:
			Destroy(gameObject);
			break;
		}
	}
}
