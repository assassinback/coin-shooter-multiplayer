﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsButtonActivate : MonoBehaviour {

	public string url = "http://teamstrixplasma-com.stackstaging.com/Multi/UserInfo/AddLevelAndExp.php";

	Slider slider;
	// Use this for initialization
	void Start () {
		slider = this.gameObject.transform.parent.GetComponent<Slider> ();
	}

	// Update is called once per frame
	void Update () {
		if (slider.GetComponent<AchievementsPowerUps>().claim==true) {
			this.gameObject.GetComponent<Button> ().interactable = true;
		} 
		else {
			this.gameObject.GetComponent<Button> ().interactable = false;

		}
	}
	public void ClaimReward()
	{
		slider.GetComponent<AchievementsPowerUps> ().claim = false;
		PlayerPrefs.SetInt ("PlayerXP",PlayerPrefs.GetInt ("PlayerXP")+slider.GetComponent<AchievementsPowerUps>().RewardXP);
		StartCoroutine (PlayerXpDBSave ());
		PlayerPrefs.SetInt ("TotalPowerUpsUsed", PlayerPrefs.GetInt ("TotalPowerUpsUsed") + 1);
	}

	public IEnumerator PlayerXpDBSave()
	{
		WWWForm ch1 = new WWWForm();
		ch1.AddField("username", PlayerPrefs.GetString("username"));
		ch1.AddField("CurrentEXP", PlayerPrefs.GetInt("PlayerXP"));
		ch1.AddField("expneeded", PlayerPrefs.GetInt("CurrentLevelMax"));
		WWW wWW = new WWW(url, ch1);
		yield return wWW;
	}
}
