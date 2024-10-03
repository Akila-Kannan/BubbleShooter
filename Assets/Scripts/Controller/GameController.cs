using UnityEngine;
using System.Collections;
using com.BubbleShooterGame.events;
using com.BubbleShooterGame.gui;
using System.Collections.Generic;
using UnityEngine.UI;

namespace com.BubbleShooterGame{

	public class GameController : MonoBehaviour {

		protected Game _game;

		private const string _bubbleShooterPrefabName = "Prefabs/BubbleShooterPrefab";
		private GameObject _bubbleShooterPrefab;
		private GameObject _camera;
		private BubbleMatrixController _bubbleMatrixController;
		private HUD _hud;
		private GameObject _hudUi;
		[SerializeField] TMPro.TMP_Text score;
		[SerializeField] TMPro.TMP_Text time;
		[SerializeField] TMPro.TMP_Text winLos;
		//[SerializeField] ui

		[SerializeField] GameObject GameFinish;
		
		[SerializeField] Button restart;
		void Awake() {
			_game = new com.BubbleShooterGame.Game();
		}

		void Start() {
			_camera = Camera.main.gameObject;
			_hud = _camera.AddComponent<HUD>();
			_hud.game = this._game;
			this.startGame();
			this._hudUi.SetActive(true);


		}

		void OnEnable() {
			GameEvents.OnBubblesRemoved += onBubblesRemoved;
			GameEvents.OnGameFinished += onGameFinished;
		}

		void OnDisable() {
			GameEvents.OnBubblesRemoved -= onBubblesRemoved;
			GameEvents.OnGameFinished -= onGameFinished;
		}

		public void setupUI(GameObject hud,TMPro.TMP_Text score, TMPro.TMP_Text time,GameObject gamefinishUi, Button resart, TMPro.TMP_Text winloss) {

			_hudUi = hud;
			this.score = score;
			this.time = time;

			this.GameFinish = gamefinishUi;
			this.restart = restart;

			this.winLos = winloss;
		
		} 
	
		void Update () {
			score.text= "score : "+ _game.score;
			time.text = string.Format("{0:D2}:{1:D2}:{2:D2}", _hud.timeSpan.Hours, _hud.timeSpan.Minutes, _hud.timeSpan.Seconds);
		}
		
		private void startGame(){
			_bubbleShooterPrefab = Instantiate(Resources.Load(_bubbleShooterPrefabName)) as GameObject;
			_bubbleShooterPrefab.transform.position = new Vector3(0,0,0);
			_bubbleMatrixController = _bubbleShooterPrefab.GetComponent<BubbleMatrixController>();
			
			_bubbleMatrixController.startGame();
				
			
			
		}
		// Game Controllers Specializations can override this function to provide
		// specific score behaviour
		protected virtual void onBubblesRemoved(int bubbleCount, bool exploded){
			this._game.destroyBubbles(bubbleCount, exploded);
		}
		
		protected virtual void onGameFinished(GameState state){
			GameFinishedGUI finishedGUI =  _camera.AddComponent<GameFinishedGUI>();
			finishedGUI.StartNewGameSelectedDelegate = this.onGameStartSelected;
			this._game.state = state;
			finishedGUI.game = this._game;
			GameFinish.SetActive(true);
			winLos.text = this._game.state == GameState.Win ? "You Win" : "You Lost";
			restart.onClick.AddListener(onGameStartSelected);
			



		}
		
		private void onGameStartSelected(){
			Application.LoadLevel (0);
		}
		
	
		
	}
}
