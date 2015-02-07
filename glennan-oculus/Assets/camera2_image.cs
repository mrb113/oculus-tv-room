using UnityEngine;
using System.Collections;

public class camera2_image : MonoBehaviour {
	public string url1 = "http://viewfinder1.case.edu/image.jpg";
	public string url2 = "http://viewfinder2.case.edu/image.jpg";
	public string url3 = "http://viewfinder3.case.edu/image.jpg";
	// Use this for initialization
	void Start () {
		// Determine which TV is using the script
		// Then we can determine which URL to use
		string url = null; 
		string caller = transform.parent.gameObject.name; 
		if (caller = "plane1"){
			Debug.Log("Plane1");
			url = url1; 
		} else if (caller = "plane2") {
			Debug.Log("Plane2");
			url = url2; 
		} else {
			Debug.Log ("plane3");
			url = url3; 
		}
		// Starts updating the image every half second 
		Texture glennan = (Texture)Resources.Load("glennan_static");
		Debug.Log("glennan: " + glennan);
		renderer.material.mainTexture =  glennan;
		InvokeRepeating("UpdateImage", 0f, .5f);
	}

	void Update () {

	}

	void UpdateImage() {
		StartCoroutine("FetchImage");
	}

	IEnumerator FetchImage() {
		WWW www = new WWW(url);
		yield return www;
		renderer.material.mainTexture = www.texture;
	}


}
