using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatePrefabs : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Stuff;
    public static CreatePrefabs instance;
    private string Price, ImageURL;
    public Transform Contents;
    // Start is called before the first frame update

    void Start()
    {
        instance = this;
        GameObject StuffInstance = Instantiate(Stuff, Contents);
        Text text = StuffInstance.transform.Find("StuffName").GetComponent<Text>();

        if (text != null)
        {
            text.text = "����";
        }

    }
    public void ReceiveData(string price, string imageURL)
    {
        Price = price;
        ImageURL = imageURL;
        CreatePrefab(price, imageURL);
    }

    public void CreatePrefab(string price, string imageURL)
    {
        GameObject StuffContents = Instantiate(prefab, Contents);
        GameObject StuffInstance = Instantiate(Stuff, Contents);



    }
}