using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uid : MonoBehaviour {
	public Dictionary<string,int> uids = new Dictionary<string,int> ();
	public List<Item> backpack = new List<Item>();
	public Text uid_txt;
	private string otpt;
	public GameObject wine1;
	//public Transform parenttrans;
	public RectTransform parenttrans;
	//public ini_test(){

	//}
	// Use this for initialization
	void Start () {
		//Dictionary<string,int> uids = new Dictionary<string,int> ();
		uids.Add("Gold:",1000);
		uids.Add ("Beer:", 1);
		uids.Add ("Names", 0);
		//UpdateUID ();
		ini_test ();
	}
	public void ini_test()
	{

		GameObject ret=Instantiate (wine1, parenttrans,false);
		Vector3 offset = new Vector3(0.0f , 50f, 0f);
		//Transform newtrans =new Vector3 (parenttrans.position.x, parenttrans.position.y - 50, parenttrans.position.z);
		parenttrans.localPosition-=offset;
		GameObject ret2=Instantiate (wine1,parenttrans);
		//ret2.transform.SetParent (ret.transform, false);


		//Instantiate (wine1,parenttrans);
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
[System.Serializable]
public class Item{
	public string item_name;
	public int item_number;
	public string item_sprite;
}