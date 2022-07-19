using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LinqButton : MonoBehaviour
{
    [HideInInspector]
    public string url;

    void Start()
    {
        var btn = GetComponent<Button>();
        if (btn == null) {
            gameObject.AddComponent<Button>();
            btn = GetComponent<Button>();
        }
        btn.onClick.AddListener(()=> {
            Application.OpenURL(url);
        });
    }
}
