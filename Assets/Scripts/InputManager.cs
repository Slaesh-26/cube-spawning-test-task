using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public event Action<SpawningData> inputChanged;
	
	[Header("Input Fields")]
	[SerializeField] private TMP_InputField distanceField;
	[SerializeField] private TMP_InputField speedField;
	[SerializeField] private TMP_InputField spawnDelayField;

	[Header("Ranges")]
	[SerializeField] private FloatRange distanceRange;
	[SerializeField] private FloatRange speedRange;
	[SerializeField] private FloatRange spawnDelayRange;

	public SpawningData Init()
	{
		distanceField.onValueChanged.AddListener(OnAnyValueChanged);
		speedField.onValueChanged.AddListener(OnAnyValueChanged);
		spawnDelayField.onValueChanged.AddListener(OnAnyValueChanged);

		return GetCurrentData();
	}

	private void OnDisable()
	{
		distanceField.onValueChanged.RemoveListener(OnAnyValueChanged);
		speedField.onValueChanged.RemoveListener(OnAnyValueChanged);
		spawnDelayField.onValueChanged.RemoveListener(OnAnyValueChanged);
	}

	private void OnAnyValueChanged(string newValue)
	{
		SpawningData data = GetCurrentData();
		inputChanged?.Invoke(data);
	}

	private SpawningData GetCurrentData()
	{
		float speed = 1f;
		float distance = 1f;
		float spawnDelay = 1f;
		
		try
		{
			speed = float.Parse(speedField.text);
			distance = float.Parse(distanceField.text);
			spawnDelay = float.Parse(spawnDelayField.text);
		}
		catch (FormatException e)
		{
			speed = 1f;
			distance = 1f;
			spawnDelay = 1f;

			Debug.LogWarning("Incorrect input");
		}

		speed = Mathf.Clamp(speed, speedRange.minValue, speedRange.maxValue);
		distance = Mathf.Clamp(distance, distanceRange.minValue, distanceRange.maxValue);
		spawnDelay = Mathf.Clamp(spawnDelay, spawnDelayRange.minValue, spawnDelayRange.maxValue);
		
		speedField.text = speed.ToString(CultureInfo.CurrentCulture);
		distanceField.text = distance.ToString(CultureInfo.CurrentCulture);
		spawnDelayField.text = spawnDelay.ToString(CultureInfo.InvariantCulture);
		
		SpawningData data = new SpawningData(speed, distance, spawnDelay);

		return data;
	}
	
	[Serializable]
	private struct FloatRange
	{
		public float minValue;
		public float maxValue;
	}
}
