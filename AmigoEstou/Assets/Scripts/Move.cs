using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed = 10.0f;
	public float jump = 0;
	private float T;
	public float Stamina = 100f;
	public bool speedUp = false;
	
	float rand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	//Equeleto Começo
		//Controle
		T = Input.GetAxis("Horizontal") * speed;
		transform.localPosition += transform.right * T * Time.deltaTime;
		if(Input.GetKey(KeyCode.Joystick1Button5) && Stamina > 0 && !speedUp)
		{
			speed = 20;
			Stamina -= 1.5f;
			if(Stamina <= 0)
			{
				speedUp = true;
			}
		}
		else
		{
			speed = 10;
		}
		if(Stamina < 100)
		{
			Stamina += 0.5f;
		}
		if(Input.GetKeyUp(KeyCode.Joystick2Button5))
		{
			speedUp = false;
		}
		//                                                                  |  |
		//                                                                 \\  //
		//Resto e controle(Controle ta aqui oh)---------------------------> \\//
		//                                                                   \/
		if((Input.GetKey(KeyCode.Space) && jump <= 0) || (Input.GetKey(KeyCode.Joystick1Button0) && jump <= 0)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, 20, 0);
			jump += 1;
		}
	//Equeleto Fim
	//-----------------------------------------------------------------------------------
	//Adicione novas coisas aqui	
		rand = Random.Range (-36.0f,36.0f);
		if(transform.position.y <= -60)
		{
			transform.position = new Vector3(rand,40,-2);
		}
	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag != "Parede")
		{
			jump = 0;
		}
	}
}
