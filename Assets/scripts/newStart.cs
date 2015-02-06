using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class newStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Advertisement.Initialize ("131624687", true);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width /2-150, Screen.height/2-100, 300, 160), 
		              Advertisement.isReady("defaultVideoAndPictureZone") ? "Show Ad and\n Play Game" : "Ad Waiting..."))
		{
			Advertisement.Show("defaultVideoAndPictureZone", new ShowOptions {
				pause = true,
				resultCallback = result => {
					if (result == ShowResult.Finished) {
						Application.LoadLevel(1);
					}
				}
			});
		}
	}
}
