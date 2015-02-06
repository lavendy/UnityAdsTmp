using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Scene : MonoBehaviour {
	private bool bigBoom = false;
	public GameObject boom;
	public GameObject player;
	// Use this for initialization
	void Start () {
		Advertisement.Initialize("131624687", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		//GUI.Box(new Rect(Screen.width - 100 , 10 ,100 ,90), "Change Motion");
		if (bigBoom == false) {
			if(Advertisement.isReady("rewardedVideoZone")) {
				if (GUI.Button (new Rect (Screen.width - 200, Screen.height - 100, 180, 60), "Watch video and \nGet a Big Boom")) {
					bigBoom = true;

					Advertisement.Show("rewardedVideoZone", new ShowOptions {
						pause = true,
						resultCallback = result => {
							if (result == ShowResult.Finished) {
								bigBoom = true;
							}
						}
					});
				}
			}
		} else {
			if (GUI.Button (new Rect (Screen.width - 200, Screen.height - 100, 180, 60), "Runches Big Boom")) {
				Vector3 pos1 = new Vector3(-1, -3, 0);
				Vector3 pos2 = new Vector3(0, -4, 0);
				Vector3 pos3 = new Vector3(1, -3, 0);

				Instantiate (boom, pos1, Quaternion.identity);
				Instantiate (boom, pos2, Quaternion.identity);
				Instantiate (boom, pos3, Quaternion.identity);
			}
		}
	}
}
