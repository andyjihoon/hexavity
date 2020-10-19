using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public Transform transform;
	int CurrentGravity;
	
	void Start()
	{
		CurrentGravity = 5;
	}
	
	void Update()
	{
		if(CurrentGravity != Control.gravity.DirectionNum){
			CurrentGravity = Control.gravity.DirectionNum;
			if(CurrentGravity == 1){
				transform.rotation = Quaternion.Euler(0, 0, 120f);
			}
			else if(CurrentGravity == 2){
				transform.rotation = Quaternion.Euler(0, 0, 180f);
			}
			else if(CurrentGravity == 3){
				transform.rotation = Quaternion.Euler(0, 0, 240f);
			}
			else if(CurrentGravity == 4){
				transform.rotation = Quaternion.Euler(0, 0, 300f);
			}
			else if(CurrentGravity == 5){
				transform.rotation = Quaternion.Euler(0, 0, 0f);
			}
			else if(CurrentGravity == 6){
				transform.rotation = Quaternion.Euler(0, 0, 60f);
			}
		}
	}
}
