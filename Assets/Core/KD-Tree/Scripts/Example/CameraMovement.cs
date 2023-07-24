using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    private void FixedUpdate() => transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + _rotation * Time.fixedDeltaTime);
}
