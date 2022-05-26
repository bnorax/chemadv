using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Doublsb.Dialog;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] public LevelController levelController;
    [SerializeField] public DialogManager dialogManager;
    [SerializeField] public Image backgroundImage;
    [SerializeField] public Color backgroundFaded;
    [SerializeField] public Color background;
    private bool levelOneEnd;

    private void Awake()
    {
        backgroundImage.color = backgroundFaded;
        dialogManager.gameObject.SetActive(true);
        List<DialogData> convo = new List<DialogData>();
        
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Эй! Ало! Подъем.", "Slime"));
        
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "А? Что случилось?", "Main"));
        //() => { levelController.ChangeLevel(2);}
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Бум! Большой бум.", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Взрыв? Видимо немного переборщили с водородом... Голова до сих пор звенит", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Давай передохнем, где-то должна быть вода. А ой, она закончилась...", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Мы же химики, видишь балоны с кислородом и водородом? Тащи их сюда", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Хм? Зачем?", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Сделаем свою воду!", "Main", () => levelController.ChangeLevel(3)));
        dialogManager.Show(convo);


    }

    private void Start()
    {
        
    }

    public void Convo2()
    {
        List<DialogData> convo = new List<DialogData>();
        
        convo.Add(new DialogData("Готовь стаканы", "Main"));
        convo.Add(new DialogData("Готовь стаканы", "Main"));
        convo.Add(new DialogData("Готовь стаканы", "Main"));
        convo.Add(new DialogData("Готовь стаканы", "Main"));
        convo.Add(new DialogData("Готовь стаканы", "Main"));
        
        
        convo.Add(new DialogData("Loh", "Main", () => { levelController.ChangeLevel(1);}));
        dialogManager.Show(convo);
    }
    
    
    void Slime1()
    {
        //dialogManager.Hide();
        DialogData dialogSlime = new DialogData("1 Ау! АУ! Вставай, чего разлегся. Что случилось?", "Slime");
        dialogSlime.Callback = Slime2;
        dialogManager.Show(dialogSlime);
    }
    void Slime2()
    {
        //dialogManager.Hide();
        DialogData dialogSlime = new DialogData("2 Ау! АУ! Вставай, чего разлегся. Что случилось?", "Slime");
        dialogSlime.Callback = Slime3;
        dialogManager.Show(dialogSlime);
    }
    void Slime3()
    {
        DialogData dialogSlime = new DialogData("3 Ау! АУ! Вставай, чего разлегся. Что случилось?", "Slime");
        dialogManager.Show(dialogSlime);
    }


    private void Update()
    {
       // if (levelController.levelList[levelController.currentLevelIndex]()) Convo2();
    }
}
