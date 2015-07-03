using UnityEngine;
using System.Collections;

public class Move_Camera_Position : MonoBehaviour {

	public GameObject player;
	public Vector3 speed = new Vector3(0.1f,0,0);
	
	public Vector3 speedd = new Vector3(0,0,180);
	public Vector3 speeddd = new Vector3(0,0,0);
	public float playerPos;
	public float playerPosY;
	
	public GameObject oculos;
	public GameObject smoke;
	public GameObject sniper;
	Quaternion target = Quaternion.Euler(0, 0, 0);
	Quaternion target2 = Quaternion.Euler(0, 180, 0);
	public float playerPosS; 
	public float Axis;
	void Update () 
	{
		playerPos = player.transform.position.x;
		playerPosY = player.transform.position.y;
		Axis = Input.GetAxis("Horizontal");
		playerPosS = playerPos - 0.77f;
		if(playerPosY <= 20)
		{
			//Esqueleto Começo
			if(playerPos >= transform.localPosition.x && Axis > 0)
			{
				transform.position += speed;
				oculos.transform.rotation = Quaternion.Slerp(transform.rotation, target,5);
				smoke.transform.rotation = Quaternion.Slerp(transform.rotation, target,5);
				sniper.transform.rotation = Quaternion.Slerp(transform.rotation, target,5);
				smoke.transform.position = new Vector3(playerPosS + (0.77f*2),playerPosY + 0.25f,-3);
			}
			else if(playerPos >= transform.localPosition.x+1 &&Axis == 0)
			{
				transform.position += speed*10;
			}
			if(playerPos <= transform.localPosition.x && Axis < 0)
			{
				transform.position -= speed;
				oculos.transform.rotation = Quaternion.Slerp(transform.rotation, target2,5);
				smoke.transform.rotation = Quaternion.Slerp(transform.rotation, target2,5);
				sniper.transform.rotation = Quaternion.Slerp(transform.rotation, target2,5);
				smoke.transform.position = new Vector3(playerPosS,playerPosY + 0.25f,-3);
			}
			else if(playerPos <= transform.localPosition.x-1 && Axis == 0)
			{
				transform.position -= speed*10;
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
