using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAutoSettings.UI
{
    public class SettingsItemEventListener : MonoBehaviour
    {
        [HideInInspector]
        public int order;
        public UIItemValueField field;
        public event System.Action<string, string> OnValueChangedEvent;

        private void Awake()
        {
            if(field == null)
                field = transform.GetComponentsInChildren<UIItemValueField>().First();
            if (field == null)
                field = transform.GetComponent<UIItemValueField>();
        }

        public void OnValueChanged(float value)
        {
            OnValueChangedEvent?.Invoke("slider", value.ToString());
        }

        public void TextChanged(string value)
        {
            OnValueChangedEvent?.Invoke("text-value", value);
        }

        public void OnClick()
        {
            OnValueChangedEvent?.Invoke("button", "submit");
        }

        public void ToggleChanged(bool value)
        {
            OnValueChangedEvent?.Invoke("toggle", value.ToString());
        }

        public void SubmitInputText(UnityEngine.UI.InputField field) {
            TextChanged(field.text);
        }
    }
}
