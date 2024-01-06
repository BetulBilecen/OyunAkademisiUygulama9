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
            durum.text = "Oyun tamamlanamadý :(";
            btn.gameObject.SetActive(true);
        }
        //Zaman bittiðinde oyunu devam bitirme
        if (zamanSayaci < 0)
            oyunDevam = false;
    }

    private void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            //Oyun devam ettiði müddetçe topu hareket ettir. Topu hareket ettirmek için gerekli kodlar:
            float yatay = Input.GetAxis("Horizontal"); //Horizontal yatay anlamýnda
            float dikey = Input.GetAxis("Vertical"); //Vertical dikey anlamýnda
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

        //Kýrmýzý renkli bitiþ nesnesine çarptýðýnda " Oyunu Kazandýnýz " diye mesaj ver
        if (nesneIsmi.Equals("Kapi"))
        {
            //print("Oyunu Kazandýnýz *_*");
            oyunTamam = true;
            durum.text = "Tebrikler! Labirenti geçtiniz *_*";
            btn.gameObject.SetActive(true);
        }

    }
}
