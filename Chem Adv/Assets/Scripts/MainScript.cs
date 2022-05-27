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
    public UnityEvent blockInput;
    public UnityEvent unblockInput;

    private void Awake()
    {
       // backgroundImage.color = backgroundFaded;
        dialogManager.gameObject.SetActive(true);
        List<DialogData> convo = new List<DialogData>();
        
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Эй! Ало! Подъем", "Slime"));
        
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "А? Что случилось?", "Main"));
        //() => { levelController.ChangeLevel(2);}
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Бум! Большой бум.", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Видимо немного переборщили с водородом...", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Давай передохнем, где-то должна быть вода. А ой, она закончилась...", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Мы же химики, видишь балоны с кислородом и водородом? Тащи их сюда", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n"+"/color:white/"+
                                 "Хм? Зачем?", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Сделаем свою воду!", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n" + "/color:white/" +
                                 "Новенький, хватит прятаться в углу. Самое время объяснить как тут все работает",
            "Main", () =>
            {
                levelController.ChangeLevel(0);
                var player = levelController.currentLevel.GetComponentInChildren<Player>();
                if(player) player.BlockInput();
            }));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Глянь в микроскоп, перед тобой поле из клеток", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Если присмотришься повнимательнее, то увидишь атомы", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Не выходи за /color:red/красные /color:white/клетки – это границы работы манипулятора", "Main", () =>StartConvo2()));
        dialogManager.Show(convo);


    }

    private void Start()
    {
        
    }

    void StartConvo2()
    {
        List<DialogData> convo = new List<DialogData>();
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Дальше них ты не сможешь сдвинуть атом", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "А теперь возьми манипулятор и попробуй подвинуть атом", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Используй /color:yellow/WASD /color:white/для управления молекулой", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "А теперь попробуй собрать молекулу воды", "Main", () =>
        {
            var player = levelController.currentLevel.GetComponentInChildren<Player>();
            if(player) player.UnblockInput();
        }));
        dialogManager.Show(convo);
    }
    public void FinishedLvl1Water()
    {
        List<DialogData> convo = new List<DialogData>();
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Неплохо, неплохо. Тебе есть еще чему учиться", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n" + "/color:white/" +
                                 "/color:orange/Леша/color:white/! Срочно! Плохие новости", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "/color:lime/Глоб/color:white/, что случилось? Мы заняты", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n" + "/color:white/" +
                                 "Балон, взрыв раньше... Это был балон с газом!", "Slime"));
        convo.Add(new DialogData("/color:lime/Глоб\n" + "/color:white/" +
                                 "Не видать нам сегодня горячего обеда...", "Slime"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Вот незадача, но ничего, это хорошая возможность новичку потренироваться", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Попробуй сделать молекулу метана, из этого вещества состоит природный газ", "Main", () => levelController.ChangeLevel(1)));
        
        
        
        
        //convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                             //    "Используй /color:yellow/WASD /color:white/для управления молекулой", "Main"));
        //convo.Add(new DialogData("Loh", "Main", () => { levelController.ChangeLevel(1);}));
        dialogManager.Show(convo);
    }

    public void FinishedLvl2Methane()
    {
        List<DialogData> convo = new List<DialogData>();
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "У тебя получается все лучше и лучше! Нужно дать тебе что-то потруднее", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Есть у меня один интересный проект, метанол. Попробуй собрать молекулу", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "/color:lime/Глоб/color:white/, принеси нужные материалы!", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n" + "/color:white/" +
                                 "Уже бегу", "Slime",() => levelController.ChangeLevel(2)));
        dialogManager.Show(convo);
    }
    public void FinishedLvl3Methane()
    {
        List<DialogData> convo = new List<DialogData>();
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "Только не пей это, оно ядовитое. Отличная работа!", "Main"));
        convo.Add(new DialogData("/color:orange/Леша\n"+"/color:white/"+
                                 "По всей видимости у нас с Глобом не осталось материалов", "Main"));
        convo.Add(new DialogData("/color:lime/Глоб\n" + "/color:white/" +
                                 "Приходи завтра. Мы подготовим много интересных молекул для сборки", "Slime",() => Application.Quit()));
        dialogManager.Show(convo);
    }

    private void Update()
    {
       // if (levelController.levelList[levelController.currentLevelIndex]()) Convo2();
    }
}
