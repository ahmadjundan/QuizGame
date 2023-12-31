using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OlahSoal : MonoBehaviour
{
    public TextAsset assetSoal;

    private string[] soal;

    private string[,] kumpulanSoal;

    int indexSoal;
    int maxSoal;
    bool ambilSoal;
    char kunciJawaban;



    bool [] soalSelesai;
    public GameObject panel, Text;
    public GameObject ImagePenilaian, ImageHasil;
    public Text txtHasil, txtNilai, txtSoal;

    public Text textSoal, textJawabanA, textJawabanB, textJawabanC, textJawabanD;

    bool isHasil;
    private float durasi;
    public float durasiPenilaian;

    int nilaiAkhir, jwbSalah, jwbnBenar;


    float nilai = 0;

    // Start is called before the first frame update

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {

        durasi = durasiPenilaian;

        soal = assetSoal.ToString().Split('#');

        soalSelesai = new bool[soal.Length];

        kumpulanSoal = new string[soal.Length, 6]; // 6 adalah jumlah kolom
        maxSoal = soal.Length;
    
        olahSoal();
        ambilSoal = true;
        TampilkanSoal();

    }

    private void olahSoal()
    {
        for (int i = 0; i < soal.Length; i++)
        {
            string[] temp = soal[i].Split('+');

            for (int j = 0; j < temp.Length; j++)
            {
                kumpulanSoal[i, j] = temp[j];
                continue;
            }
            continue;
        }
    }

    private void tampilkanNilai() {
        txtNilai.text = "Nilai : " + HitungNilai();
    }

    private void TampilkanSoal() {
        if (indexSoal < maxSoal) 
        {
            if(ambilSoal){
                for (int i=0; i < soal.Length; i++) {
                    int randomIndexSoal = Random.Range(0, soal.Length);
                    print("random: " +randomIndexSoal);
                    if (!soalSelesai[randomIndexSoal]){
                            textSoal.text = kumpulanSoal[randomIndexSoal, 0];
                            textJawabanA.text = kumpulanSoal[randomIndexSoal, 1];
                            textJawabanB.text = kumpulanSoal[randomIndexSoal, 2];
                            textJawabanC.text = kumpulanSoal[randomIndexSoal, 3];
                            textJawabanD.text = kumpulanSoal[randomIndexSoal, 4];
                            kunciJawaban = kumpulanSoal[randomIndexSoal, 5][0];

                            txtSoal.text = "Soal " + (indexSoal + 1) + " / " + maxSoal;

                            soalSelesai[randomIndexSoal] = true;

                            ambilSoal = false;
                            break;
                        } else {
                            continue;
                        }
                }
            }
        }
    }
    
    public void Opsi(string opsiHuruf) {
        checkJawaban(opsiHuruf[0]);
        if(indexSoal == maxSoal - 1) {
            isHasil = true;
        } else {    
        indexSoal++;
        ambilSoal = true;
        }
        
        panel.SetActive(true);
    }

    private float HitungNilai() {
        if (nilaiAkhir < 0) {
            nilaiAkhir = 0;
        }
        return nilai = (float)nilaiAkhir / maxSoal * 100;

    }

    public Text textPenilaian;
    private void checkJawaban(char huruf) {
        string penilaian;
        if (huruf.Equals(kunciJawaban)){
            penilaian = "Jawaban Benar";
            nilaiAkhir +=1;
            jwbnBenar+=1;
        } else {
            // kurangi nilai
            nilaiAkhir -= 1;
            penilaian = "Jawaban Salah";
            jwbSalah+=1;
        }

        textPenilaian.text = penilaian;
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.activeSelf) {
            durasiPenilaian -= Time.deltaTime;

            if (isHasil) {
                ImagePenilaian.SetActive(true);
                ImageHasil.SetActive(false);

                if (durasiPenilaian <= 0)  {
                    txtHasil.text ="Jawaban Benar : " + jwbnBenar + "\nJawaban Salah : " + jwbSalah + "\nNilai : " + HitungNilai();

                    ImagePenilaian.SetActive(false);
                    ImageHasil.SetActive(true);

                    durasiPenilaian = 0;
                }
            } else {
            ImagePenilaian.SetActive(true);
            ImageHasil.SetActive(false);

            if (durasiPenilaian <= 0) {
                panel.SetActive(false);
                durasiPenilaian = durasi;

                TampilkanSoal();
            }
        }
        
        tampilkanNilai();       
        }
    }
}
