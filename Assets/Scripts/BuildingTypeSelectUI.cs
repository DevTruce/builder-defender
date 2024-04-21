using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingTypeSelectUI : MonoBehaviour {

    private Dictionary<BuildingTypeSO, Transform> btnTransformDistionary;

    private void Awake() {
        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        btnTransformDistionary = new Dictionary<BuildingTypeSO, Transform>();

        int index = 0;
        foreach (BuildingTypeSO buildingType in buildingTypeList.list) {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            float offsetAmount = +130f;
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            btnTransform.GetComponent<Button>().onClick.AddListener(() => {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            btnTransformDistionary[buildingType] = btnTransform;

            index++;
        }
    }

    private void Update() {
        UpdateActiveBuildingTypeButton();
    }

    private void UpdateActiveBuildingTypeButton() {
        foreach (BuildingTypeSO buildingType in btnTransformDistionary.Keys) {
            Transform btnTransform = btnTransformDistionary[buildingType];
            btnTransform.Find("selected").gameObject.SetActive(false);
        }

       BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
       btnTransformDistionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
    }
   
}
