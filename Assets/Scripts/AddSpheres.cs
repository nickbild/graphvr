using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class AddSpheres : MonoBehaviour {

	private GameObject gameObj;
	private float minX = 0;
	private float maxX = 0;
	private float minY = 0;
	private float maxY = 0;
	private float minZ = 0;
	private float maxZ = 0;

	void Start () {
		string fileName = @"data.txt";
		string str;

		StreamReader file = new StreamReader(fileName);  
		while((str = file.ReadLine()) != null) {  
			str = Regex.Replace(str, @"\r\n?|\n", "");
			string[] tokens = str.Split('\t');

			DrawSphere(System.Convert.ToSingle(tokens[0]), System.Convert.ToSingle(tokens[1]), System.Convert.ToSingle(tokens[2]));
			FindMinMaxBounds(System.Convert.ToSingle(tokens[0]), System.Convert.ToSingle(tokens[1]), System.Convert.ToSingle(tokens[2]));
		}
		file.Close();

		DrawAxis(new Vector3 (0, minY, 0), new Vector3 (0, maxY, 0), new Color(66f/255f, 244f/255f, 144f/255f));
		DrawAxis(new Vector3 (minX, 0, 0), new Vector3 (maxX, 0, 0), new Color(116f/255f, 66f/255f, 244f/255f));
		DrawAxis(new Vector3 (0, 0, minZ), new Vector3 (0, 0, maxZ), new Color(244f/255f, 232f/255f, 66f/255f));
	}

	void OnGUI() {
        	GUI.enabled = true;

		string fileName = @"data.txt";
		string str;

		StreamReader file = new StreamReader(fileName);  
		while((str = file.ReadLine()) != null) {  
			str = Regex.Replace(str, @"\r\n?|\n", "");
			string[] tokens = str.Split('\t');

			Vector3 pos = Camera.main.WorldToViewportPoint(new Vector3(System.Convert.ToSingle(tokens[0]), System.Convert.ToSingle(tokens[1]), System.Convert.ToSingle(tokens[2])));

			// Is current label location in camera view?
			if ( (pos.x >= 0 && pos.x <= 1) && (pos.y >= 0 && pos.y <= 1) && pos.z > 0) {
				DrawLabel(System.Convert.ToSingle(tokens[0]), System.Convert.ToSingle(tokens[1]), System.Convert.ToSingle(tokens[2]), tokens[3]);			
			}
		}
     	}

	void DrawAxis(Vector3 start, Vector3 end, Color color) {
        	GameObject myLine = new GameObject();
             	myLine.transform.position = start;
             	myLine.AddComponent<LineRenderer>();
             	LineRenderer lr = myLine.GetComponent<LineRenderer>();
             	lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.numCornerVertices = 12;
		lr.numCapVertices = 12;
             	lr.startColor = color;
		lr.endColor = color;
             	lr.startWidth = 0.2f;
		lr.endWidth = 0.2f;
             	lr.SetPosition(0, start);
             	lr.SetPosition(1, end);
	}

	void DrawSphere(float x, float y, float z) {
		gameObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		gameObj.GetComponent<Renderer> ().material.color = new Color(66f/255f, 134f/255f, 244f/255f);
		gameObj.transform.position = new Vector3 (x, y, z);
	}

	void FindMinMaxBounds(float x, float y, float z) {
		minX = Math.Min (minX, x);
		maxX = Math.Max (maxX, x);
		minY = Math.Min (minY, y);
		maxY = Math.Max (maxY, y);
		minZ = Math.Min (minZ, z);
		maxZ = Math.Max (maxZ, z);
	}

	void DrawLabel(float x, float y, float z, string label) {
		Vector3 pos = Camera.main.WorldToScreenPoint(new Vector3(x, y, z));
		GUI.contentColor = Color.white;
	       	GUI.Label(new Rect(pos.x-15,Screen.height-pos.y-10,150,130), label);
	}

}

