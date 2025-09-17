using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotate = new Vector3(0f, 45f, 5f);
    private Rigidbody _rigidbody;

    private IEnumerator Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody not found on this object!", this);
            yield break;
        }

        _rigidbody.isKinematic = true;

        while (true)
        {
            RotateKinematicBody();

            yield return null;
        }
    }

    private void RotateKinematicBody()
    {
        Quaternion deltaRotation = Quaternion.Euler(_rotate * Time.deltaTime);

        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }

    public void SetRotationSpeed(Vector3 newRotation)
    {
        _rotate = newRotation;
    }

    public void StopRotation()
    {
        StopAllCoroutines();
    }

    public void ResumeRotation()
    {
        StartCoroutine(Start());
    }
}
