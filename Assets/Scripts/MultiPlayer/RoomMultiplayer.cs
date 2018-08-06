using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomMultiplayer : MonoBehaviour
{
    public Button tombolGabung;
    public Dropdown dropdownMultiplayer;

    public Text statusMultiplayer;
    public int maksimumPanjangNamaPlayer;
    public int minimumPanjangNamaPlayer;

    [SerializeField]
    private InputField inputNamaPlayer;

    private Button TombolGabung;
    private Dropdown DropdownMultiplayer;

    private Canvas canvasMultiplayer;
    public PengaturanMultiPlayer pengaturanMultiplayer;
    private List<AmbilRoom.Room> obyekRoom;

    public string namaScene;

    // Use this for initialization

    private void Awake()
    {
        TombolGabung = tombolGabung.GetComponent<Button>();
        DropdownMultiplayer = dropdownMultiplayer.GetComponent<Dropdown>();
        canvasMultiplayer = transform.GetComponent<Canvas>();
        //Debug.Log(GameObject.FindGameObjectWithTag("PengaturanMultiplayer"));
        //pengaturanMultiplayer = GameObject.FindGameObjectWithTag("PengaturanMultiplayer").GetComponent<PengaturanMultiPlayer>();
        Debug.Log("Mulai Fungsi Awake");
        statusMultiplayer.text = "Mulai Fungsi Awake";
        inputNamaPlayer.interactable = false;
    }

    private void Start()
    {
        validasiRoom();
        Debug.Log("Mulai Validasi");
        statusMultiplayer.text = "Mulai Validasi";
        PhotonNetwork.automaticallySyncScene = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void GabungSeleksiRoom()
    {
        AmbilRoom.Room roomDiseleksi = obyekRoom[DropdownMultiplayer.value];
        pengaturanMultiplayer.GabungRoom(roomDiseleksi.namaRoom, inputNamaPlayer.text);
        statusMultiplayer.text = "Gabung dengan Room yang diseleksi";
    }

    private void OnJoinedRoom()
    {
        statusMultiplayer.text = "Bergabung Ke Room : " + PhotonNetwork.room.Name;
        Scene sceneIni = SceneManager.GetActiveScene();
        if (sceneIni.name != namaScene)
            PhotonNetwork.LoadLevel(namaScene);
    }

    private void OnJoinedLobby()
    {
        validasiRoom();
        statusMultiplayer.text = "Bergabung ke Lobby";
    }

    public void PerubahanInputNamaPlayer()
    {
        Debug.Log("Perubahan Input Player");
        statusMultiplayer.text = "Perubahan Input Player";
        validasiRoom();
    }

    private void SaatPerubahanDaftarRoom(List<AmbilRoom.Room> daftarRoom)
    {
        statusMultiplayer.text = "Perubahan Daftar Room";
        obyekRoom = daftarRoom;
        DropdownMultiplayer.ClearOptions();
        foreach (var room in daftarRoom)
        {
            DropdownMultiplayer.options.Add(new Dropdown.OptionData(room.namaRoom));
        }
        DropdownMultiplayer.RefreshShownValue();
        DropdownMultiplayer.onValueChanged.AddListener(delegate
        {
            Debug.Log("Room Terpilih: " + DropdownMultiplayer.options[DropdownMultiplayer.value].text + " | Index: " + DropdownMultiplayer.value);
        });
    }

    private void BelumBisaGabung()
    {
        TombolGabung.interactable = false;
        Debug.Log("Belum Bisa Gabung");
    }

    private void SudahBisaGabung()
    {
        Debug.Log("Bisa Gabung");
        TombolGabung.interactable = true;
    }

    private bool ApakahRoomPenuh()
    {
        AmbilRoom.Room roomDiseleksi = obyekRoom[DropdownMultiplayer.value];
        return roomDiseleksi.maksimumJumlahPlayer <= roomDiseleksi.jumlahPlayer;
    }

    public bool validasiRoom()
    {
        if (inputNamaPlayer.text.Length < minimumPanjangNamaPlayer || inputNamaPlayer.text.Length > maksimumPanjangNamaPlayer
            || ApakahRoomPenuh())
        {
            BelumBisaGabung();
            return false;
        }
        SudahBisaGabung();
        return true;
    }

    private void OnReceivedRoomListUpdate()
    {
        statusMultiplayer.text = "Perubahan Daftar Room";
        inputNamaPlayer.interactable = true;
    }
}