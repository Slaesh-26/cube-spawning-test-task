using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField] private CubeMovement cubeToSpawn;

	private SpawningData data;
	
	public void StartSpawning()
	{
		StartCoroutine(SpawnCoroutine());
	}

	public void SetData(SpawningData data)
	{
		this.data = data;
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			SpawnCube();
			yield return new WaitForSeconds(data.spawnDelay);
		}
	}

	private void SpawnCube()
	{
		CubeMovement cube = Instantiate(cubeToSpawn, transform.position, Quaternion.identity);
		cube.Init(data.speed, data.distance, transform.forward);
	}
}
