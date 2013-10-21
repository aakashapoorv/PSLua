using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Input;



namespace PSLua
{
	public class mainController
	{
		static GamePadData gamePadData;
		
		
		public string GameKey ()
		{
			gamePadData = GamePad.GetData(0);
			return Convert.ToString(gamePadData.Buttons);
		}
		
		public bool GameKeyBool ()
		{
			gamePadData = GamePad.GetData(0);
			return Convert.ToBoolean(gamePadData.Buttons);
		}
	}
}

