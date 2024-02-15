using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabs : MonoBehaviour
{
    public GameObject prefab;
    public static CreatePrefabs instance;
    private string Price, ImageURL;
    public Transform Contents;
    // Start is called before the first frame update

    void Start()
    {
        instance = this;
    }
    public void ReceiveData(string price, string imageURL)
    {
        Price = price;
        ImageURL = imageURL;
    }

    public void CreatePrefab()
    {
        GameObject StuffContents = Instantiate(prefab, Contents);

        prefabData prefabData = newPrefab.GetComponent<PrefabData>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
