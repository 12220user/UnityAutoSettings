using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAutoSettings;
using UnityAutoSettings.UI.Source;
using UnityAutoSettings.UI;

public class SettingsControler : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Use from realtime change UI")]
    private bool isDebug = false;
    [Space(25)]
    [SerializeField]
    private string path;
    [SerializeField]
    private SettingsUISource source;
    private SettingsObject settings;
    public SettingsObject Settings { get { return settings; } }
    [SerializeField]
    private GameObject parrent;

    private string lastChanged;

    private void Awake()
    {
        if (parrent == null) parrent = this.gameObject;
        path = Application.streamingAssetsPath + path;
        init();
        if (isDebug)
        {
            StartCoroutine(DebugReload());
        }
    }

    private void init() {
        var settings = SettingsObject.init(path);
        if (isDebug && settings != null && settings == this.settings) return;
        this.settings = settings;
        GenerateUI(settings);
    }

    private void GenerateUI(SettingsObject data) {
        var count = parrent.transform.childCount;
        for (int i = 0; i < count; i++) {
            //parrent.transform.GetChild(i).gameObject.SetActive(false);
            Destroy(parrent.transform.GetChild(i).gameObject);
        }

        var showedObj = data.GetAllOrdersVisualised();
        foreach (int order in showedObj) {
            DrawItem(settings.GetItem(order));
        }
    }

    private IEnumerator DebugReload() {
        while (isDebug) {
            yield return new WaitForSeconds(5);
            var data = System.IO.File.ReadAllText(path);
            init();
        }
    }

    private void DrawItem(SettingsItem data) {
        try
        {
            var trs = Instantiate(source.items.Where(x => x.type.ToLower() == data.type.ToLower()).First().prefub);
            trs.name = $"{data.order}:{data.name} type({data.type})";
            var obj = trs.GetComponent<SettingsItemEventListener>();
            if (obj == null)
            {
                trs.AddComponent<SettingsItemEventListener>();
                obj = trs.GetComponent<SettingsItemEventListener>();
            }
            obj.order = data.order;
            var startValue = settings.GetValue(data.order);
            obj.transform.SetParent(parrent.transform, false);
            if (obj != null)
            {
                obj.field.SetValue(startValue.Item2.ToString());
                obj.OnValueChangedEvent += (string type, string value) =>
                {
                    settings.SetValue(obj.order, value);
                };
            }
        }
        catch (System.Exception e){
            Debug.LogError("Undefied format object. Pls Add here to source: " + source.name  + " type : " + data.type + "\n or :" + e);
        }
    }
}
