using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {
	
	// radar! by oPless from the original javascript by PsychicParrot, 
	// who in turn adapted it from a Blitz3d script found in the
	// public domain online somewhere ....
	// adapted by iseratho
	
	
	public Texture blip;
	public Texture radarBG;
	
	public Transform centerObject ;
	public float mapScale = 1.3f;
	public Vector2 mapCenter = new Vector2(Screen.width,Screen.height);
	public string tagFilter =  "PickUp";
	public float maxDist = 200;
	public int width = 80;
	public int height = 80;
	public int minimap_posx = 40; //offset
	public int minimap_posy = 40; //offset
	public int screen_offset = 10;
	public int blip_size = 4;
	
	//public GameObject player;
	//private Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() 
	{
		
		//	GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, Vector3(Screen.width / 600.0, Screen.height / 450.0, 1));
		
		// Draw player blip (centerObject)
		//		float bX=centerObject.transform.position.x * mapScale;
		//	    float bY=centerObject.transform.position.z * mapScale;
		
		//calculates minimap center
		mapCenter = new Vector2(Screen.width - width - screen_offset,0 + height + screen_offset);
		
		GUI.DrawTexture(new Rect(mapCenter.x-minimap_posx,mapCenter.y-minimap_posy, width, height),radarBG);
		DrawBlipsFor(tagFilter);
		
	}
	
	private void DrawBlipsFor(string tagName)
	{
		
		// Find all game objects with tag 
		GameObject[] gos = GameObject.FindGameObjectsWithTag(tagName); 
		
		// Iterate through them
		foreach (GameObject go in gos)  
		{ 
			drawBlip(go,blip);
		}
	}
	
	private void drawBlip(GameObject go,Texture aTexture)
	{
		Vector3 centerPos=centerObject.position;
		Vector3 extPos=go.transform.position;
		
		// first we need to get the distance of the enemy from the player
		float dist=Vector3.Distance(centerPos,extPos);
		
		float dx=centerPos.x-extPos.x; // how far to the side of the player is the enemy?
		float dz=centerPos.z-extPos.z; // how far in front or behind the player is the enemy?
		
		// what's the angle to turn to face the enemy - compensating for the player's turning?
		//float deltay=Mathf.Atan2(dx,dz)*Mathf.Rad2Deg - 270 - centerObject.eulerAngles.y;
		
		// just basic trigonometry to find the point x,y (enemy's location) given the angle deltay
		//float bX=dist*Mathf.Cos(deltay * Mathf.Deg2Rad);
		//float bY=dist*Mathf.Sin(deltay * Mathf.Deg2Rad);
		
		//bX=bX*mapScale; // scales down the x-coordinate by half so that the plot stays within our radar
		//bY=bY*mapScale; // scales down the y-coordinate by half so that the plot stays within our radar
		
		dx=dx*mapScale; // scales down the x-coordinate by half so that the plot stays within our radar
		dz=dz*mapScale; // scales down the y-coordinate by half so that the plot stays within our radar
		
		if(dist<= maxDist)
		{ 
			// this is the diameter of our largest radar circle
			GUI.DrawTexture(new Rect(mapCenter.x-dx,mapCenter.y+dz,blip_size,blip_size),aTexture);
		}
	}	
}