using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*o objeto devera ter duas versoes, uma na mao e a outra no local que sera coletado
o script deve ser aplicado no objeto a ser coletado*/
public class GrabItem : MonoBehaviour
{
    public GameObject item;
//arrastar o objeto na mâp aqui
    void Start()
    {
        item.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.SetActive(false);
            item.SetActive(true);
        }
    }
}
