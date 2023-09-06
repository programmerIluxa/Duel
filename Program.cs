using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Traning5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int begin = 3;
            

            Console.WriteLine("Добро пожаловать в игру!");
            Console.Write("Введите имя игрока 1: ");
            Player player = new Player(Console.ReadLine());
            Console.Write("Введите имя игрока 2: ");
            Player player2 = new Player(Console.ReadLine());
            Console.Clear();
            Console.SetCursorPosition(50, 3);
            while(begin >= 0)
            {
                if(begin == 0)
                {
                    Console.SetCursorPosition(60, 3);
                    Console.WriteLine("ДУЭЛЬ");
                    Thread.Sleep(500);
                    Console.Clear();
                   
                    break;
                }
                Console.SetCursorPosition(50, 3);
                Console.WriteLine($"Дуэль начнется через: {begin}");
                begin--;
                Thread.Sleep(1000);
                Console.Clear();
            }
           
            int i = 1;
            while (player.Health > 0 || player2.Health > 0)
            {
                if(player.Health <= 0 || player2.Health <= 0)
                {
                    Console.SetCursorPosition(50, 3);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if(player.Health == 0)
                    {
                        //Console.WriteLine($"Победитель - игрок {player2.Name}");
                        //Thread.Sleep(1000);
                        Console.SetCursorPosition(45, 4);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Нажмите любую кнопку для выхода");
                    }
                    else
                    {
                        //Console.WriteLine($"Победитель - игрок {player.Name}");
                        //Thread.Sleep(1000);
                        Console.SetCursorPosition(45, 4);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Нажмите любую кнопку для выхода");
                    }
                    HealthIndicatorX(player.Health);
                    HealthIndicatorY(player2.Health);
                    XYPostion(player, player2);
                    Console.ReadKey();
                    break;
                }
                UserBegin(i);
                HealthIndicatorX(player.Health);
                HealthIndicatorY(player2.Health);
                XYPostion(player, player2);
                
                if(i % 2 == 1 || i == 1)
                {
                    XAttack(true, player, player2);
                    UserAttack(player, player2, i);
                }
                else
                {
                    YAttack(true, player, player2);
                    UserAttack(player, player2, i);
                }
                //XYPostion(player, player2);
                HealthIndicatorX(player.Health);
                HealthIndicatorY(player2.Health);
                XYPostion(player, player2);
                i++;
            }
           
        }

        static void UserBegin(int userCount)
        {
            int user1count = userCount;
            if(user1count % 2 == 1)
            {
                Console.SetCursorPosition(55, 3);
                Console.WriteLine("Выстрел игрока 1");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.SetCursorPosition(55, 3);
                Console.WriteLine("Выстрел игрока 2");
                Thread.Sleep(1000);
                Console.Clear();

            }
        }

        static void UserAttack(Player player, Player player1, int countUser)
        {
           

            if (countUser % 2 == 1 || countUser == 1)
            {
               
                Random random = new Random();
                int damage = random.Next(1, 31);
                player1.Player2Attack(damage);
            }
            else
            {
                
                Random random = new Random();
                int damage = random.Next(1, 31);
                player.Player2Attack(damage);
            }
            Console.Clear();
            

        }
       static void PositionX(int x)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(x, 7);
        }

        static void PositionY(int y)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(y, 7);
        }

        static void XYPostion(Player player, Player player2)
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            
            Console.SetCursorPosition(10, 6);
            player.ShowInfo();
            Console.SetCursorPosition(80, 6);
            player2.ShowInfo();
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("@");
            Console.SetCursorPosition(70, 7);
            Console.WriteLine("@");
        }

        static void XAttack(bool isOpen,Player player, Player player1)
        {
            HealthIndicatorX(player.Health);
            HealthIndicatorY(player1.Health);
            XYPostion(player, player1);
            Console.SetCursorPosition(40, 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Игрок 1 - нажмите любую кнопку, чтобы выстрелить");
            Console.ReadKey();
            int positionX = 51;
            while (isOpen)
            {
                XYPostion(player, player1);
                HealthIndicatorX(player.Health);
                HealthIndicatorY(player1.Health);
                PositionX(positionX);
                Console.WriteLine("-");
                positionX++;
                Thread.Sleep(25);
                Console.Clear();
                if (positionX == 70)
                {
                    isOpen = false;
                }
                //XYPostion(player, player1);
                //HealthIndicatorX(player.Health);
                //HealthIndicatorY(player1.Health);
            }
        }
        

        static void YAttack(bool isOpen, Player player, Player player1)
        {
            HealthIndicatorX(player.Health);
            HealthIndicatorY(player1.Health);
            XYPostion(player, player1);
            Console.SetCursorPosition(40, 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Игрок 2 - нажмите любую кнопку, чтобы выстрелить");
            Console.ReadKey();
            int positionY = 69;
            while (isOpen)
            {
                XYPostion(player, player1);
                HealthIndicatorX(player.Health);
                HealthIndicatorY(player1.Health);
                PositionY(positionY);
                Console.WriteLine("-");
                positionY--;
                Thread.Sleep(25);
                Console.Clear();
                if (positionY == 50)
                {
                    isOpen = false;
                }
                //XYPostion(player, player1);
                //HealthIndicatorX(player.Health);
                //HealthIndicatorY(player1.Health);
            }
        }

        static void HealthIndicatorX(int x)
        {
            int positionX = 10 + x;
            if (x < 0)
            {
                positionX = 10;
            }
            
            if(positionX == 10)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                for (int j = 10; j <= 40 - 1; j++)
                {
                    Console.SetCursorPosition(j, 4);
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                for (int i = 10; i <= positionX; i++)
                {
                    Console.SetCursorPosition(i, 4);
                    Console.WriteLine(" ");
                }
                Console.BackgroundColor = ConsoleColor.Red;
                for (int j = positionX; j <= 40 - 1; j++)
                {
                    Console.SetCursorPosition(j, 4);
                    Console.WriteLine(" ");
                }
            }
           
            //Console.SetCursorPosition(50, 5);
            
        }
        static void HealthIndicatorY(int y)
        {
            int positionY = 110 - y;
            if(y < 0)
            {
                positionY = 110;
            }
            if(positionY == 110)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                for (int i = 80; i <= 110; i++)
                {
                    Console.SetCursorPosition(i, 4);
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                for (int i = 80; i <= positionY; i++)
                {
                    Console.SetCursorPosition(i, 4);
                    Console.WriteLine(" ");
                }
                Console.BackgroundColor = ConsoleColor.Green;
                for (int i = positionY; i <= 110; i++)
                {
                    Console.SetCursorPosition(i, 4);
                    Console.WriteLine(" ");
                }
            }
            
           
        }

    }

    class Player
    {

        public int Health;
        public string Name;

        public Player(string name)
        {
            Health = 30;
            Name = name;
        }

        public void Player2Attack(int damage)
        {

            Health -= damage;
            if(Health <= 0)
            {
                Console.SetCursorPosition(55, 3);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Игрок {Name} побежден");
                Thread.Sleep(1000);

            }
           
        }

        public void ShowInfo()
        {
            if (Health <= 0)
                Console.WriteLine($"Игрок {Name}, Текущее здоровье 0");
            else
            {
                Console.WriteLine($"Игрок {Name}, Текущее здоровье {Health}");
            }
           
        }
    }
}
