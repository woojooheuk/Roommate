using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatePrefabs : MonoBehaviour
{
    public GameObject Stuff;
    public static CreatePrefabs instance;
    public Transform Contents;
    // Start is called before the first frame update

    void Start()
    {
        instance = this;
        GameObject StuffInstance = Instantiate(Stuff, Contents);
        Text text = StuffInstance.transform.Find("StuffName").GetComponent<Text>();

        if(text != null)
        {
            text.text = "¤¾¤·";
        }

    }
    public void ReceiveData(string price, string imageURL)
    {
        CreatePrefab(price, imageURL);
    }

    public void CreatePrefab(string price, string imageURL)
    {
        GameObject StuffInstance = Instantiate(Stuff, Contents);

        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
