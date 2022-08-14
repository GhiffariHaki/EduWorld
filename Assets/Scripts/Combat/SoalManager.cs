using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class SoalManager : MonoBehaviour
{
    [System.Serializable]
    public class Soal
    {
        [TextArea]
        [Header("Soal")]
        public string soal;
        
        [Header("Pilihan untuk jawaban :")]
        public string pilA, pilB, pilC, pilD;

        [Header("Kunci Jawaban")]
        public bool A, B, C, D;
    }


    Text textSoal, textA, textB, textC, textD, textWaktu, textAction, textDeskripsiAction, textCooldownCrit, textCooldownHeal, textCooldownSleep, textCooldownRay, textQuestTitle;

    public GameObject MonsterTextPrefab, PlayerTextPrefab, SkillSetWar, SkillSetWiz, SkillSetAnti;
    public float waktu;
    public List<Soal> KumpulanSoal;
    private int randomPoint;
    private float highscoreChecker;
    private int playcountChecker;
    private int attackstate, sleep = 0;
    private int counterheal = 0, countercrit = 0, countersleep = 0, counterray = 0;

    public GameObject GameOverMenu, cooldownCrit, cooldownHeal, cooldownSleep, cooldownRay;
    public Monster monster;
    public PlayerCombat player;
    public PlayerData playerData;
    public PlayerLobbyMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.Find("Monster").GetComponent<Monster>();
        player = GameObject.Find("PlayerCombatManager").GetComponent<PlayerCombat>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerLobbyMove>();

        textSoal = GameObject.Find("TextSoal").GetComponent<Text>();
        textA = GameObject.Find("A").GetComponent<Text>();
        textB = GameObject.Find("B").GetComponent<Text>();
        textC = GameObject.Find("C").GetComponent<Text>();
        textD = GameObject.Find("D").GetComponent<Text>();
        textAction = GameObject.Find("ActionText").GetComponent<Text>();
        textDeskripsiAction = GameObject.Find("ActionDescText").GetComponent<Text>();

        // Cari Class
        SkillSetWar = GameObject.Find("WarriorSkill");
        SkillSetWiz = GameObject.Find("WizardSkill");
        SkillSetAnti = GameObject.Find("AntiSkill");

        // Class Warrior
        textCooldownCrit = GameObject.Find("CooldownCritText").GetComponent<Text>();
        textCooldownHeal = GameObject.Find("CooldownHealText").GetComponent<Text>();

        // Class Wizard
        textCooldownSleep = GameObject.Find("CooldownSleepText").GetComponent<Text>();
        textCooldownRay = GameObject.Find("CooldownRayText").GetComponent<Text>();

        textQuestTitle = GameObject.Find("QuestTitleText").GetComponent<Text>();
        textQuestTitle.gameObject.SetActive(false);
        Debug.Log(textQuestTitle.text);

        if (playerData.playerClass == 2)
        {
            SkillSetWiz.gameObject.SetActive(false);
            SkillSetAnti.gameObject.SetActive(false);
            attackstate = 1;
        }
        else if(playerData.playerClass == 3)
        {
            SkillSetWar.gameObject.SetActive(false);
            SkillSetAnti.gameObject.SetActive(false);
            attackstate = 4;
        }
        else
        {
            SkillSetWar.gameObject.SetActive(false);
            SkillSetWiz.gameObject.SetActive(false);
            attackstate = 7;
        }


        textWaktu = GameObject.Find("TimerText").GetComponent<Text>();

        randomPoint = Random.RandomRange(0, KumpulanSoal.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //Kondisi Menang
        if(monster.currentHealth <= 0)
        {
            if (textQuestTitle.text == "SINON")
            {
                playerData.coin += 25;
                PlayerPrefs.SetInt("Coin", playerData.coin);
                highscoreChecker = PlayerPrefs.GetFloat("HighScoreSinonim");
                playcountChecker = PlayerPrefs.GetInt("PlayCountSinonim");
                if (waktu <= highscoreChecker || highscoreChecker == 0)
                {
                    PlayerPrefs.SetFloat("HighScoreSinonim", waktu);
                }
                playcountChecker += 1;
                PlayerPrefs.SetInt("PlayCountSinonim", playcountChecker);
            }
            if (textQuestTitle.text == "ANTON")
            {
                playerData.coin += 25;
                PlayerPrefs.SetInt("Coin", playerData.coin);
                highscoreChecker = PlayerPrefs.GetFloat("HighScoreAntonim");
                playcountChecker = PlayerPrefs.GetInt("PlayCountAntonim");
                if (waktu <= highscoreChecker || highscoreChecker == 0)
                {
                    PlayerPrefs.SetFloat("HighScoreAntonim", waktu);
                }
                playcountChecker += 1;
                PlayerPrefs.SetInt("PlayCountAntonim", playcountChecker);
            }
            else
            {
                playerData.coin += 50;
                PlayerPrefs.SetInt("Coin", playerData.coin);
                highscoreChecker = PlayerPrefs.GetFloat("HighScore");
                playcountChecker = PlayerPrefs.GetInt("PlayCount");
                if (waktu <= highscoreChecker || highscoreChecker == 0)
                {
                    PlayerPrefs.SetFloat("HighScore", waktu);
                }
                playcountChecker += 1;
                PlayerPrefs.SetInt("PlayCount", playcountChecker);
            }

            SceneManager.LoadScene("GameLobby");
        }
        //Kondisi Kalah
        if(player.currentHealth <= 0)
        {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        //Warrior Skill
        if (countercrit <= 0)
        {
            cooldownCrit.SetActive(false);
        }
        else if (countercrit > 0)
        {
            cooldownCrit.SetActive(true);
            textCooldownCrit.text = countercrit.ToString();
        }
        if (counterheal <= 0)
        {
            cooldownHeal.SetActive(false);
        }
        else if (counterheal > 0)
        {
            cooldownHeal.SetActive(true);
            textCooldownHeal.text = counterheal.ToString();
        }

        //Wizard Skill
        if (countersleep <= 0)
        {
            cooldownSleep.SetActive(false);
        }
        else if (countersleep > 0)
        {
            cooldownSleep.SetActive(true);
            textCooldownSleep.text = countersleep.ToString();
        }
        if (counterray <= 0)
        {
            cooldownRay.SetActive(false);
        }
        else if (counterray > 0)
        {
            cooldownRay.SetActive(true);
            textCooldownRay.text = counterray.ToString();
        }

        // Action Warrior
        if (CrossPlatformInputManager.GetButtonDown("AttackAction"))
        {
            attackstate = 1;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }
        if (CrossPlatformInputManager.GetButtonDown("HealAction") && counterheal <= 0)
        {
            attackstate = 2;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }
        if (CrossPlatformInputManager.GetButtonDown("CriticalAction") && countercrit <= 0)
        {
            attackstate = 3;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }
        
        // Action Wizard
        if (CrossPlatformInputManager.GetButtonDown("AttackWizAction"))
        {
            attackstate = 4;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }
        if (CrossPlatformInputManager.GetButtonDown("SleepAction") && countersleep <= 0)
        {
            attackstate = 5;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }
        if (CrossPlatformInputManager.GetButtonDown("RayAction") && counterray <= 0)
        {
            attackstate = 6;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }

        // Action Anti
        if (CrossPlatformInputManager.GetButtonDown("AttackAnti"))
        {
            attackstate = 7;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }

        // TEXT WAKTU
        textWaktu.text = "Time : " + waktu.ToString("0.0");      
        waktu += Time.deltaTime;

        // TEXT ACTION
        if(attackstate == 1)
        {
            textAction.text = "Attack";
            textDeskripsiAction.text = "Give 2 Damage";
        }
        else if (attackstate == 2)
        {
            textAction.text = "Heal";
            textDeskripsiAction.text = "Heal 5 point HP";
        }
        else if (attackstate == 3)
        {
            textAction.text = "Critical";
            textDeskripsiAction.text = "Give 4 Damage";
        }
        else if (attackstate == 4)
        {
            textAction.text = "Attack";
            textDeskripsiAction.text = "Give 3 Damage";
        }
        else if (attackstate == 5)
        {
            textAction.text = "Sleep";
            textDeskripsiAction.text = "Stun Enemy 2 Turn";
        }
        else if (attackstate == 6)
        {
            textAction.text = "Ray";
            textDeskripsiAction.text = "Give 7 Damage";
        }
        else if (attackstate == 7)
        {
            textAction.text = "Attack";
            textDeskripsiAction.text = "Give 1 Damage";
        }

        // TEXT SOAL & JAWABAN
        textSoal.text = KumpulanSoal[randomPoint].soal;
        textA.text = KumpulanSoal[randomPoint].pilA;
        textB.text = KumpulanSoal[randomPoint].pilB;
        textC.text = KumpulanSoal[randomPoint].pilC;
        textD.text = KumpulanSoal[randomPoint].pilD;

    }

    public void cekJawaban(string jawaban)
    {
        // Player Turn
        if ((KumpulanSoal[randomPoint].A == true && jawaban == "A") || (KumpulanSoal[randomPoint].B == true && jawaban == "B") || (KumpulanSoal[randomPoint].C == true && jawaban == "C") || (KumpulanSoal[randomPoint].D == true && jawaban == "D"))
        {
            if (attackstate == 1)
            {
                playerMove.m_Anim.Play("Attack");
                monster.Damage(2);
                countercrit -= 1;
                counterheal -= 1;
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.attack);
                PlayerTurn("Attackk!!");
            }
            else if (attackstate == 2)
            {
                player.Heal(5);
                countercrit -= 1;
                counterheal = 2;
                attackstate = 1;
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.heal);
                PlayerTurn("Heal!!");
            }
            else if (attackstate == 3)
            {
                monster.Damage(4);
                countercrit = 5;
                counterheal -= 1;
                attackstate = 1;
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.crit);
                PlayerTurn("Crit!!");
            }
            else if (attackstate == 4)
            {
                playerMove.m_Anim.Play("Attack");
                monster.Damage(3);
                countersleep -= 1;
                counterheal -= 1;
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.attack);
                PlayerTurn("Attack!!");
            }
            else if (attackstate == 5)
            {
                sleep = 2;
                countersleep = 4;
                counterray -= 1;
                attackstate = 4;
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.heal);
                PlayerTurn("Sleep!!");
            }
            else if (attackstate == 6)
            {
                monster.Damage(7);
                countersleep -= 1;
                counterray = 5;
                attackstate = 4;
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.crit);
                PlayerTurn("Ray!!");
            }
            else if (attackstate == 7)
            {
                playerMove.m_Anim.Play("Attack");
                monster.Damage(1);
                attackstate = 7;
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.attack);
                PlayerTurn("Attack!!");
            }
        }
        else
        {
            PlayerTurn("No Turn");
            countercrit -= 1;
            counterheal -= 1;
            counterray -= 1;
            countersleep -= 1;
        }
        Invoke(nameof(MonsterAttack), 1.0f);
    }

    public void MonsterAttack()
    {
        if (sleep == 0)
        {
            playerMove.m_Anim.Play("Die");
            player.Damage(1);
            MonsterTurn();
            KumpulanSoal.RemoveAt(randomPoint);
            randomPoint = Random.RandomRange(0, KumpulanSoal.Count);
        }
        else
        {
            PlayerTurn("Monster Sleeping");
            sleep -= 1;
            KumpulanSoal.RemoveAt(randomPoint);
            randomPoint = Random.RandomRange(0, KumpulanSoal.Count);
        }
    }

    public void PlayerTurn(string action)
    {
        var turnplayer = Instantiate(PlayerTextPrefab);
        turnplayer.GetComponent<TextMesh>().text = action;
    }

    public void MonsterTurn()
    {
        Instantiate(MonsterTextPrefab);
    }
}
