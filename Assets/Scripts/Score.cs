using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//定义三种零件的Prefab
	public GameObject Obj1;
	public GameObject Obj2;
	public GameObject Obj3;
	//Prefab导入到UIRoot中的位置
	public GameObject ReparentTarget;
	//临时存放对象
	private GameObject Component;
	private Animator Anim;
	// Use this for initialization
	private int LingjianNum;
//	private int i = 3;
	void Start () {
//		switch(Component_Count.Lingjian)
//		{
//		case 1:
//			Debug.Log("碰撞触发，Obj1");
//			Component = NGUITools.AddChild(ReparentTarget , Obj1);
//			Anim = Component.GetComponent<Animator>();
//			Anim.SetBool("Score1Play", true);
//			Component_Count.Lingjian++;
//			break;
//		case 2:
//			Debug.Log("碰撞触发，Obj2");
//			Component = NGUITools.AddChild(ReparentTarget , Obj2);
//			Anim = Component.GetComponent<Animator>();
//			Anim.SetBool("Score2Play", true);
//			Component_Count.Lingjian++;
//			break;
//		case 3:
//			Debug.Log("碰撞触发，Obj3");
//			Component = NGUITools.AddChild(ReparentTarget , Obj3);
//			Anim = Component.GetComponent<Animator>();
//			Anim.SetBool("Score3Play", true);
//			Component_Count.Lingjian++;
//			break;
//		case 4:
//			Destroy(gameObject);
//			break;
//		}
	
		LingjianNum = PlayerPrefs.GetInt("LingjianCount");
		//读取获得零件的个数，显示相应的分数，并在显示后将分数清零
		switch(LingjianNum)
		{
		case 1:
			Debug.Log("碰撞触发1");
			StartCoroutine(Single());
			PlayerPrefs.SetInt("LingjianCount", 0);
			break;
		case 2:
			Debug.Log("碰撞触发2");
			StartCoroutine(Double());
			PlayerPrefs.SetInt("LingjianCount", 0);
			break;
		case 3:
			Debug.Log("碰撞触发3");
			StartCoroutine(Triple());
			PlayerPrefs.SetInt("LingjianCount", 0);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Single()
	{
		Component = NGUITools.AddChild(ReparentTarget , Obj1);
		Anim = Component.GetComponent<Animator>();
		Anim.SetBool("Score1Play", true);
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator Double()
	{
		Component = NGUITools.AddChild(ReparentTarget , Obj1);
		Anim = Component.GetComponent<Animator>();
		Anim.SetBool("Score1Play", true);
		yield return new WaitForSeconds(1.0f);
		Component = NGUITools.AddChild(ReparentTarget , Obj2);
		Anim = Component.GetComponent<Animator>();
		Anim.SetBool("Score2Play", true);
	}

	IEnumerator Triple()
	{
		Component = NGUITools.AddChild(ReparentTarget , Obj1);
		Anim = Component.GetComponent<Animator>();
		Anim.SetBool("Score1Play", true);
		yield return new WaitForSeconds(1.0f);
		Component = NGUITools.AddChild(ReparentTarget , Obj2);
		Anim = Component.GetComponent<Animator>();
		Anim.SetBool("Score2Play", true);
		yield return new WaitForSeconds(1.0f);
		Component = NGUITools.AddChild(ReparentTarget , Obj3);
		Anim = Component.GetComponent<Animator>();
		Anim.SetBool("Score3Play", true);
	}

}
