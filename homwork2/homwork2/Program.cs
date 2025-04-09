using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homwork2
{
    class Program
    {
        public static string CON = ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");
        public static int number;
        public static string[] re;
        public static char[] UserAnswer;
        public static string[] question;
        public static string[] typeofquestion;
        public static char[] correctAnswers;
        public static int Wrong()
        {
            //function for wrong answers
            UserAnswer = new char[number];
            question = new string[number];
            typeofquestion = new string[number];
            correctAnswers = new char[number];
            int Total = 0;
            for (int cw = 0; cw < number; cw++)
                if (UserAnswer[cw] != correctAnswers[cw])
                {
                    Total += 1;
                }
            return Total;
        }
        public static int Right_Answer()
        {
            //function for Right answers
            int Total = 0;
            for (int cw = 0; cw < number; cw++)
                if (UserAnswer[cw] == correctAnswers[cw])
                {
                    Total += 1;
                }
            return Total;
        }

        static void Main(string[] args)
        {
            int CountCharacters;

            string[] Qus = { "What is The Must Repeated Charachter In The Follwoing Charachter ?",
                    "What is The Least Repeated Charachter In The Follwoing Charachter ?" };
            string Answe_User;

            int num = CON.Length;

            Console.WriteLine("Pleas Enter The Maximum Number of Question :");
            number = int.Parse(Console.ReadLine());


            while (number <= 0)
            {
                Console.WriteLine("The Number Must Be Greater Than Zero , Pleas Try Again :");
                number = int.Parse(Console.ReadLine());

            }

            re = new string[number];
            for (int i = 0; i < number; i++)
            {
                string emptystr = "";
                Console.WriteLine("===========================");
                Console.WriteLine("please enter an integer value between 3 and 100 (the number of characters from which to enumerate certain (Odd?Even?primary) number == Degree of difficulty)");
                CountCharacters = int.Parse(Console.ReadLine());
                while (CountCharacters > 100 || CountCharacters < 3)
                {
                    Console.WriteLine("please enter an integer value between 3 and 100 (the number of characters from which to enumerate certain (Odd?Even?primary) number == Degree of difficulty)");
                    CountCharacters = int.Parse(Console.ReadLine());
                }
                Random random = new Random();
                for (int j = 0; j < CountCharacters; j++)
                {
                    int rand = random.Next(0, num - 1);
                    emptystr += CON[rand];
                }
                question[i] = emptystr;
                int typeQuestion = random.Next(2);
                Console.WriteLine(Qus[typeQuestion]);


                Console.WriteLine(emptystr);
                int[] frequency = new int[255];
                int CHAR;
                if (typeQuestion == 0)
                {
                    int j = 0, max, l;
                    typeofquestion[i] = "Must";

                    l = emptystr.Length;

                    for (j = 0; j < 255; j++)
                    {
                        frequency[j] = 0;
                    }

                    j = 0;
                    while (j < l)
                    {
                        CHAR = (int)emptystr[j];
                        frequency[CHAR] += 1;

                        j++;
                    }
                    max = 0;
                    for (j = 0; j < 255; j++)
                    {
                        if (j != 32)
                        {
                            if (frequency[j] > frequency[max])
                                max = j;
                        }
                        correctAnswers[i] = Convert.ToChar(max);

                    }
                }
                else if (typeQuestion == 1)
                {
                    int j = 0, l;
                    typeofquestion[i] = "Least";
                    l = emptystr.Length;
                    for (j = 0; j < 255; j++)
                    {
                        frequency[j] = 0;
                    }

                    j = 0;
                    while (j < l)
                    {
                        CHAR = (int)emptystr[j];
                        frequency[CHAR] += 1;

                        j++;
                    }

                    int min = 0;
                    for (j = 0; j < 255; j++)
                    {
                        if (j != 32)
                        {
                            if (frequency[j] < frequency[min])
                                min = j;
                        }
                        correctAnswers[i] = Convert.ToChar(min);
                    }
                }
                Console.WriteLine("To ignore the question type Ignore");
                Answe_User = Console.ReadLine();
                if (Answe_User == " " || Answe_User == "Igonre")
                    UserAnswer[i] = '0';
                else
                    UserAnswer[i] = Convert.ToChar(Answe_User);
            }

            string ar;
            while (true)
            {
                //to get the number of wrong or right answers
                Console.WriteLine("To get the number of wrong answers, type 1");
                Console.WriteLine("To get the number of right answers, type 2");
                Console.WriteLine("To view all the questions with correct and answered response ,type 3");
                Console.WriteLine("To exit, type exit");
                ar = Console.ReadLine();
                if (ar == "1")
                {
                    Console.WriteLine("wrong answers is : " + Wrong());
                }
                else if (ar == "2")
                {
                    Console.WriteLine("right answers is : " + Right_Answer());
                }
                else if (ar == "3")
                {
                    Console.WriteLine("Question\t Type\t User Answer\t Correct Answer");
                    Console.WriteLine("=========================================================");
                    for (int i = 0; i < number; i++)
                        Console.WriteLine(question[i] + "\t" + typeofquestion[i] + "\t" + UserAnswer[i] + "\t" + correctAnswers[i]);
                }
                else if (ar == "exit")
                    break;
                else
                {
                    Console.WriteLine("not found");
                }
            }



        }

    }

}