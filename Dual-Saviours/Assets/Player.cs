using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public LayerMask collisionLayers;

	public bool _hasHeart = true;

	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log("collided!!" + other.name);
	}

	public bool HasHeart()
	{
		return _hasHeart;
	}

	public void PutHeart()
	{
		_hasHeart = true;
	}

	public void RemoveHeart()
	{
		_hasHeart = false;
	}
}
