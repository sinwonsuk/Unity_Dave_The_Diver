using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Audio_Manager;

public class Audio_Manager : MonoBehaviour
{
     static Audio_Manager instance;

    public static Audio_Manager GetInstance()
    {
        return instance;
    }

    [Header("#BGM")]
    public AudioClip [] bgmClips;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip [] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelindex;

    public enum sfx
    {
        dave_diving,
        lobby_dave_foot,
        amb_lobby_loop,
        amb_lobby_far_bird,
        ui_lobby_dive,
        harpoon_aim,
        harpoon_line_pull_loop,
        harpoon_pump_shot,
        harpoon_shot,
        sound_harpoon_QTE_Success_01,
        dave_breathe,
        ui_lobby_open,
        ui_lobby_sushi_openpopup,
        Vib_lobby_boat_move,
        ui_sushibar_close,
        ui_sushibar_open,
        ui_button_click,
        effect_chopping_board,
        sushi_customer_served,
        sushi_customer_eat,
        sound_sushibar_pay,
        sushi_bancho_foodready,
        sushi_bancho_foodready_02,
        sushi_customer_enter_talk,
        sushi_customer_enter_talk_02,
        sushi_customer_enter_talk_03,
    }
    public enum bgm
    {
        Lobby,
        Dive,
        SushiBar,
        Intro,
        Title,

    }

    private void Awake()
    {
       



        instance = this;
        Init();
    }

    void Init()
    {
        


        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BGM");
        bgmObject.transform.parent = transform;    
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        //bgmPlayer.clip = bgmClip;

        GameObject sfxObject = new GameObject("SFX");
        sfxObject.transform.parent = transform;
        sfxPlayers  = new AudioSource[channels];

        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = sfxVolume;           
        }
    }

    public void SfxPlay(sfx sfx, bool _loopcheck,float volume = 0.5f)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channelindex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }


            channelindex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            sfxPlayers[loopIndex].volume = volume;
            if (_loopcheck ==true)
            {
                sfxPlayers[loopIndex].loop = true;
            }
            else
            {
                sfxPlayers[loopIndex].loop = false;
            }


            break;
        }

    }

    public void Sfx_Stop(sfx _sfx)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            if (sfxPlayers[i].clip == sfxClips[(int)_sfx])
            {
                sfxPlayers[i].Stop();
            }
        }
    }

    public void PlayBgm(bgm _bgm)
    {       
       bgmPlayer.clip = bgmClips[(int)_bgm];
       bgmPlayer.Play();             
    }
    public void Bgm_Stop()
    {
        bgmPlayer.Stop();
    }

    public void All_Sfx_Stop()
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {          
            sfxPlayers[i].Stop();          
        }
    }



    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
