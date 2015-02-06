using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class BossControl : MonoBehaviour {
	public ParticleSystem explo;
	public ParticleSystem dieExplo;

	private int health = 100;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = transform.position.x;
		float moveY = transform.position.y - 0.12f * Time.deltaTime;
		this.transform.position = new Vector2 (moveX, moveY);
	}

	void OnTriggerEnter(Collider other){

		if (health < 0) {
			dieExplo.transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
			dieExplo.time = 0;
			dieExplo.Play();

			this.transform.position = new Vector3(0,10000,0);

			StartCoroutine(Die());
		}

		if (other.gameObject.name == "Bullet_p(Clone)") {
			health -= 6;

			GameObject.Destroy (other.gameObject);


			explo.transform.position = other.gameObject.transform.position;
			explo.time = 0;
			explo.Play();
		}
	}
	
	IEnumerator Die(){
		yield return new WaitForSeconds(2.0f);
	
		if (Advertisement.isReady ("rewardedVideoZone")) {
			Advertisement.Show("rewardedVideoZone", new ShowOptions {
				pause = true,
				resultCallback = result => {
					if (result == ShowResult.Finished) {
						Application.LoadLevel(0);
					}
				}
			});
		}
		else
			Application.LoadLevel(1);
	} 
}
