using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public GameObject Batata;
	public float rand;
	void Update()
	{
		rand = Random.Range (-36.0f,36.0f);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "HitMark")
		{
			GameObject Enemy = Instantiate(Batata, new Vector3(rand,80,-3), transform.rotation) as GameObject;
			Destroy(gameObject);
		}
	}
}
