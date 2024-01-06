using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyunDurum : MonoBehaviour
{
    private Animator _animator;
    public Button btn;
    private Rigidbody _rigidb;
    public float hiz = 1.5f;
    public Text kalan_zaman, durum;
    float zamanSayaci = 550;
    bool oyunDevam = true;
    bool oyunTamam = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            kalan_zaman.text = (int)zamanSayaci + "";
        }
        else if (!oyunTamam)
        {
            durum.text = "Oyun tamamlanamad� :(";
            btn.gameObject.SetActive(true);
        }
        //Zaman bitti�inde oyunu devam bitirme
        if (zamanSayaci < 0)
            oyunDevam = false;
    }

    private void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            //Oyun devam etti�i m�ddet�e topu hareket ettir. Topu hareket ettirmek i�in gerekli kodlar:
            float yatay = Input.GetAxis("Horizontal"); //Horizontal yatay anlam�nda
            float dikey = Input.GetAxis("Vertical"); //Vertical dikey anlam�nda
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            _rigidb.AddForce(kuvvet * hiz);
            //_animator.SetBool("KosuyorMu", true);
        }
        else
        {
            //Oyun bittiyse hareketleri iptal eder.
            _rigidb.velocity = Vector3.zero;
            _rigidb.angularVelocity = Vector3.zero;
            //_animator.SetBool("KosuyorMu", false);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        string nesneIsmi = other.gameObject.name;

        //K�rm�z� renkli biti� nesnesine �arpt���nda " Oyunu Kazand�n�z " diye mesaj ver
        if (nesneIsmi.Equals("Kapi"))
        {
            //print("Oyunu Kazand�n�z *_*");
            oyunTamam = true;
            durum.text = "Tebrikler! Labirenti ge�tiniz *_*";
            btn.gameObject.SetActive(true);
        }

    }
}
