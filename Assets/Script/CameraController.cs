using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	// 『Sphere』オブジェクトへの参照
	[SerializeField]
	GameObject player;

	// 『Sphere』オブジェクトと『MainCamera』オブジェクトの距離
	Vector3 offset;

	// 拡大率の最小値と最大値
	const float OffsetMin = 50f;
	const float OffsetMax = 150f;

	// カメラの拡大率(%)
	[SerializeField, Range(OffsetMin, OffsetMax)]
	float magnify = 100f;

	void Start()
	{
		// オフセットを計算する
		offset = gameObject.transform.position - player.transform.position;
	}

	void LateUpdate()
	{
		// カメラの拡大率に応じたオフセットを取得
		Vector3 magnifiedOffset = GetMagnifiedOffset();

		// 『Sphere』オブジェクトとオフセットからカメラの現在位置を計算
		gameObject.transform.position = player.transform.position + magnifiedOffset;
	}

	Vector3 GetMagnifiedOffset()
	{
		// 規格化されたオフセットを取得
		Vector3 normalizedOffset = offset.normalized;

		// 『Sphere』オブジェクトとカメラの距離を取得
		float offsetDistance = offset.magnitude;

		// offsetDistanceに拡大率をかけて補正後の距離を取得
		float magnifiedDistance = offsetDistance * magnify / 100f;

		// 規格化されたベクトルと拡大後の距離からオフセットを返す
		Vector3 magnifiedOffset = magnifiedDistance * normalizedOffset;
		return magnifiedOffset;
	}
}


