using UnityEngine;

namespace YK
{
    public class UI_Character_Slot : MonoBehaviour
    {
        [Header("Game Slot")]
        public CharacterSlot characterSlot;

        public void LoadIconFromCharacterSlot()
        {
            PCScreenManager.Instance.currentSelectedSlot = characterSlot;
            PCScreenManager.Instance.SelectCharacterIcon(characterSlot);
        }

        public void SelectCurrentSlot()
        {
            PCScreenManager.Instance.SelectCharacterSlot(characterSlot);
            Debug.Log($"SELECTED {characterSlot}");
        }
    }
}
