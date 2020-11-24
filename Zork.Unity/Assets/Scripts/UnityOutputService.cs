using System;
using Zork;
using UnityEngine;
using TMPro;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    [SerializeField]
    private GameObject TextDestination;

    [SerializeField]
    private GameObject TextTemplate;

    public void Clear()
    {
        for (int i = 0; i < TextDestination.transform.childCount; ++i)
            Destroy(TextDestination.transform.GetChild(i).gameObject);
    }

    public void Write(string value)
    {
        int count = TextDestination.transform.childCount;
        
        if(count == 0)
            Instantiate(TextTemplate, TextDestination.transform);
        else
        {
            GameObject latest = TextDestination.transform.GetChild(count - 1).gameObject;
            latest.GetComponent<TMP_Text>().text += value;
        }
    }

    public void Write(object value) => Write(value.ToString());

    public void WriteLine(string value)
    {
        GameObject textLine = Instantiate(TextTemplate, TextDestination.transform);
        textLine.GetComponent<TMP_Text>().text = value;
    }

    public void WriteLine(object value) => WriteLine(value.ToString());

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
