using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game15Csharp
{
    class Game
    {

        int size;
        int spaceX, spaceY, spaceRX, spaceRY;
        int[,] RightMap;
        int[,] GameMap;
        static Random rand = new Random();

        public Game (int size)
        {
            this.size = size;
            RightMap = new int [size, size];
            GameMap = new int [size, size];
        }

        public void Start ()
        {

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    RightMap[x, y] = CoordsToPosition(x, y)+1;
                }
            }
            spaceRX = size - 1;
            spaceRY = size - 1;
            RightMap[spaceRX,spaceRY] = 0;


           /* 
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    GameMap[x, y] = CoordsToPosition(x, y) + 1;
                }
            }
            spaceX = size - 1;
            spaceY = size - 1;
            GameMap[spaceX,spaceY] = 0;
           */ 

            CreateGameMap();

        }

        public void CreateGameMap()
        {
            
            bool [] NumIsFree = new bool [15]; // показывает, определи ли мы уже позицию i-костяшки 
            int[] Nums = new int[15]; // содержит номер костяшки, находящийся в i-позиции
            for (int i = 0; i <15; i++)
            {
                NumIsFree[i] = true; // объявляем, что все костяшки свободны изначально
            }
            bool flag; //флаг определяющий корректность выбора костяшки для данной позиции
            int RandNum;
            for (int i=0; i<15; i++)
            {
                flag = false;
                while(!flag)
                {
                    RandNum = rand.Next(1, 16);
                    if(NumIsFree[RandNum-1])  // если костяшка с таким номером свободна, то номер определен корректно
                    {
                        flag = true;
                        Nums[i] = RandNum;
                        NumIsFree[RandNum - 1] = false; // Костяшка занята
                    }
                   
                }
            }
            int Chaos = 0;  // количество беспорядков на поле
            int CurrNum;    // костяшка, для которой рассматриваем беспорядки
            for (int i=0; i<14; i++) 
            {
                CurrNum = Nums[i];
                for (int j=i+1; j<15; j++)
                {
                    if (CurrNum > Nums[j])
                    {
                        Chaos++;    // Считаем количесво беспорядков для костяшек на первых 14 - позициях
                    }
                }
            }
            if (Chaos % 2 == 1)     //Если общее число беспорядков нечетное, меняем костяшки на 14 и 15 позициях местами
            {
                int temp = Nums[13];
                Nums[13] = Nums[14];
                Nums[14] = temp;
            }
            for (int i=0; i<15; i++)
            {
                GameMap[i % 4, i / 4] = Nums[i];
            }
            int x=3, y=3;
            GameMap[x, y] = 0;
            spaceX = x;
            spaceY = y;
        }



        public void Shift (int position)
        {
            PositionToCoords(position, out int x,  out int y);
            if ((Math.Abs(spaceX-x) + Math.Abs(spaceY-y)) !=1)
                return;
            GameMap[spaceX, spaceY] = GameMap[x, y];
            GameMap[x, y] = 0;
            spaceX = x;
            spaceY = y;
        }


        public bool CheckMap()
        {
            int Count = 0;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (GameMap[x, y] == RightMap[x, y])
                    {
                        Count++;
                    }
                }
            }

            if (Count==16)
            {
                return true;
            }
            else return false;
        }

        public int GetNumber(int position)
        {
            PositionToCoords(position, out int x, out int y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return GameMap[x, y];
        }


        private int CoordsToPosition (int x, int y)
        {
            return y * size + x;
        }

        private void PositionToCoords (int position, out int x, out int y)
        {
            x = position % size;
            y = position / size;
        }

    }
}
