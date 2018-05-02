using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class EnableJacob : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QuestLog.AddQuestStateObserver ("Find Your Tent", LuaWatchFrequency.EveryUpdate, OnQuestStateChanged);
	}

	void OnQuestStateChanged (string title, QuestState newState) {
		// make a quest marker on the tent
		if (newState == QuestState.Success) {
			GameObject jacob = GameObject.Find("Jacob") as GameObject;
			jacob.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
		}
	}
}