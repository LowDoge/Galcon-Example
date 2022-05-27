using UnityEngine;

namespace Galcon.Core.Components
{
    public sealed class Spinner : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationAnglePerSecond;
        private Transform _selfTransform;

        private void Awake() => _selfTransform = transform;

        private void Update() => RotationTick(Time.deltaTime);

        private void RotationTick(float deltaTime) => _selfTransform.Rotate(_rotationAnglePerSecond * deltaTime);
    }
}
