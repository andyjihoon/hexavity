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
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Control.gravity.DirectionRadian + 90);
		}
	}
}
