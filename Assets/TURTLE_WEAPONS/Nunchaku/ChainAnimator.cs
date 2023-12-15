using System;
using UnityEngine;
using UnityEngine.Rendering;

public class ChainAnimator : MonoBehaviour
{
	public Transform origin;

	public Transform end;

	public int midPoints;

	public float clampAngleTo;

	public Mesh mesh;

	public Material material;

	public float linkLength;

	public float linkScale = 1f;

	private Vector3[] pos;

	private Matrix4x4[] matrices;

	private void Start()
	{
		pos = new Vector3[midPoints];
		matrices = new Matrix4x4[midPoints];
	}

	private void Update()
	{
		Vector3 from = end.position - origin.position;
		Vector3 forward = origin.forward;
		float num = Mathf.Clamp(Vector3.Angle(from, forward), 0f - clampAngleTo, clampAngleTo);
		float num2 = Mathf.Clamp(from.magnitude / (2f * Mathf.Cos(num * ((float)Math.PI / 180f))), 0f, from.magnitude / (float)midPoints * 2f);
		Vector3 topPoint = origin.position + origin.forward * num2;
		for (int i = 0; i < midPoints; i++)
		{
			float t = ((float)i + 1f) / ((float)midPoints + 1f);
			pos[i] = GetPointAt(t, topPoint);
		}
		for (int j = 0; j < midPoints - 1; j++)
		{
			float num3 = Vector3.Distance(pos[j], pos[j + 1]);
			matrices[j].SetTRS(pos[j], Quaternion.LookRotation(pos[j + 1] - pos[j], (j % 2 == 0) ? origin.up : origin.right), new Vector3(1f, 1f, Mathf.Clamp(num3 / linkLength, 1f, 10f)) * linkScale);
		}
		float num4 = Vector3.Distance(pos[midPoints - 1], end.position);
		matrices[midPoints - 1].SetTRS(pos[midPoints - 1], Quaternion.LookRotation(end.position - pos[midPoints - 1]), new Vector3(1f, 1f, Mathf.Clamp(num4 / linkLength, 1f, 10f)) * linkScale);
		Graphics.DrawMeshInstanced(mesh, 0, material, matrices, midPoints, null, ShadowCastingMode.Off, false);
	}

	private Vector3 GetPointAt(float t, Vector3 topPoint)
	{
		return (1f - t) * (1f - t) * origin.transform.position + 2f * (1f - t) * t * topPoint + t * t * end.position;
	}
}
