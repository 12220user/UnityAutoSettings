using UnityEngine;

public class UIItemValueField : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text field;
    [SerializeField]
    private UnityEngine.UI.InputField fieldInput;
    [SerializeField]
    private UnityEngine.UI.Toggle fieldToggle;

    public void SetValue(string value) {
        if (field != null)
            field.text = value;
        if (fieldInput != null)
            fieldInput.text = value;
        if (fieldToggle != null)
            SetValue(bool.Parse(value));
    }

    private void SetValue(bool b) {
        fieldToggle.isOn = b;
    }
}
