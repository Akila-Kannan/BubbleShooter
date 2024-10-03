using UnityEngine;
using System.Collections;

namespace com.BubbleShooterGame{
	public enum BubbleColor {Red, Blue, Yellow, Green, Black, White};
	public class Bubble {
		
		private BubbleColor _color;
		private Sprite _sprite;
		public Bubble(BubbleColor color){
			this._color = color;
			
		}
		public Bubble(BubbleColor color,Sprite sprite)
		{
			this._color = color;
			this._sprite = sprite;

		}

		public BubbleColor color{
			get{
				return this._color;
			}
			set {
				this._color = value;
			}
		}
		public Sprite sprite
		{
			get
			{
				return this._sprite;
			}
			set
			{
				this._sprite = value;
			}
		}

	}
}
