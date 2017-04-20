using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scene_jmp : MonoBehaviour {
	public GameObject panel1;
	public GameObject panel2;
	public GameObject panel3;
	public GameObject panel4;
	public Text txt;
	public List<string> convs;
	public int _indexer = 0;
	// Use this for initialization
	void Start () {

		//List<string> convs = new List<string>();
		panel1.SetActive (false);
		panel2.SetActive (false);
		panel3.SetActive (false);
		//txt.text = "Queen limits you to find the strange name of Goblin throughout the country in 3days. Or the little prince will fall into the hands of Goblin and you will be execuated for not completeing the royal mission.";
		//txt.text
		convs.Add("Hello the royal messenger. Her Majesty has an important mission for you.");
		convs.Add ("The Queen and Goblin have an agreement, in three days if she can not call out the full name of Goblin, the little prince will fall into Goblin's hands.");
		convs.Add ("Your mission is to collect those strange names throughout the country");
		convs.Add ("Failing to the mission will cost your life");
		convs.Add ("<WASD> to move, <SPACE> to jump, now pick a place to start your name-searching adventure.");
		txt.text = convs [_indexer];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void throw_panel(){
		panel1.SetActive (true);
		panel2.SetActive (true);
		panel3.SetActive (true);
		panel4.SetActive (false);
	}
	public void next_dia(){
		_indexer++;
		Debug.Log (_indexer.ToString ());
		if (_indexer <= 4) {
			txt.text = convs [_indexer];
		} else {
			throw_panel();
		}

	}
}
