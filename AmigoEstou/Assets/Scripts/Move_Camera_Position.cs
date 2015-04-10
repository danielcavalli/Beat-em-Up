using UnityEngine;
using System.Collections;

public class Move_Camera_Position : MonoBehaviour {

	public GameObject player;
	public Vector3 speed = new Vector3(0.1f,0,0);
	public float playerPos;
	public float playerPosY;
	
	public float Axis;
	void Update () 
	{
		playerPos = player.transform.position.x;
		playerPosY = player.transform.position.y;
		Axis = Input.GetAxis("Horizontal");
		if(playerPosY <= 20)
		{
			//Esqueleto Começo
			if(playerPos >= transform.localPosition.x && Axis > 0)
			{
				transform.position += speed;
			}
			else if(playerPos >= transform.localPosition.x && Axis == 0)
			{
				transform.position += speed*6;
			}
			if(playerPos <= transform.localPosition.x && Axis < 0)
			{
				transform.position -= speed;
			}
			else if(playerPos <= transform.localPosition.x && Axis == 0)
			{
				transform.position -= speed*6;
			}
			//Esqueleto Fim
			//-------------------Novas Coisas---------------------
		}
		else
		{
			transform.position = new Vector3(playerPos,2.41f,-10);
		}
	}
}

//line.Contains(char)
