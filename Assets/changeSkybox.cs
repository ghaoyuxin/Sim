using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class changeSkybox : MonoBehaviour
{

	//public Material SkyboxOne;
	public Material SkyboxTwo;
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			RenderSettings.skybox = SkyboxTwo;
			//new music
		}
	}
}
