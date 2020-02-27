using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProgram
{

    public class ComplexGame
    {
        private readonly Random _rnd = new Random();
        private List<Position> _startPositions = new List<Position>();

        public void Setup(int pieceNum)
        {
            //初始随机位置,且位置不同
            
            for (int i = 0; i < pieceNum; i++)
            {
                var position= GetRandoMPosition();
                while (!IsNoOverrid(_startPositions, position))
                {
                    GetRandoMPosition();
                }
                
                _startPositions.Add(position);
            }

        }
        //传入移动次数和一个或多个棋子
        public void Play(int moves,params Piece[] pieces)
        {
            if (pieces.Length == 0)
            {
                Console.WriteLine("没有棋子");
                Console.ReadLine();
            }
            else
            {
                Setup(pieces.Length);


                // TODO: Play the game moves here
                for (int i = 1; i <= pieces.Length; i++)
                {
                    Console.WriteLine("初始位置: No.{0} piece position is ({1})", i, _startPositions[i - 1]);

                }
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------");
                for (int i = 1; i <= moves; i++)
                {
                    var movesPositions = _startPositions;
                    for (int j = 0; j < pieces.Length; j++)
                    {
                        var movesPosition = NextPos(pieces[j], movesPositions[j]);
                        while (!IsNoOverrid(movesPositions, movesPosition))
                        {
                            movesPosition = NextPos(pieces[j], movesPositions[j]);
                        }
                        //判断棋子位置是否重复

                        movesPositions[j] = movesPosition;
                        Console.WriteLine("第{0}次移动: NO.{1} piece position is ({2})", i, j + 1, movesPosition);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("---------------------------------------------------");
                }
            }
        }
        //获得一个随机位置
        public Position GetRandoMPosition() 
        {
            var pos = new Position(_rnd.Next(1, 9), _rnd.Next(1, 9));
            return pos;
        }
        //移动一次
        public Position NextPos(Piece piece, Position position)
        {
            var possibleMove = piece.ValidMovesFor(position).ToList();
            return possibleMove[_rnd.Next(possibleMove.Count)];
        }
        //是否重复
        public Boolean IsNoOverrid(List<Position> positions, Position position)
        {
            foreach (var item in positions)
            {
                if ((item.X == position.X) & (item.Y == position.Y))
                {
                    return false;
                }
            }
            return true;
        }
    }

    //基类棋子
    public class Piece
    {
        public virtual int[,] Moves { get; }
        public IEnumerable<Position> ValidMovesFor(Position pos)
        {
            for (var i = 0; i <= Moves.GetUpperBound(0); i++)
            {
                var newX = pos.X + Moves[i, 0];
                var newY = pos.Y + Moves[i, 1];
                if (newX > 8 || newX < 1 || newY > 8 || newY < 1)
                    continue;
                yield return new Position(newX, newY);
            }
        }
    }
    public class Bishop : Piece
    {
        public override int[,] Moves
        {
            get
            {
                return new[,]
                    { 
                         //沿对角线移动
                        { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 },
                        { 2, 2 }, { 2, -2 }, { -2, 2 }, { -2, -2 },
                        { 3, 3 }, { 3, -3 }, { -3, 3 }, { -3, -3 },
                        { 4, 4 }, { 4, -4 }, { -4, 4 }, { -4, -4 },
                        { 5, 5 }, { 5, -5 }, { -5, 5 }, { -5, -5 },
                        { 6, 6 }, { 6, -6 }, { -6, 6 }, { -6, -6 },
                        { 7, 7 }, { 7, -7 }, { -7, 7 }, { -7, -7 },
                    };
            }


        }
    }

    public class Queen : Piece
    {
        public override int[,] Moves
        {
            get
            {
                return new[,]
                            { 
                        //沿对角线移动
                        { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 },
                        { 2, 2 }, { 2, -2 }, { -2, 2 }, { -2, -2 },
                        { 3, 3 }, { 3, -3 }, { -3, 3 }, { -3, -3 },
                        { 4, 4 }, { 4, -4 }, { -4, 4 }, { -4, -4 },
                        { 5, 5 }, { 5, -5 }, { -5, 5 }, { -5, -5 },
                        { 6, 6 }, { 6, -6 }, { -6, 6 }, { -6, -6 },
                        { 7, 7 }, { 7, -7 }, { -7, 7 }, { -7, -7 },
                        //水平或垂直方向移动
                        { -7,0},{ -6,0},{ -5,0},{ -4,0},{ -3,0},{ -2,0},{ -1,0},{ 1,0},{ 2,0},{ 3,0},{ 4,0},{ 5,0},{ 6,0},{ 7,0},
                        { 0,-7},{ 0,-6},{ 0,-5},{ 0,-4},{ 0,-3},{ 0,-2},{ 0,-1},{ 0,1},{ 0,2},{ 0,3},{ 0,4},{ 0,5},{ 0,6},{ 0,7},
                                 };

            }
        }
    }
    public class Knight:Piece
    {
        public override int[,] Moves
        {
            get
            {
                return new[,]{ { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }, { 2, 1 }, { -2, 1 }, { 2, -1 }, { -2, -1 } };

            }
        }

    }
}

