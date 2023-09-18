﻿using System.Collections.Generic;
using Carbon;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
public class RustAsset : MonoBehaviour
{
	public static List<RustAsset> assets = new ();

	public string Path;

	[Header("Auto-assigned")]
	public Vector3 Position;
	public Quaternion Rotation;
	public Vector3 Scale;

	internal GameObject _instance;
	internal float _timeSinceRetry;

	public void Cache()
	{
		Position = transform.position;
		Rotation = transform.rotation;
		Scale = transform.localScale;
	}

	public bool HasChanged(out Vector3 pos, out Quaternion rot, out Vector3 scale)
	{
		pos = transform.position;
		rot = transform.rotation;
		scale = transform.localScale;

		if (Position != pos || Rotation != rot || Scale != scale)
		{
			Position = pos;
			Rotation = rot;
			Scale = scale;
			return true;
		}

		return false;
	}

	public void OnEnable()
	{
		Fetch();
	}
	public void OnDestroy()
	{
		Cleanup();

		if (assets.Contains(this))
		{
			assets.Remove(this);
		}
	}

	public void Awake()
	{
		Fetch();
		Preview();
	}
	public void Tick()
	{
		if (_instance == null)
		{
			return;
		}

		if (HasChanged(out var pos, out var rot, out var scale) && _instance != null)
		{
			_instance.transform.SetPositionAndRotation(pos, rot);
			_instance.transform.localScale = scale;
		}
	}

	public void Preview()
	{
		try
		{
			Fetch();

			if (Defines.IsBuildingAddons || RustAssetProcessor.Prefabs == null || RustAssetProcessor.PrefabLookup == null)
			{
				return;
			}

			if (RustAssetProcessor.Instance != null && !RustAssetProcessor.Instance.CreateVisuals)
			{
				return;
			}

			Cleanup();

			var prefab = RustAssetProcessor.PrefabLookup.backend.LoadPrefab(Path);
			var previewContainer = Defines.Singleton.GetPreviewContainer();

			if (prefab != null && previewContainer != null)
			{
				_instance = Instantiate(prefab);
				_instance.transform.SetParent(previewContainer);
				_instance.transform.SetLocalPositionAndRotation(transform.position, transform.rotation);
				_instance.transform.localScale = transform.localScale;
				_instance.SetActive(true);
				_instance.tag = "EditorOnly";
			}
		}
		catch { }
	}
	public void Cleanup()
	{
		try
		{
			if (_instance != null)
			{
				DestroyImmediate(_instance);
				_instance = null;
			}

			foreach (Transform child in transform)
			{
				DestroyImmediate(child.gameObject);
			}
		}
		catch { }
	} 
	public void Fetch()
	{
		if (!assets.Contains(this))
		{
			assets.Add(this);
		}
	}

	public static void Scan(bool cleanup = false)
	{
		assets.Clear();
		assets.AddRange(FindObjectsOfType<RustAsset>());

		if (cleanup)
		{
			foreach (var asset in assets)
			{
				asset.Cleanup();
			}
		}
	}
	public static void PreviewAll()
	{
		foreach(var asset in assets)
		{
			asset.Preview();
		}
	}

	public void OnGUI()
	{

	}
}
