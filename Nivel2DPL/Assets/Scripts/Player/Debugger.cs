using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debugger 
{
	public static void LaunchAssert(bool condition, string message, GameObject context)
	{
		if(condition)
		{
			return;
		}
		Debug.Assert(condition, message, context);
		
#if UNITY_EDITOR
		UnityEditor.EditorUtility.DisplayDialog("Assert!", message, "Ok");
#endif // UNITY_EDITOR
	}
}
