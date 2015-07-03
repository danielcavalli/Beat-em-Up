using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour 
{
	public float uaiti = 0.5f;
	public GameObject doritos;
	public GameObject Player;
	IEnumerator Espera() 
	{
		yield return new WaitForSeconds(uaiti);
		Player.GetComponent<Life_Damage>().parada = false;
		Destroy(gameObject);
	}
	void Update ()
	{
		StartCoroutine(Espera());
	}
}