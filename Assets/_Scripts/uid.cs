using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uid : MonoBehaviour {
	public Dictionary<string,int> uids = new Dictionary<string,int> ();
	public Text uid_txt;
	private string otpt;
	// Use this for initialization
	void Start () {
		//Dictionary<string,int> uids = new Dictionary<string,int> ();
		uids.Add("Gold:",1000);
		uids.Add ("Beer:", 1);
		uids.Add ("Names", 0);
		UpdateUID ();
	}
	
	// Update is called once per frame
	public void UpdateUID () {
		otpt="";
		foreach (KeyValuePair<string,int> item in uids) {
			if (item.Value > 0) {
				otpt = otpt+ item.Key + item.Value+"\n";}
		}
		uid_txt.text = otpt;
		//Debug.Log(uids["Gold:"]);
	}
}
