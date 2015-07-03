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
	public GameObject hit;
	public GameObject Batata;
	
	public float x;
	public float y;
	public Vector3 mousePos = Input.mousePosition;
	public Vector3 aim;
	public bool parada = false;
	float rand;
	
	void Start()
	{
		weapon = Random.Range (-1,5);
		dano = Random.Range (3,5);
		danoG = dano + weapon;
	}
	
	void Update () 
	{
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;
		mousePos = Input.mousePosition;
		aim =  Camera.current.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 7));
		if(Input.GetKey(KeyCode.Mouse0) && !parada)
		{
			parada = true;
			GameObject hitmark = Instantiate(hit, aim, transform.rotation) as GameObject;
		}
		if(Input.GetKeyDown (KeyCode.Mouse0) && !atacando && gameObject.tag != "Enemy")
		{
			atacando = true;
		}
		if(atacando && atacar)
		{
			I.GetComponent<Life_Damage>().life -= dano;
			atacando = false;
		}
		rand = Random.Range(-6.0f,6.0f);
		if(life < 10)
		{
			GameObject Enemy = Instantiate(Batata, new Vector3(rand,80,-3), transform.rotation) as GameObject;
		}
		if(life < 0)
		{
			Destroy(gameObject);
		}
		if(transform.position.y <= -60)
		{
			transform.position = new Vector3(rand,40,-3);
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