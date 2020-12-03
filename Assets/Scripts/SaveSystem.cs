using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public GameObject namePan;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Name")) namePan.SetActive(true);
        else PlayerPrefs.GetString("Name");
    }

    public void CheckName(string name)
    {
        if (!string.IsNullOrEmpty(name) && name.Length >= 3)
        {
            PlayerPrefs.SetString("Name", name);
            Debug.Log("Ваше имя: " + name);
        }
        else Debug.Log("Имя должно быть не короче 3-х символов");
    }
}
