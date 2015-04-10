using UnityEngine;
using System.Collections;

public class Life_Damage : MonoBehaviour {
	
	public GameObject I;
	public float life = 100;
	public float dano;
	
	private float weapon;
	public float danoG;
	public bool atacar = false;
	public bool atacando = false;
	
	void Start()
	{
		weapon = Random.Range (-1,5);
		dano = Random.Range (3,5);
		danoG = dano + weapon;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Mouse0) && !atacando && gameObject.tag != "Enemy")
		{
			atacando = true;
		}
		if(atacando && atacar)
		{
			I.GetComponent<Life_Damage>().life -= dano;
			atacando = false;
		}
		if(life < 0)
		{
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Enemy")
		{
			atacar = true;
			I = coll.gameObject;
		}
	}
	void OnCollisionExit2D(Collision2D coll)	
	{
		atacar = false;
		I = null;
	}
}