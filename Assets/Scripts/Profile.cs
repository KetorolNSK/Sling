using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public Text textProfile;
    public InputField inputField;
    void Start()
    {
        textProfile.text = SaveText.MyName;
    }

    public void LoadText()
    {
        SaveText.MyName = inputField.text;
    }
}
