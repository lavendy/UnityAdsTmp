using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			//transform.Translate(Vector3.right * Time.deltaTime * 100, Space.World);
			Fire();
		}
	}

	void Fire()
	{
		float pos = Random.Range (-5, 5) / 10.0f;
		Vector2 newPos = new Vector3 (this.transform.position.x + pos,
		                              this.transform.position.y + 0.1f);
		Instantiate (bullet, newPos, Quaternion.identity);
	}
}