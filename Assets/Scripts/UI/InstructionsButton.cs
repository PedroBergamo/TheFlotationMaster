using UnityEngine;
using UnityEngine.UI;

    public class InstructionsButton : MonoBehaviour
    {
        public InstructionsManager Instructions;

        public void ButtonClicked()
        {
            InstructionsManager.GivenAnswer = gameObject.transform.GetSiblingIndex();
            Instructions.CheckIfRightAnswer();
        }

        void Start()
        {
            var button = transform.GetComponent<Button>();
        }
}
