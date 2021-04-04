using UnityEngine;
using System.Collections;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class SpinFree : MonoBehaviour {
	[Tooltip("Spin: Yes or No")]
	public bool spin;
	[Tooltip("Spin the parent object instead of the object this script is attached to")]
	public bool spinParent;
	public float speed = 10f;

	[HideInInspector]
	public bool clockwise = true;
	[HideInInspector]
	public float direction = 1f;
	[HideInInspector]
	public float directionChangeSpeed = 2f;

	public bool xAxis;
	public bool yAxis;
	public bool zAxis;

	// Update is called once per frame
	void Update() {
		if (direction < 1f) {
			direction += Time.deltaTime / (directionChangeSpeed / 2);
		}

		if (spin) {
			Spin();
		}
	}

	public void Spin(){
		if(xAxis)
			transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
		if(yAxis)
			transform.Rotate(Vector3.forward, (speed * direction) * Time.deltaTime);
		if(zAxis)
			transform.Rotate(Vector3.right, (speed * direction) * Time.deltaTime);
	}
}