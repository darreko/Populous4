using System;
using UnityEngine.UI;

[Serializable]
public class Displayable<T>
{
    private T _value = default;

    public T Value
    {
        get { return _value; }
        set
        {
            _value = value;

            if (ValueText != null)
            {
                ValueText.text = value.ToString();
            }
        }
    }

    public Text ValueText;
}
