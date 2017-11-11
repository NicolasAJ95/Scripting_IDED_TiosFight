using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPool : MonoBehaviour {

	private static BloodPool instance;

	public static BloodPool Instance
	{
		get
		{
			return instance;
		}
	}

	[SerializeField]
	private GameObject bloodPrefab;

	[SerializeField]
	private int size;

	private List<GameObject> bloodParticles;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			PrepareBlood();
		}
		else
			Destroy(gameObject);
	}

	private void PrepareBlood()
	{
		bloodParticles = new List<GameObject>();
		for (int i = 0; i < size; i++)
			AddBlood();
	}

	public GameObject GetBlood()
	{
		if (bloodParticles.Count == 0)
			AddBlood();
		return AllocateBloodParticle();
	}

	public void ReleaseBlood(GameObject blood)
	{
		blood.gameObject.SetActive(false);
		bloodParticles.Add(blood);
	}

	private void AddBlood()
	{
		GameObject instance = Instantiate(bloodPrefab) as GameObject;
		instance.gameObject.SetActive(false);
		bloodParticles.Add(instance);
	}

	private GameObject AllocateBloodParticle()
	{
		GameObject blood = bloodParticles[bloodParticles.Count - 1];
		bloodParticles.RemoveAt(bloodParticles.Count - 1);
		blood.gameObject.SetActive(true);
		return blood;
	}
}
