using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

	//public float secondsPerMinute = 0.625f;
	//float startTime = 0f;
	public float speed = 100;
	public float latitudeAngle = 45f;
		
	public Transform sunTilt;
	private float smoothMin = 0;
	private float texOffset;
	private Material skyMat;
	private Transform sunOrbit;

	public bool day2Night = false;
	public bool night2Day = false;

	
	void Start () {
		skyMat = GetComponent<Renderer>().sharedMaterial;
		sunOrbit = sunTilt.GetChild(0);

		sunTilt.eulerAngles = new Vector3(Mathf.Clamp(latitudeAngle,0,90),0,0); //set the sun tilt

		Transition();

		//if(secondsPerMinute==0){
		//	Debug.LogError("Error! Can't have a time of zero, changed to 0.01 instead.");
		//	secondsPerMinute = 0.01f;
		//}
	}
	
	// Update is called once per frame
	void Update () {

		//Transition();
		print(sunOrbit.localEulerAngles.y);

		
		if (day2Night)
		{
			if (sunOrbit.localEulerAngles.y < 360)
			{
				Transition();
			}
			else
			{
				day2Night = false;
			}
		}
		
		if (night2Day)
		{
			if (sunOrbit.localEulerAngles.y < 180)
			{
				Transition();
			}
			else
			{
				night2Day = false;
			}
		}
	}

	void Transition()
	{
		//smoothMin = (Time.time / secondsPerMinute) + (startTime * 60);
		//smoothMin = ((Time.time - startTime) / secondsPerMinute);
		smoothMin += Time.deltaTime * speed;
		smoothMin = smoothMin - (Mathf.Floor(smoothMin / 1440f) * 1440); //clamp smoothMin between 0-1440
		//print(smoothMin);
		

		sunOrbit.localEulerAngles = new Vector3(0, smoothMin / 4f, 0);
		texOffset = Mathf.Cos((((smoothMin) / 1440f) * 2f) * Mathf.PI) * 0.25f + 0.25f;
		skyMat.mainTextureOffset =
		new Vector2(Mathf.Round((texOffset - (Mathf.Floor(texOffset / 360f) * 360)) * 1000) / 1000f, 0);
	}
}
