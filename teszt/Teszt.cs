using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloadasProject.teszt
{
    [TestFixture]
    class Teszt
    {
        Eloadas teszt;
         [SetUp]
        public void Setup()
        {
            teszt = new Eloadas(3,3);
        }
        [TestCase]
        public void szabadHelyek()
        {
            teszt.Lefoglal();
            Assert.AreEqual(8, teszt.SzabadHelyek, "Hibás a férőhelyek száma");
        }

        [TestCase]
        public void szabadHelyekTeli()
        {
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            Assert.AreEqual(0, teszt.SzabadHelyek, "Hibás a férőhelyek száma");
        }

        [TestCase]
        public void szabadHelyekMinusz()
        {
            Assert.Greater(teszt.SzabadHelyek, -1, "Hibás a férőhelyek száma");
        }

        [TestCase]
        public void teliEloadas()
        {
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            Assert.AreEqual(true, teszt.Teli, "Nem teli a Teli előadás.");
        }

        [TestCase]
        public void nemTeliEloadas()
        {
            teszt.Lefoglal();
            Assert.AreEqual(false, teszt.Teli, "Teli a nem teli előadás.");
        }

        [TestCase]
        public void teliNull()
        {
            Assert.AreNotEqual(null, teszt.Teli, "A változó null.");
        }


        [TestCase]
        public void foglaltTeszt()
        {
            teszt.Lefoglal();
            Assert.AreEqual(true, teszt.Foglalt(1, 1), "Nem foglalt a felfoglalt hely.");
        }

        [TestCase]
        public void foglaltNull()
        {
            teszt.Lefoglal();
            Assert.AreNotEqual(null, teszt.Foglalt(1, 3), "A változó null.");
        }

        [TestCase]
        public void lefoglalNull()
        {
            Assert.AreNotEqual(null, teszt.Lefoglal(), "A változó null.");
        }

        [TestCase]
        public void helytelenBemenet()
        {
            Assert.Throws<ArgumentException>(() => {
                var test = new Eloadas(0, -1);
            });
        }

        [TestCase]
        public void foglaltTesztOutOfRange()
        {
            var test = new Eloadas(2, 2);
            Assert.Throws<IndexOutOfRangeException>(() => {
                test.Foglalt(10, 10);
            });
        }

        [TestCase]
        public void hibasFoglaltTeszt()
        {
            var test = new Eloadas(2, 2);
            test.Lefoglal();
            Assert.Throws<ArgumentException>(() => {
                test.Foglalt(0, 0);
            });
        }
    }
}
