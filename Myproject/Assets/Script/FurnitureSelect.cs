using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureSelect : MonoBehaviour
{
    public GameObject furniturePrefab; // 가구 프리펩 연결 
    public Transform furnitureSpawnPoint; // 가구를 배치할 위치

    private List<GameObject> spawnedFurnitureList = new List<GameObject>(); // 가구 생성을 리스트로 만들어봄

    public void SpawnFurniture(GameObject furniturePrefab)
    {
        // 가구 생성 및 배치
        if (furniturePrefab != null && furnitureSpawnPoint != null)
        {
            // 새로운 가구 생성 
            GameObject newFurniture = Instantiate(furniturePrefab, furnitureSpawnPoint.position, furnitureSpawnPoint.rotation);

            // 가구에 태그 설정
            newFurniture.tag = "Furniture";

            // 생성된 가구를 리스트에 추가 
            spawnedFurnitureList.Add(newFurniture);
        }

        else
        {
            Debug.LogError("FurniturePrefab or FurnitureSpawnPoint is not set");
        }
    }
}
