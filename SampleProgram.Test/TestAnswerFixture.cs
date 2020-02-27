using System;
using System.Collections.Generic;
using System.Linq;
using ChessLib;
using NUnit.Framework;

namespace SampleProgram.Test
{
    [TestFixture]
    public class TestAnswerFixture
    {

        [Test]
        public void TestGetRandoMPosition()
        {
            var game = new ComplexGame();
            for (int i = 0; i < 50; i++)
            {
                var pos = game.GetRandoMPosition();
                Assert.IsTrue(pos.X <= 8 & pos.X >= 1&pos.Y<=8&pos.Y>=1);
            }
            
        }
        [Test]
        public void TestNextPos()
        {
            var game = new ComplexGame();
            Knight knight = new Knight();
            for (int i = 0; i < 50; i++)
            {
                var pos = game.GetRandoMPosition();
                var nextPos =game.NextPos(knight, pos);
                Assert.IsFalse(pos.ToString() == nextPos.ToString());
            }
        }
        [Test]
        public void TestIsNoOverrid()
        {
            var game = new ComplexGame();
            List<Position> positions = new List<Position> { new Position(1, 2), new Position(3, 2), new Position(2, 2) };
            Position posA = new Position(2, 2);
            Position posB = new Position(4, 2);
            Assert.IsFalse(game.IsNoOverrid(positions,posA));
            Assert.IsTrue(game.IsNoOverrid(positions, posB));
        }
        [Test]
        public void TestKnightMoveFromCorner()
        {
            var pos = new Position(1, 1);
            var knight = new Knight();

            var moves = new HashSet<Position>(knight.ValidMovesFor(pos));

            Assert.IsNotNull(moves);

            var possibles = new[] { new Position(2, 3), new Position(3, 2) };

            foreach (var possible in possibles)
            {
                Assert.IsTrue(moves.Contains(possible));
            }
        }

        [Test]
        public void TestPosition()
        {
            var pos = new Position(1, 1);
            Assert.AreEqual(1, pos.X);
            Assert.AreEqual(1, pos.Y);

            var pos2 = new Position(1, 1);

            Assert.AreEqual(pos, pos2);
        }
    }
}
