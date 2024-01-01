using System;
using UnityEngine;

namespace YK
{
    public class CharacterInputManager : MonoBehaviour
    {
        private IControllable _controllable;
        private PlayerControls _playerControls;

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _playerControls.Enable();

            _controllable = GetComponent<IControllable>();

            if ( _controllable == null )
            {
                throw new Exception($"There is no IControllable component on the objects: {gameObject.name}");
            }
        }

        private void Update()
        {
            ReadMovement();
        }

        private void ReadMovement()
        {
            var inputDirection = _playerControls.Actions.Movement.ReadValue<Vector2>();
            var direction = new Vector3(inputDirection.x, 0f, inputDirection.y);

            _controllable.Move(direction);
        }
    }
}
