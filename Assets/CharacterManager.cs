using UnityEngine;

namespace YK
{
    public class CharacterManager : MonoBehaviour, IControllable
    {
        [SerializeField] private float _speed = 10f;

        private CharacterController _controller;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            MoveInternal();
        }

        public void Move(Vector3 direction)
        {
            _moveDirection = direction;
        }

        private void MoveInternal()
        {
            _controller.Move(_moveDirection * _speed * Time.fixedDeltaTime);
        }
    }
}
