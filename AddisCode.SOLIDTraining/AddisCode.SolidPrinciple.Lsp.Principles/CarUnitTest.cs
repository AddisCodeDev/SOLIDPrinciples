using System;
using System.Drawing;
using AddisCode.SolidPrinciple.Lsp.Principles.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddisCode.SolidPrinciple.Lsp.Principles
{
    [TestClass]
    public class CarUnitTest
    {
        [TestMethod]
        public void Make_sure_car_can_start()
        {
            var car = new Car(Color.Aqua);
            //var car = new BrokenCar(Color.Aqua);          //Post condition Weakened
            //var car = new CrimeBossCar(Color.Aqua, true);   //Throws new type of exception
            try
            {
                car.StartEngine();
            }
            catch (OutOfFuelException)
            {
                Assert.Fail("Car is out of gas....");
            }
            Assert.IsTrue(car.IsEngineRunning);
        }

        [TestMethod]
        public void Make_sure_engine_is_running_after_start()
        {
            var car = new Car(Color.Aqua);
            //var car = new Prius(Color.Aqua);          // Changing invariants
            //var car = new StolenCar(Color.Aqua);      // Changing preconditions

            car.StartEngine();

            Assert.IsTrue(car.IsEngineRunning);
        }
        
        [TestMethod]
        public void Make_sure_the_car_is_painted_correctly()
        {
            var car = new Car(Color.Aqua);
            //var car = new PimpedCar(Color.Aqua);    // Violating history constraint
            //car.setTempreture(30);

            Assert.AreEqual(Color.Aqua, car.Color);
        }
    }
}
