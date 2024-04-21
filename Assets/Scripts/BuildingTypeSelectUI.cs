using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingTypeSelectUI : MonoBehaviour {

    [SerializeField] private Sprite arrowSprite;

    private Dictionary<BuildingTypeSO, Transform> btnTransformDistionary;
    private Transform arrowBtn;

    private void Awake() {
        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        btnTransformDistionary = new Dictionary<BuildingTypeSO, Transform>();

        int index = 0;

        arrowBtn = Instantiate(btnTemplate, transform);
        arrowBtn.gameObject.SetActive(true);

        float offsetAmount = +130f;
        arrowBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

        arrowBtn.Find("image").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -30);

        arrowBtn.Find("image").GetComponent<Image>().sprite = arrowSprite;

        arrowBtn.GetComponent<Button>().onClick.AddListener(() => {
            BuildingManager.Instance.SetActiveBuildingType(null);
        });

        index++;

        foreach (BuildingTypeSO buildingType in buildingTypeList.list) {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            offsetAmount = +130f;
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            btnTransform.GetComponent<Button>().onClick.AddListener(() => {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            btnTransformDistionary[buildingType] = btnTransform;

            index++;
        }
    }

    private void Start() {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
        UpdateActiveBuildingTypeButton();
    }

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e) {
        UpdateActiveBuildingTypeButton();
    }


    private void UpdateActiveBuildingTypeButton() {
        arrowBtn.Find("selected").gameObject.SetActive(false);
        foreach (BuildingTypeSO buildingType in btnTransformDistionary.Keys) {
            Transform btnTransform = btnTransformDistionary[buildingType];
            btnTransform.Find("selected").gameObject.SetActive(false);
        }

       BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();

       if (activeBuildingType == null) {
        arrowBtn.Find("selected").gameObject.SetActive(true);
       } else {
        btnTransformDistionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
        }
    }
   
}
