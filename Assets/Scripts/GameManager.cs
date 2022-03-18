using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private InputManager inputManager;
	[SerializeField] private CubeSpawner cubeSpawner;

	private void Start()
	{
		SpawningData initialData = inputManager.Init();
		cubeSpawner.SetData(initialData);
		inputManager.inputChanged += cubeSpawner.SetData;
		cubeSpawner.StartSpawning();
	}

	private void OnDisable()
	{
		inputManager.inputChanged -= cubeSpawner.SetData;
	}
}
