using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeDayNight : MonoBehaviour {

	public bool changeNight2Day;
	public DayNight dn;
	private AudioSource swoosh;

	void Start()
	{
		swoosh = GetComponent<AudioSource>();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if (changeNight2Day)
			{
				dn.night2Day = true;
				swoosh.Play();
			}
			else
			{
				dn.day2Night = true;
			}
			
		}
	}
}

