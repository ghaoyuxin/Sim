using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkybox2 : MonoBehaviour {


		//public Material SkyboxOne;
		public Material SkyboxThree;
	
		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.CompareTag("Player"))
			{
				RenderSettings.skybox = SkyboxThree;
				//new music
			}
		}
	}