using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DestroyAfterTalkingToOfficer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QuestLog.AddQuestStateObserver ("Find Your Tent", LuaWatchFrequency.EveryUpdate, OnQuestStateChanged);
	}

	void OnQuestStateChanged (string title, QuestState newState) {
		// make a quest marker on the tent
		if (newState == QuestState.Active) {
			Destroy(GameObject.Find("PreGameColliders"));
		}
	}
}
