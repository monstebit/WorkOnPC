using UnityEngine;
using UnityEngine.UI;

namespace YK
{
    public class PCScreenManager : MonoBehaviour
    {
        public static PCScreenManager Instance;

        [Header("Character Slot")]
        public CharacterSlot currentSelectedSlot = CharacterSlot.NO_SLOT;

        [Header("Character Icon")]
        public Image imageComponent;
        public Sprite slot1Sprite;
        public Sprite slot2Sprite;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SelectCharacterSlot(CharacterSlot characterSlot)
        {
            currentSelectedSlot = characterSlot;
        }

        public void SelectCharacterIcon(CharacterSlot selectedSlot)
        {
            switch (selectedSlot)
            {
                case CharacterSlot.CharacterSlot_01:
                    imageComponent.sprite = slot1Sprite;
                    break;
                case CharacterSlot.CharacterSlot_02:
                    imageComponent.sprite = slot2Sprite;
                    break;
                case CharacterSlot.NO_SLOT:
                    break;
                default:
                    break;
            }
        }
    }
}
