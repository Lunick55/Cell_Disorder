using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode curseMode = CursorMode.Auto;
	public Vector2 mainSpot = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseEnter()
	{
		Debug.Log ("NEW MOUSE");
		Cursor.SetCursor (cursorTexture, mainSpot, curseMode);
	}

	void OnMouseExit()
	{
		Cursor.SetCursor (cursorTexture, mainSpot, curseMode);
	}

}
