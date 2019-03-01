using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 王者荣耀英雄识别
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                //初始化
                string[] conditions = {
                "0.团队增益技能",
                "1.物理攻击",
                "2.基础攻速不低于28%",
                "3.基础攻速低于28%",
                "4.法术攻击",
                "5.基础血量大于3200",
                "6.突进技能",
                "7.高爆发",
                "8.法师",
                "9.坦克",
                "10.刺客",
                "11.辅助",
                "12.射手",
                "13.战士",
                "14.打野",
                "15.女性",
                "16.男性",
                "17.全图技能",
                "18.隐身技能",
                "19.真实伤害",
                "20.复活技能",
                "21.沉默技能",
                "22.拥有坐骑",
                "23.芈月",
                "24.刘邦",
                "25.阿珂",
                "26.露娜",
                "27.貂蝉",
                "28.太乙真人",
                "29.孙膑",
                "30.亚瑟",
                "31.花木兰",
                "32.成吉思汗 "
                };

                Rule[] rules = new Rule[26];
                for (int i = 0; i < 26; i++)
                {
                    rules[i] = new Rule();
                }

                rules[0].conditionIds = new int[2] { 0, -1 };
                rules[0].resultId = 11;
                rules[1].conditionIds = new int[3] { 1, 2, -1 };
                rules[1].resultId = 12;
                rules[2].conditionIds = new int[3] { 1, 3, -1 };
                rules[2].resultId = 13;
                rules[3].conditionIds = new int[2] { 4, -1 };
                rules[3].resultId = 8;
                rules[4].conditionIds = new int[2] { 5, -1 };
                rules[4].resultId = 9;
                rules[5].conditionIds = new int[3] { 6, 7, -1 };
                rules[5].resultId = 10;
                rules[6].conditionIds = new int[4] { 8, 9, 15, -1 };
                rules[6].resultId = 23;
                rules[7].conditionIds = new int[4] { 9, 16, 17, -1 };
                rules[7].resultId = 24;
                rules[8].conditionIds = new int[3] { 15, 18, -1 };
                rules[8].resultId = 25;
                rules[9].conditionIds = new int[4] { 8, 10, 14, -1 };
                rules[9].resultId = 26;
                rules[10].conditionIds = new int[3] { 15, 19, -1 };
                rules[10].resultId = 27;
                rules[11].conditionIds = new int[3] { 11, 20, -1 };
                rules[11].resultId = 28;
                rules[12].conditionIds = new int[3] { 8, 21, -1 };
                rules[12].resultId = 29;
                rules[13].conditionIds = new int[4] { 13, 16, 21, -1 };
                rules[13].resultId = 30;
                rules[14].conditionIds = new int[4] { 13, 15, 21, -1 };
                rules[14].resultId = 31;
                rules[15].conditionIds = new int[3] { 12, 22, -1 };
                rules[15].resultId = 32;
                rules[16].conditionIds = new int[2] { 23, -1 };
                rules[16].resultId = 23;
                rules[17].conditionIds = new int[2] { 24, -1 };
                rules[17].resultId = 24;
                rules[18].conditionIds = new int[2] { 25, -1 };
                rules[18].resultId = 25;
                rules[19].conditionIds = new int[2] { 26, -1 };
                rules[19].resultId = 26;
                rules[20].conditionIds = new int[2] { 27, -1 };
                rules[20].resultId = 27;
                rules[21].conditionIds = new int[2] { 28, -1 };
                rules[21].resultId = 28;
                rules[22].conditionIds = new int[2] { 29, -1 };
                rules[22].resultId = 29;
                rules[23].conditionIds = new int[2] { 30, -1 };
                rules[23].resultId = 30;
                rules[24].conditionIds = new int[2] { 31, -1 };
                rules[24].resultId = 31;
                rules[25].conditionIds = new int[2] { 32, -1 };
                rules[25].resultId = 32;

                int[] flags = new int[33];
                for (int i = 0; i < 33; i++)
                {
                    flags[i] = 0;
                }


                //主程序
                showConditions(conditions);
                inputConditions(flags);
                Console.WriteLine("请选择推理方式：1.正向推理；2.逆向推理");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    forward_match(rules, flags, conditions);
                }
                else if (choice == 2)
                {
                    back_match(rules, flags, conditions);
                }
                else
                {
                    Console.WriteLine("输入无效！");
                }

                Console.WriteLine("\n\n---------------------------------------------------------------------------\n\n");
            }

            

        }


        


        public static void showConditions(string[] conditions)
        {

            Console.WriteLine("                        《王者荣耀》英雄识别系统                \n");
            Console.WriteLine("所有条件：");
            for (int j = 0; j < conditions.Length; j++)
            {
                Console.WriteLine(conditions[j]);
            }
            Console.WriteLine();

        }

        public static void inputConditions(int[] flags) {
            Console.WriteLine("请输入要勾选的条件序号（以 -1 结束）：");
            int k = Convert.ToInt32(Console.ReadLine());
            while (k != -1)
            {
                flags[k] = 1;
                k = Convert.ToInt32(Console.ReadLine());
            }
            /*for (int i = 0; i < flags.Length; i++) {
                Console.Write(flags[i]+" ");
            }
            Console.WriteLine();*/
        }

        public static void forward_match(Rule[] rules,int[] flags, string[] conditions) {
            int m, n, cid, rid;
            for (m = 0; m < 26; m++)
            {
                n = 0;
                cid = rules[m].conditionIds[n];
                while (cid != -1)
                {
                    if (flags[cid] == 0)
                        break;
                    n++;
                    cid = rules[m].conditionIds[n];
                }
                if (cid == -1)
                {
                    rid = rules[m].resultId;
                    flags[rid] = 1;
                    //Console.WriteLine("运用了规则:");
                    n = 0;
                    int flag = 0;
                    for (int o = 0; o < flags.Length; o++) {
                        if (flags[o]==1 && ((IList)rules[m].conditionIds).Contains(o)==false)
                            flag = 1;
                    }
                    while (rules[m].conditionIds[n] != -1)
                    {
                        flags[rules[m].conditionIds[n]] = 0;
                        //Console.Write(conditions[rules[m].conditionIds[n]] + " ");
                        n++;
                    }
                    //Console.WriteLine("->" + conditions[rid]);
                    if (rid > 22 && rid < 33 && flag==0) {
                        Console.WriteLine("匹配到英雄:"+conditions[rid]);
                        break;
                    }
                }
            }
            if (m >= 26) {
                Console.WriteLine("没有匹配到符合该条件的英雄");
            }
        }

        


        public static void back_match(Rule[] rules, int[] flags, string[] conditions) {

            for (int i = flags.Length-1; i >=0; i--) {
                if (flags[i] == 1) {
                    SetPre(i,rules,flags);
                }
            }

            int[] flags2 = new int[33];
            int p, q, r;
            for (p = 23; p < 33; p++)
            {
                for (q = 0; q < 33; q++)
                    flags2[q] = 0;
                SetPre(p, rules, flags2);
                /*for (int i = 0; i < flags2.Length; i++) {
                    Console.Write(flags2[i]+" ");
                }
                Console.WriteLine();*/
                int flag = 0;
                for (r = 0; r < 33; r++)
                {
                    if (flags2[r] != flags[r])
                    {
                        flag = 1;
                        break;
                    }
                }

                if (r >= 33)
                {
                    Console.WriteLine("匹配到英雄:" + conditions[p]);
                    break;
                }

                if (flag == 1)
                    continue;

            }
            if (p >= 33)
                Console.WriteLine("没有匹配到符合该条件的英雄。");

        }

        public static void SetPre(int resid, Rule[] rules, int[] flags2)
        {
            int i, j;
            for (i = 0; i < 26; i++)
            {
                if (resid == rules[i].resultId && resid!=rules[i].conditionIds[0])
                {
                    /*for (int k = 0; k < rules[i].conditionIds.Length && rules[i].conditionIds[k] != -1; k++)
                    {
                        Console.Write(rules[i].conditionIds[k] + " ");
                    }
                    Console.WriteLine(":" + rules[i].resultId);*/
                    
                    for (j = 0; j < rules[i].conditionIds.Length && rules[i].conditionIds[j] != -1; j++)
                    {
                        flags2[rules[i].resultId] = 0;
                        flags2[rules[i].conditionIds[j]] = 1;
                        if (resid == rules[i].conditionIds[j])
                            break;
                        SetPre(rules[i].conditionIds[j], rules, flags2);
                    }

                }
            }
        }


        



    }



    
        

        

    

    class Rule
    {
        public int[] conditionIds;
        public int resultId;  
    }


}
