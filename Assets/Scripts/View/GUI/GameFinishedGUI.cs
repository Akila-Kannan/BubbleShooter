using UnityEngine;
using System.Collections;


namespace com.BubbleShooterGame.gui{
	
	public class GameFinishedGUI : MenuGUI {
	
		GameFinishGUIDelegate startNewGameSelectedDelegate;
		public delegate void GameFinishGUIDelegate();
			
		public GameFinishGUIDelegate StartNewGameSelectedDelegate{
			set{
				this.startNewGameSelectedDelegate = value;
			}
		}
		
		public Game game;
		void Start () {
				base.Start();;
			}
			
			// Update is called once per frame
			void Update () {
				base.Update ();
			
			}

		protected override void OnGUI()
		{

		}
		 private void newGameWasSelected(){
			if (startNewGameSelectedDelegate != null)
				startNewGameSelectedDelegate();
			}
		}
			


}
