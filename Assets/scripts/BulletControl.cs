using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float moveY = this.transform.position.y + (speed * Time.deltaTime);
		transform.position = new Vector2 (this.transform.position.x, moveY);
		
		if (transform.position.y > 5)
			Destroy (gameObject);
	}
}
