using UnityEngine;
using System.Collections;

public class Animation_Play : MonoBehaviour {

	public GameObject Bear;
	//private GameObject AnimContainer;
	private Animator Anim;
	KinectController2 comp;
	SimpleGestureListener comp2;
	public AudioClip m_music;
	protected AudioSource m_audio;


	private float time=0.2f;
	// Use this for initialization
	void Start () {
		Anim = Bear.GetComponent<Animator>();
		comp = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<KinectController2> ();
		comp2= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SimpleGestureListener>();
		m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)||comp2.jflag==2)
		{    
			m_audio.clip=m_music;
			m_audio.Play();
			comp2.jflag=0;
			StartCoroutine(Jump_Wait());
		}


		if(Input.GetKey(KeyCode.K)||comp.lflag==1)
		{   
			time-=Time.deltaTime;
			Anim.SetBool("Left_Btn_Click", true);//hold on
			Anim.SetBool("Left_Btn_Loosen", false);
			if(time<0)
			{
				time=0.2f;
				comp.lflag=2;
			}
		}
		else
		{
			Anim.SetBool("Left_Btn_Loosen", true);

		}

		if(Input.GetKeyUp(KeyCode.K)||comp.lflag==2)
		{  
			StartCoroutine(Left_Wait());
			comp.lflag=0;

		}


		if(Input.GetKey(KeyCode.L)||comp.rflag==1)
		{   time-=Time.deltaTime;
			Anim.SetBool("Right_Btn_Click", true);
			Anim.SetBool("Right_Btn_Loosen", false);
			if(time<0)
		   {
				time=0.2f;
				comp.rflag=2;
			}
		}
		 else
		{
			Anim.SetBool("Right_Btn_Loosen", true);
		}
		if(Input.GetKeyUp(KeyCode.L)||comp.rflag==2)
		{ 
			StartCoroutine(Right_Wait());
			comp.rflag=0;
		}

	}

	IEnumerator Left_Wait()
	{
		Anim.SetBool("Left_Btn_Loosen", true);
		Anim.SetBool("Left_Btn_Click", false);
		yield return new WaitForSeconds(0.2f);
		Anim.SetBool("Left_Btn_Loosen", false);
	}

	IEnumerator Right_Wait()
	{
		Anim.SetBool("Right_Btn_Loosen", true);
		Anim.SetBool("Right_Btn_Click", false);
		yield return new WaitForSeconds(0.2f);
		Anim.SetBool("Right_Btn_Loosen", false);
	}

	IEnumerator Jump_Wait()
	{
		Anim.SetBool("Jump_Btn_Click", true);
		yield return new WaitForSeconds(0.2f);
		Anim.SetBool("Jump_Btn_Click", false);
	}
}
