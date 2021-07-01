using System;
using System.Collections.Generic;
using CurioLab.UI;
using UnityEngine;

namespace CurioLab
{
	[RequireComponent(typeof(MissionController))]
	public class GameController : MonoBehaviour
	{
		public static GameController instance;
		public List<Character> characters;
		public List<Item> inventory;
		public MissionController missionController;

		private void Start()
		{
			instance = this;
			FindObjectOfType<LobbyView>().Initialize();
		}

		public void StartMission(Mission mission = null, List<Character> characters = null)
		{
			missionController.StartMission(mission, characters);
		}
	}
}