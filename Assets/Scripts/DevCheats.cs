using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCheats {

    public ResourceManager resourceManager;
    
    
    void Update()
    {
        DeveloperCheats(); 
    }

   private void DeveloperCheats() {
        // DEV CHEATS 

        // give 50 wood 
        if (Input.GetKeyDown(KeyCode.I) ) {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

            resourceManager.AddResource(resourceTypeList.list[0], 50);
            Debug.Log(resourceTypeList.list[0].nameString + "+50");
        }
    }
}
