using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController _characterController;
    public Transform cameraa;
    public float lookSensivity; //Bakýþ hassasiyeti
    public float maxXRot, minXRot;
    private float curXRot; //Þu anki x konumu

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //MOUSE GÝZLEME ÝÇÝN
    }


    void Update()
    {
        Move();
        if(Cursor.lockState== CursorLockMode.Locked)
        {
            Look();
        }
        
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //Yukarý-aþaðý ile sað-sol tuþlarýna ayný anda basmak için:
        Vector3 dir = transform.right * x + transform.forward * y;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;

        _characterController.Move(dir);
    }

    private void Look()
    {
        float x = Input.GetAxis("Mouse X") * lookSensivity; //Farenin X konumundaki hareketi
        float y = Input.GetAxis("Mouse Y") * lookSensivity; //Farenin Y konumundaki hareketi

        // X ekseninde dönmek için:
        transform.eulerAngles += Vector3.up * x; //eulerAngles dönüþ iþlemleri için kullanýlýr. 

        //Karakterin Yukarý As?ag?ý Bakmasý ve Hareket Etmesi Ýçin:
        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot); // Deðeri -80 ve 80 arasýnda sabit tutuyot + veya - 90 olamaz mesala + veya - 80 deðerini alabilir en çok
        cameraa.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f); //cam.localEulerAngles kameranýn playerden baðýmsýz kendi içinde dönebilmesi için
    }
}
