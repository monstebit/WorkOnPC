using UnityEngine;
using UnityEngine.InputSystem;

namespace YK
{
    public class ComputerInteraction : MonoBehaviour
    {
        public Camera mainCamera;
        public Camera computerCamera;
        public Transform computerUI;

        private bool isInComputerMode = false;

        void Start()
        {
            // Начинаем с того, что устанавливаем приоритет камеры компьютера ниже
            computerCamera.depth = -1;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        void Update()
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (!isInComputerMode)
                {
                    EnterComputerMode();
                }
                else
                {
                    ExitComputerMode();
                }
            }
        }

        public void EnterComputerMode()
        {
            PCScreenManager.Instance.PCCanvasGroup.blocksRaycasts = true;

            isInComputerMode = true;
            // Устанавливаем приоритет камеры компьютера выше
            computerCamera.depth = 30;
        }

        public void ExitComputerMode()
        {
            PCScreenManager.Instance.PCCanvasGroup.blocksRaycasts = false;

            isInComputerMode = false;
            // Возвращаем приоритет камеры компьютера ниже
            computerCamera.depth = -1;
        }
    }
}
