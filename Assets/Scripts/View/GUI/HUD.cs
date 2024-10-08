﻿using UnityEngine;
using System;
using System.Collections;

namespace com.BubbleShooterGame{
	public class HUD : MonoBehaviour {
		
		public Game game;
		
		private float _timeOffset;
		public TimeSpan timeSpan;
		void Start () {
			_timeOffset = Time.timeSinceLevelLoad;	
		}
		
		void Update () {
		}
		
		void OnGUI(){
			
			
			timeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad - _timeOffset);
			//string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			
			//GUI.Label(new Rect(20,100,200,30), "Score: " + game.score);
			//GUI.Label(new Rect(20,120,200,30), "Bubbles destroyed: " + game.bubblesDestroyed);
			//GUI.Label(new Rect(20,140,200,30), "Time played: " + timeText);
			
		}
	}
}
