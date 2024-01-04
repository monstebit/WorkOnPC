using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace YK
{
    public class CharacterInputManager : MonoBehaviour
    {
        public float raycastDistance = 5f; // Дистанция Raycast

        private ComputerInteraction computerInteraction;

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

        private void Start()
        {
            computerInteraction = GetComponent<ComputerInteraction>();
            if (computerInteraction == null)
            {
                Debug.LogError("ComputerInteraction script not found on the same GameObject.");
            }
        }

        private void Update()
        {
            ReadMovement();
            PcInteracte();

            // Создаем луч из позиции игрока в направлении вперед
            Ray ray = new Ray(transform.position, transform.forward);

            // Переменная для хранения информации о столкновении луча
            RaycastHit hit;

            // Проверяем, сталкивается ли луч с объектом
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // Отрисовываем линию от позиции игрока до точки столкновения
                Debug.DrawLine(ray.origin, hit.point, Color.red);

                // Визуализация точки столкновения с объектом
                Debug.DrawRay(hit.point, hit.normal * 0.2f, Color.green);

                // Ваша логика обработки столкновения
                // Например, вы можете обрабатывать информацию о столкновении (hit) здесь
            }
            else
            {
                // Если луч не сталкивается с объектом, отрисовываем линию на максимальное расстояние
                Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.blue);
            }
        }

        private void ReadMovement()
        {
            var inputDirection = _playerControls.Actions.Movement.ReadValue<Vector2>();
            var direction = new Vector3(inputDirection.x, 0f, inputDirection.y);

            _controllable.Move(direction);
        }

        void PcInteracte()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                computerInteraction.EnterComputerMode();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                computerInteraction.ExitComputerMode();
            }
        }
    }
}
