using UnityEngine;
using System.Collections;

public class DoorRotate : MonoBehaviour {
	
	public int rotationSpeed;
	public bool loop = false;
	public float maxAngle;

	Vector3 rotationPoint;

	// Use this for initialization
	void Start () 
	{
		if(transform.childCount > 0)
			rotationPoint = this.gameObject.transform.FindChild("RotationPoint").position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(loop)
			transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
		else
		{
			Vector3 rot = transform.rotation.eulerAngles;
			if (rot.z < maxAngle && rotationPoint != null)
				transform.RotateAround(rotationPoint, Vector3.forward, rotationSpeed);
		}
	}
}
