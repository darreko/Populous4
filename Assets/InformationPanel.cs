using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public Text TitleTextField;
    public string TitleText;
    public Text ValueTextField;

    private void Start()
    {
        TitleTextField.text = TitleText;
    }

    public void SetValueText(string text)
    {
        ValueTextField.text = text;
    }
}
