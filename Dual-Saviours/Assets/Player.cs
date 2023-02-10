using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public LayerMask collisionLayers;

	public bool _hasHeart = true;

	public GameObject heartObj;

	public UIManager uIManager;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("obstacle"))
		{
			uIManager.GameOverNegative();
			uIManager.audioManager.PlayPlayerDeadSound();
		}
	}

	public bool HasHeart()
	{
		return _hasHeart;
	}

	public void PutHeart()
	{
		_hasHeart = true;
		SpawnHeart();
	}

	public void RemoveHeart()
	{
		_hasHeart = false;
		DeSpawnHeart();
	}

	void SpawnHeart()
	{
		if (heartObj)
			heartObj.SetActive(true);
	}

	void DeSpawnHeart()
	{
		if (heartObj)
			heartObj.SetActive(false);
	}
}
