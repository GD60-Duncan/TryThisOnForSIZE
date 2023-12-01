using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeSingleDirection : MonoBehaviour
{
	public bool inverse;
	public float resizeAmount;
	public string resizeDirection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKey (KeyCode.Alpha5)) {
			Resize (resizeAmount, resizeDirection);
		}
    }

	void Resize(float amount, string direction) {
		if (direction == "x" && inverse == false) {
			transform.position = new Vector3 (transform.position.x + (amount / 2), transform.position.y, transform.position.z);
			transform.localScale = new Vector3 (transform.localScale.x + amount, transform.localScale.y, transform.localScale.z);
		} else if (direction == "y" && inverse == false) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (amount / 2), transform.position.z);
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y + amount, transform.localScale.z);
		} else if (direction == "z" && inverse == false) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + (amount / 2));
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z + amount);
		}

		if (direction == "x" && inverse == true) {
			transform.position = new Vector3 (transform.position.x - (amount / 2), transform.position.y, transform.position.z);
			transform.localScale = new Vector3 (transform.localScale.x + amount, transform.localScale.y, transform.localScale.z);
		} else if (direction == "y" && inverse == true) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - (amount / 2), transform.position.z);
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y + amount, transform.localScale.z);
		} else if (direction == "z" && inverse == true) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - (amount / 2));
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z + amount);
		}

	}
}