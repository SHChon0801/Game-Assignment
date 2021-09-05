using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    private void Start()
    {
        Update();
    }

    public List<GameObject> items = new List<GameObject>();

    bool isOpen = false;

    public GameObject ui_window;
    public Image[] items_images;

    private void Update()
    {
        //if (!PauseMenu.GameIsPause)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleInventory();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                closeInventory();
            }
            Update_Inventory();
        }
    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;
        ui_window.SetActive(isOpen);
        Update_Inventory();
    }

    void closeInventory()
    {
        isOpen = false;
        ui_window.SetActive(isOpen);
    }


    public void PickUp(GameObject item_list)
    {

        items.Add(item_list);

        Update_Inventory();
    }

    void Update_Inventory()
    {
        //HideAll();
        for (int i = 0; i < items.Count; i++)
        {
            items_images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            items_images[i].gameObject.SetActive(true);
        }

    }

    void HideAll()
    {
        foreach (var i in items_images)
        {
            i.gameObject.SetActive(false);
        }
    }

    public void useitem(int id)
    {
        Update_Inventory();
    }
}
