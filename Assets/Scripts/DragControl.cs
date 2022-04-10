
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    /*  
     *  Kodun çalışabilmesi için atıldığı objeye bir collider eklenmeli.
     *  Collider is trigger aktive edilmiş olmalı ve kullanıcının dokunarak kontrol edeceği yerde olmalı.
     *  Aşağıdaki kodda y ve x hareketini sınırlandırarak yukarı-aşağı ve ileri-geri oynamasının önüne geçilmiştir.
     */

    private Vector3 initialOffset;
    private float fixedZCoor;

    void OnMouseDown()
    {
        fixedZCoor = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //mouse tıklaması x ve y olarak alındığı için tıklama z sine atamak adına bir değişken tuttum
        initialOffset = gameObject.transform.position - GetMouseAsWorldPoint(); //ilk başta tıkladığımda mouse ile tıkladığım obje arasındaki offseti hesaplayıp initialOffset'e eşitledim
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePos = Input.mousePosition; //2 boyutlu bir vektör olan mouse x ve mouse y den fixedZCoor koordinatını da kullanarak 3 boyutlu bir vector elde ettim
        mousePos.z = fixedZCoor;
        return Camera.main.ScreenToWorldPoint(mousePos); //ekrana göre hangi koordinata tekabil ettiğini geri döndürdüm
    }

    void OnMouseDrag()//Burada da objeyi drag hareketi ile istenilen yere sürükledim. Ancak yukarı aşağı hareketini kısıtladım yalnızca sağa ve sola gidebiliyor.
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, (GetMouseAsWorldPoint() + initialOffset).z);

    }
}