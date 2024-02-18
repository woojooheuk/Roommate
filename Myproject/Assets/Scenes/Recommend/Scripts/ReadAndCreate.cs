using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;

public class ReadAndCreate : MonoBehaviour
{
    private DatabaseReference databaseReference;
    public GameObject Stuff;
    public Transform Contents;
    // Start is called before the first frame update
    public void Start()
    {/*
        for(int i = 0; i < 5; i++)
        {
            Debug.Log("");

            //string StuffName = childSnapshot.Child("")   이름
            //string Price = childSnapshot.Child("Price").Value.ToString();
            //string ImageURL = childSnapshot.Child("ImageURL").Value.ToString();

            GameObject StuffInstance = Instantiate(Stuff, Contents);
            Text text = StuffInstance.transform.Find("StuffName").GetComponent<Text>();
            text.text = i.ToString();
        }*/
        InitializeFirebase();
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("파이어베이스 초기화 실패: " + task.Result);
            }
        });
    }

    private void InitializeFirebase()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        ReadData("StuffInfo");
    }

    private void ReadData(string path)
    {
        databaseReference.Child(path).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("데이터 읽기 실패" + task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                int ChildCount = (int)snapshot.ChildrenCount;
                CreatePrefabs(snapshot, ChildCount);

            }
        });
    }
    private void CreatePrefabs(DataSnapshot snapshot, int ChildCount)
    {
        Debug.Log(ChildCount);
        foreach (DataSnapshot childSnapshot in snapshot.Children)
        {
            Debug.Log(childSnapshot.Child("Price"));

            //string StuffName = childSnapshot.Child("")   이름
            string Price = childSnapshot.Child("Price").Value.ToString();
            string ImageURL = childSnapshot.Child("ImageURL").Value.ToString();

            GameObject StuffInstance = Instantiate(Stuff, Contents);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}