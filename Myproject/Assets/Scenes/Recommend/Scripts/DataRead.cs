using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class DataRead : MonoBehaviour
{
    private DatabaseReference databaseReference;

    // Start is called before the first frame update
    void Start()
    {
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

        ReadData("StuffInfo/소파");
    }

    private void ReadData(string path)
    {
        databaseReference.Child(path).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("데이터 읽기 실패" + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot childSnapshot in snapshot.Children)
                {
                    //string StuffName = childSnapshot.Child("")   이름
                    string Price = childSnapshot.Child("Price").Value.ToString();
                    string ImageUrl = childSnapshot.Child("ImageURL").Value.ToString();

                    Debug.Log(ImageUrl);
                    Debug.Log(Price);


                }
            }
        });

    }

    private void ApplyDataToPrefab(string Price, string ImageURL)
    {
        CreatePrefabs.instance.ReceiveData(Price, ImageURL);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
