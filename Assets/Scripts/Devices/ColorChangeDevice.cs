﻿using UnityEngine;

namespace Game.Devices
{
	public class ColorChangeDevice : BaseDevice
	{
		protected override void Operate() {
			Color random = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
			this.gameObject.GetComponent<Renderer>().material.color = random;
		}
	}	
}
