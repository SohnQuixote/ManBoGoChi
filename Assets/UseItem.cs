using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Transform SelectedItem;
    public Transform ItemRoot;          //유니티 인벤토리씬에 있는 ItemList 오브젝트를 가리킴
    public GameObject zerofailwin;
    public GameObject successwin;
    public GameObject evolfailwin;

    private int count;
    private int temp;
    private float coe;
    private string stat;
    private int cost;
    private float curstat;
    public void OnClickUse()
    {
        var selecteditem = SelectedItem.GetComponent<ItemIndex>();
        var item = ItemRoot.GetChild(selecteditem.index).GetComponent<Item>();       //ItemList 오브젝트에서 선택된 아이템을 반환
        temp = PlayerPrefs.GetInt(item.name, 0);
        cost = int.Parse(item.icost.text);

        if (temp > 0)
        {
            if(PlayerPrefs.GetString("shape", "0").Contains("egg"))
            {
                stat = "exp";
                switch (selecteditem.index)
                {
                    case 0:
                        coe = 0.1f;
                        break;
                    case 1:
                        coe = 0.15f;
                        break;
                    case 2:
                        coe = 0.2f;
                        break;
                    default:
                        stat = "fail";
                        break;
                }
            }
            else if (PlayerPrefs.GetString("shape", "0").Contains("kid"))
            {
                switch (selecteditem.index)
                {
                    case 3:
                        stat = "hunger";
                        coe = 1f;
                        break;
                    case 4:
                        stat = "feeling";
                        coe = 0.25f;
                        break;
                    case 5:
                        stat = "feeling";
                        coe = 0.3f;
                        break;
                    case 6:
                        stat = "feeling";
                        coe = 0.35f;
                        break;
                    case 7:
                        stat = "exp";
                        coe = 0.25f;
                        break;
                    case 8:
                        stat = "exp";
                        coe = 0.3f;
                        break;
                    case 9:
                        stat = "exp";
                        coe = 0.4f;
                        break;
                    default:
                        stat = "fail";
                        break;
                }
            }
            else if (PlayerPrefs.GetString("shape", "0").Contains("mid"))
            {
                switch (selecteditem.index)
                {
                    case 10:
                        stat = "hunger";
                        coe = 1f;
                        break;
                    case 11:
                        stat = "feeling";
                        coe = 0.4f;
                        break;
                    case 12:
                        stat = "feeling";
                        coe = 0.5f;
                        break;
                    case 13:
                        stat = "exp";
                        coe = 0.45f;
                        break;
                    case 14:
                        stat = "exp";
                        coe = 0.5f;
                        break;
                    case 15:
                        stat = "exp";
                        coe = 0.6f;
                        break;
                    default:
                        stat = "fail";
                        break;
                }
            }
            if(stat == "fail")
            {
                evolfailwin.SetActive(true);
            }
            else
            {
                curstat = PlayerPrefs.GetFloat(stat, 0);
                PlayerPrefs.SetFloat(stat, curstat + cost * coe);

                temp -= 1;
                item.icount.text = temp.ToString();
                PlayerPrefs.SetInt(item.name, temp);

                successwin.SetActive(true);
            }
        }
        else
        {
            temp += 5;
            item.icount.text = temp.ToString();
            PlayerPrefs.SetInt(item.name, temp);

            zerofailwin.SetActive(true);
        }
    }

    public void OnZeroFailYes()
    {
        zerofailwin.SetActive(false);
    }
    public void OnSuccYes()
    {
        successwin.SetActive(false);
    }
    public void OnEvolFailYes()
    {
        evolfailwin.SetActive(false);
    }
}
