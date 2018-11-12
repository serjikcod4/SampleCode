using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PogruzhikMoveController : MonoBehaviour {

    public bool isStartPosition;
    public bool isCanMovePogruzhicktoCameraCenter;
    public bool isMoveToPosRight;
    public bool isMoveToPosLeft;
    public Transform PosCenter;
    public Transform PosLeft;
    public Transform PosRight;
    public GameObject Pogruzhik_sprite;
    public Transform CameMain;
    public Sounds sounds;

    private BlockCreatorContoller blockCreatorContoller;
    private float startPosY = 4.5f;
    private float speedPogruzchikLevel_3 = 6f;
    private float speedPogruzchikLevel_2 = 4f;
    private float speedPogruzchikLevel_1 = 2f;
    private bool isMoveToPosCenter;
   
    private void Start()
    {
        blockCreatorContoller = FindObjectOfType<BlockCreatorContoller>();
    }

    private void Update()
    {
        if (Application.loadedLevel == 0)
        {
            if (isStartPosition)
            {
                transform.position -= new Vector3(0, 0.05f, 0);
                sounds.PogruzhikPlay();
                if (transform.position.y <= startPosY)
                {
                    sounds.pogruzhikAudio.Stop();
                    isStartPosition = false;
                    isMoveToPosRight = true;
                    blockCreatorContoller.isCanChangeBlockScale = true;
                }
            }

            if (isMoveToPosRight)
            {
                Pogruzhik_sprite.transform.position = Vector3.MoveTowards(Pogruzhik_sprite.transform.position, PosRight.position, Time.deltaTime * speedPogruzchikLevel_1);
                sounds.PogruzhikMovingAudioPlay();
                if (Pogruzhik_sprite.transform.position.x >= PosRight.position.x)
                {
                    isMoveToPosRight = false;
                    isMoveToPosLeft = true;
                    sounds.PogruzhikRevers();
                }
            }

            if (isMoveToPosLeft)
            {
                Pogruzhik_sprite.transform.position = Vector3.MoveTowards(Pogruzhik_sprite.transform.position, PosLeft.position, Time.deltaTime * speedPogruzchikLevel_1);
                sounds.PogruzhikMovingAudioPlay();
                if (Pogruzhik_sprite.transform.position.x <= PosLeft.position.x)
                {
                    isMoveToPosLeft = false;
                    isMoveToPosRight = true;
                    sounds.PogruzhikRevers();
                }
            }

            //Move Pogruzchik to Center
            if (isCanMovePogruzhicktoCameraCenter)
            {
                transform.position = Vector3.Lerp(transform.position,
                                                    new Vector3(CameMain.position.x,
                                                                transform.position.y,
                                                                transform.position.z),
                                                    Time.deltaTime * speedPogruzchikLevel_1);
            }
        }

        if (Application.loadedLevel == 1)
        {
            if (isStartPosition)
            {
                transform.position -= new Vector3(0, 0.05f, 0);
                sounds.PogruzhikPlay();
                if (transform.position.y <= startPosY)
                {
                    sounds.pogruzhikAudio.Stop();
                    isStartPosition = false;
                    isMoveToPosRight = true;
                    blockCreatorContoller.isCanChangeBlockScale = true;
                }
            }

            if (isMoveToPosRight)
            {
                Pogruzhik_sprite.transform.position = Vector3.MoveTowards(Pogruzhik_sprite.transform.position, PosRight.position, Time.deltaTime * speedPogruzchikLevel_2);
                sounds.PogruzhikMovingAudioPlay();
                if (Pogruzhik_sprite.transform.position.x >= PosRight.position.x)
                {
                    isMoveToPosRight = false;
                    isMoveToPosLeft = true;
                    sounds.PogruzhikRevers();
                }
            }

            if (isMoveToPosLeft)
            {
                Pogruzhik_sprite.transform.position = Vector3.MoveTowards(Pogruzhik_sprite.transform.position, PosLeft.position, Time.deltaTime * speedPogruzchikLevel_2);
                sounds.PogruzhikMovingAudioPlay();
                if (Pogruzhik_sprite.transform.position.x <= PosLeft.position.x)
                {
                    isMoveToPosLeft = false;
                    isMoveToPosRight = true;
                    sounds.PogruzhikRevers();
                }
            }

            //Move Pogruzchik to Center
            if (isCanMovePogruzhicktoCameraCenter)
            {
                transform.position = Vector3.Lerp(transform.position,
                                                    new Vector3(CameMain.position.x,
                                                                transform.position.y,
                                                                transform.position.z),
                                                    Time.deltaTime * speedPogruzchikLevel_1);
            }
        }

        if (Application.loadedLevel == 2)
        {
            if (isStartPosition)
            {
                transform.position -= new Vector3(0, 0.05f, 0);
                sounds.PogruzhikPlay();
                if (transform.position.y <= startPosY)
                {
                    sounds.pogruzhikAudio.Stop();
                    isStartPosition = false;
                    isMoveToPosRight = true;
                    blockCreatorContoller.isCanChangeBlockScale = true;
                }
            }

            if (isMoveToPosRight)
            {
                Pogruzhik_sprite.transform.position = Vector3.MoveTowards(Pogruzhik_sprite.transform.position, PosRight.position, Time.deltaTime * speedPogruzchikLevel_3);
                sounds.PogruzhikMovingAudioPlay();
                if (Pogruzhik_sprite.transform.position.x >= PosRight.position.x)
                {
                    isMoveToPosRight = false;
                    isMoveToPosLeft = true;
                    sounds.PogruzhikRevers();
                }
            }

            if (isMoveToPosLeft)
            {
                Pogruzhik_sprite.transform.position = Vector3.MoveTowards(Pogruzhik_sprite.transform.position, PosLeft.position, Time.deltaTime * speedPogruzchikLevel_3);
                sounds.PogruzhikMovingAudioPlay();
                if (Pogruzhik_sprite.transform.position.x <= PosLeft.position.x)
                {
                    isMoveToPosLeft = false;
                    isMoveToPosRight = true;
                    sounds.PogruzhikRevers();
                }
            }

            //Move Pogruzchik to Center
            if (isCanMovePogruzhicktoCameraCenter)
            {
                transform.position = Vector3.Lerp(transform.position,
                                                    new Vector3(CameMain.position.x,
                                                                transform.position.y,
                                                                transform.position.z),
                                                    Time.deltaTime * speedPogruzchikLevel_1);
            }
        }
    }

    public void MovePogruzhiktoStartPositionY()
    {
        isStartPosition = true;
    }
}
