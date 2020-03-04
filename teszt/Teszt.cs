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
        [TestCase]
        public void szabadHelyek()
        {
            var test = new Eloadas(3, 3);
            test.Lefoglal();
            Assert.AreEqual(8, test.SzabadHelyek, "Hibás a férőhelyek száma");
        }

        [TestCase]
        public void szabadHelyekTeli()
        {
            var test = new Eloadas(3, 3);
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            Assert.AreEqual(0, test.SzabadHelyek, "Hibás a férőhelyek száma");
        }

        [TestCase]
        public void szabadHelyekMinusz()
        {
            var test = new Eloadas(2, 2);
            Assert.Greater(test.SzabadHelyek, -1, "Hibás a férőhelyek száma");
        }

        [TestCase]
        public void teliEloadas()
        {
            var test = new Eloadas(3, 3);
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            test.Lefoglal();
            Assert.AreEqual(true, test.Teli, "Nem teli a Teli előadás.");
        }

        [TestCase]
        public void nemTeliEloadas()
        {
            var test = new Eloadas(2, 2);
            test.Lefoglal();
            Assert.AreEqual(false, test.Teli, "Teli a nem teli előadás.");
        }

        [TestCase]
        public void teliNull()
        {
            var test = new Eloadas(2, 2);
            Assert.AreNotEqual(null, test.Teli, "A változó null.");
        }


        [TestCase]
        public void foglaltTeszt()
        {
            var test = new Eloadas(3, 3);
            test.Lefoglal();
            Assert.AreEqual(true, test.Foglalt(1, 1), "Nem foglalt a felfoglalt hely.");
        }

        [TestCase]
        public void foglaltNull()
        {
            var test = new Eloadas(3, 3);
            test.Lefoglal();
            Assert.AreNotEqual(null, test.Foglalt(1, 3), "A változó null.");
        }

        [TestCase]
        public void lefoglalNull()
        {
            var test = new Eloadas(3, 3);
            Assert.AreNotEqual(null, test.Lefoglal(), "A változó null.");
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
