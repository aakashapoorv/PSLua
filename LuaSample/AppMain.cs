/* 
 * Aakash Apoorv
 */
using System;
using System.Threading;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using LuaInterface;

namespace Sample
{

/**
 * LuaSample
 */
public class LuaSample
{
    static GraphicsContext graphics;
    static bool loop = true;

    static Lua lua;
	static GamePadData gamePadData;
		
		
	static string titleString;
	static int TitleStringX;
		
	static string buttonName;
		


    public static void Main(string[] args)
    {
        Init();
        while (loop) {
            SystemEvents.CheckEvents();
            Update();
            Render();
        }
        Term();
    }

    public static void Init()
    {
        graphics = new GraphicsContext();
        SampleDraw.Init(graphics);

        // Set up LuaInterface
        lua = new Lua();

        // Register C# function
        lua.RegisterFunction("FillCircle", null, typeof(LuaSample).GetMethod("FillCircle"));
		lua.RegisterFunction("MoveText", null, typeof(LuaSample).GetMethod("MoveText"));
		lua.RegisterFunction("btnText", null, typeof(LuaSample).GetMethod("btnText"));
        // Read Lua file
        lua.DoFile("/Application/touch.lua");
			
		titleString = Convert.ToString(lua["TitleString"]);
		TitleStringX = Convert.ToInt32(lua["TitleStringX"]);
			
<<<<<<< HEAD
			buttonName= "nil";

		
		
=======
		buttonName= "nil";
>>>>>>> 27ba49d2a274c352ed94cfdb8a630b52f57fad44
        
    }

    public static void Term()
    {
        // Close LuaInterface
        lua.Dispose();

        SampleDraw.Term();
        graphics.Dispose();
    }
		PSLua.mainController mc = new PSLua.mainController();

    public static void Update()
			
    {
<<<<<<< HEAD
			PSLua.mainController mc = new PSLua.mainController();
			string mys = mc.GameKey();
			bool myb = mc.GameKeyBool();
			
			
			if(myb)
			{
				//Console.WriteLine(mys);
            }
			
			bool isBtnDown = myb;
			var btnLua = mys;
			lua.GetFunction("OnPress").Call(btnLua, isBtnDown);
=======
		gamePadData = GamePad.GetData(0);
		if((gamePadData.Buttons & GamePadButtons.Left) != 0)
		{
			Console.WriteLine(gamePadData.Buttons);
			
            	}
			
		if((gamePadData.Buttons) != 0)
		{
			Console.WriteLine(gamePadData.Buttons);
		
            	}
			
		bool isBtnDown = true;
		if ((gamePadData.Buttons) != 0)
		{
			isBtnDown = true;
		}
		else
		{
			isBtnDown = false;
		}
		var btnLua = Convert.ToString(gamePadData.Buttons);
		lua.GetFunction("OnPress").Call(btnLua, isBtnDown);
>>>>>>> 27ba49d2a274c352ed94cfdb8a630b52f57fad44
			
        	SampleDraw.Update();

			
			
			
    }

		
    public static void Render()
    {
        graphics.SetClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        graphics.Clear();

        foreach (var touchData in Touch.GetData(0)) {
            if (touchData.Status == TouchStatus.Down ||
                touchData.Status == TouchStatus.Move) {

                // Call Lua function
                int pointX = (int)((touchData.X + 0.5f) * SampleDraw.Width);
                int pointY = (int)((touchData.Y + 0.5f) * SampleDraw.Height);
                bool isDown = touchData.Status == TouchStatus.Down;
                lua.GetFunction("OnTouch").Call(pointX, pointY, isDown);
				
				
            }
        }

        // Get Lua variables
        
        var colorIndex = Convert.ToInt32(lua["ColorIndex"]);
        var message = string.Format("Color {0}", colorIndex);

        
        SampleDraw.DrawText(message, 0xffffffff, 0, graphics.Screen.Height - 24);
			
				SampleDraw.DrawText(buttonName, 0xffffffff, 0, 0);

        graphics.SwapBuffers();
    }

    public static void FillCircle(uint argb, int pointX, int pointY, int radius)
    { 
        SampleDraw.FillCircle(argb, pointX, pointY, radius); 
			
		
    }
		
	public static void MoveText (int arg)
		{
			//buttonName = Convert.ToString(gamePadData.Buttons);
		}
	public static void btnText(string arg)
		{
			buttonName = arg;
		}
		
	public static void btnCircle ()
		{
			SampleDraw.DrawText("Circle Pressed", 0xffffffff, 200, 200);
		}
}

} // Sample
