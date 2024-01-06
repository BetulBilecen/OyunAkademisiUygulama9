using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController _characterController;
    public Transform cameraa;
    public float lookSensivity; //Bak�� hassasiyeti
    public float maxXRot, minXRot;
    private float curXRot; //�u anki x konumu

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //MOUSE G�ZLEME ���N
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
        //Yukar�-a�a�� ile sa�-sol tu�lar�na ayn� anda basmak i�in:
        Vector3 dir = transform.right * x + transform.forward * y;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;

        _characterController.Move(dir);
    }

    private void Look()
    {
        float x = Input.GetAxis("Mouse X") * lookSensivity; //Farenin X konumundaki hareketi
        float y = Input.GetAxis("Mouse Y") * lookSensivity; //Farenin Y konumundaki hareketi

        // X ekseninde d�nmek i�in:
        transform.eulerAngles += Vector3.up * x; //eulerAngles d�n�� i�lemleri i�in kullan�l�r. 

        //Karakterin Yukar� As?ag?� Bakmas� ve Hareket Etmesi ��in:
        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot); // De�eri -80 ve 80 aras�nda sabit tutuyot + veya - 90 olamaz mesala + veya - 80 de�erini alabilir en �ok
        cameraa.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f); //cam.localEulerAngles kameran�n playerden ba��ms�z kendi i�inde d�nebilmesi i�in
    }
}
