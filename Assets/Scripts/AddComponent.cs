using UnityEngine;
using System.Collections;

public class AddComponent : MonoBehaviour {

	public GameObject Obj;
	public GameObject ReparentTarget;
	private GameObject Component1;
	private Animator Anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//Debug.Log("1");
			Component1 = NGUITools.AddChild(ReparentTarget , Obj);
		//	Debug.Log(Obj.name);
			Anim = Component1.GetComponent<Animator>();
			Anim.SetBool("Lingjian1Play", true);
		}
	
	}
}
