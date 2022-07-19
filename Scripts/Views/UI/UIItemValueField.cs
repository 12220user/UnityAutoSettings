using UnityEngine;

public class UIItemValueField : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text field;
    [SerializeField]
    private UnityEngine.UI.InputField fieldInput;
    [SerializeField]
    private UnityEngine.UI.Toggle fieldToggle;
    [SerializeField]
    private LinqButton linq;

    public void SetValue(string value) {
        
        if (fieldInput != null)
            fieldInput.text = value;
        if (fieldToggle != null)
            SetValue(bool.Parse(value));
        if (linq != null) {
            string[] values = value.Split('|');
            if (values.Length == 2)
            {
                linq.url = values[1];
                if (field != null)
                {
                    field.text = values[0];
                }
            }
            else if (values.Length == 1) {
                linq.url = values[0];
                if (field != null)
                {
                    field.text = values[0];
                }
            }
        }
        else if (field != null)
            field.text = value;
    }

    private void SetValue(bool b) {
        fieldToggle.isOn = b;
    }
}
