using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Jump;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    XRRayInteractor m_ARInteractor;

    [SerializeField] private Transform m_SkatePosition;
    [SerializeField] private Rigidbody m_SkateRigdy;

    private ARRaycastHit _m_lastHit;

	void Start()
	{

	}

	void Update()
	{
		if (HasHitTarget(out var hit))
		{
			m_SkateRigdy.ResetInertiaTensor();
			m_SkateRigdy.rotation.Set(0f,0f,0f, 0f);
			m_SkateRigdy.Move(hit.pose.position, Quaternion.identity);
		}

	}

	public void JumpPlayer()
	{
		m_SkateRigdy.linearVelocity = Vector3.up * 2;
	}

	public void RotLeftPlayer()
	{
		m_SkateRigdy.AddTorque(Vector3.up * -5);
	}
	
	public void RotRightPlayer()
	{
		m_SkateRigdy.AddTorque(Vector3.up * 5);
	}

	bool HasHitTarget(out ARRaycastHit _hit)
	{
		if (m_ARInteractor.TryGetCurrentARRaycastHit(out var hit))
		{
			if (_m_lastHit == hit)
			{
				_hit = hit;
				return false;
			}

			_hit = hit;
			return true;
		}
		
		_hit = new ARRaycastHit();
		return false;
	}
}
