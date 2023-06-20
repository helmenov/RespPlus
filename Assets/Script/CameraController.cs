using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	// �wSphere�x�I�u�W�F�N�g�ւ̎Q��
	[SerializeField]
	GameObject player;

	// �wSphere�x�I�u�W�F�N�g�ƁwMainCamera�x�I�u�W�F�N�g�̋���
	Vector3 offset;

	// �g�嗦�̍ŏ��l�ƍő�l
	const float OffsetMin = 50f;
	const float OffsetMax = 150f;

	// �J�����̊g�嗦(%)
	[SerializeField, Range(OffsetMin, OffsetMax)]
	float magnify = 100f;

	void Start()
	{
		// �I�t�Z�b�g���v�Z����
		offset = gameObject.transform.position - player.transform.position;
	}

	void LateUpdate()
	{
		// �J�����̊g�嗦�ɉ������I�t�Z�b�g���擾
		Vector3 magnifiedOffset = GetMagnifiedOffset();

		// �wSphere�x�I�u�W�F�N�g�ƃI�t�Z�b�g����J�����̌��݈ʒu���v�Z
		gameObject.transform.position = player.transform.position + magnifiedOffset;
	}

	Vector3 GetMagnifiedOffset()
	{
		// �K�i�����ꂽ�I�t�Z�b�g���擾
		Vector3 normalizedOffset = offset.normalized;

		// �wSphere�x�I�u�W�F�N�g�ƃJ�����̋������擾
		float offsetDistance = offset.magnitude;

		// offsetDistance�Ɋg�嗦�������ĕ␳��̋������擾
		float magnifiedDistance = offsetDistance * magnify / 100f;

		// �K�i�����ꂽ�x�N�g���Ɗg���̋�������I�t�Z�b�g��Ԃ�
		Vector3 magnifiedOffset = magnifiedDistance * normalizedOffset;
		return magnifiedOffset;
	}
}


