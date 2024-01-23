using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveFurniture : MonoBehaviour
{
    private FurnitureSelect furnitureSelect; // FurnitureSelect 스크립트 선언

    void Start()
    {
        // FurnitureSelect 스크립트 찾기 
        furnitureSelect = FindObjectOfType<FurnitureSelect>();
    }

    public void OnRemoveButtonClick()
    {
        // Furniture 태그를 가진 모든 가구를 배열에 저장
        GameObject[] furnitureArray = GameObject.FindGameObjectsWithTag("Furniture");

        if (furnitureArray != null && furnitureArray.Length > 0)
        {
            // 가장 최근에 생성된 가구를 찾기
            GameObject furnitureToRemove = furnitureArray[furnitureArray.Length - 1];

            // 제거
            Destroy(furnitureToRemove);
        }

    }
}
