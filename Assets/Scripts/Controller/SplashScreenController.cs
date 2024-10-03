using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace com.BubbleShooterGame{
	
	public class SplashScreenController : MonoBehaviour {
	
		private GameObject _camera;
		private SplashScreenGUI _gui;
		private const string _bubbleShooterPrefabName = "Prefabs/BubbleShooterPrefab";
		[SerializeField] GameObject HUd;
		[SerializeField] TMPro.TMP_Text score;
		[SerializeField] TMPro.TMP_Text time;
		[SerializeField] TMPro.TMP_Text winLos;
		//[SerializeField] ui

		[SerializeField] GameObject GameFinish;
		[SerializeField] Button restart;
		void Start () {
			_camera = Camera.main.gameObject;	
			this._gui = _camera.AddComponent<SplashScreenGUI>();
			this._gui.StartGameDelegate = this.startGame;
		}

		
		public void startGame(){
			this._gui.StartGameDelegate = null;
			GameObject game = new GameObject("Game");
			game.AddComponent<GameController>();
			Destroy(this._gui);
			Destroy (this.gameObject);
			game.GetComponent<GameController>().setupUI(HUd, score, time, GameFinish, restart, winLos);
		}
	}
}