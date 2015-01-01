using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddisCode.SolidPrinciple.Lsp.Principles.Entities
{
    public class Car
    {
        private bool _hasFuel = true;
        public bool IsEngineRunning { get; private set; }
        public Color Color { get; protected set; }

        public Car(Color color)
        {
            this.Color = color;
        }

        public virtual void StartEngine()
        {
            if (!_hasFuel)
                throw new OutOfFuelException("Cant start car without Fuel in tansk..."); 
            IsEngineRunning = true;

        }
        public virtual void StopEngine()
        {
            IsEngineRunning = false;
        }

    }
    public class BrokenCar : Car
    {
        public BrokenCar(Color color) : base(color)
        {
        }

        public override void StartEngine()
        {
            throw new NotImplementedException();
        }
    }

    public class CrimeBossCar : Car
    {
        private readonly bool _boobyTrap;
        public CrimeBossCar(Color color, bool boobyTrap) : base(color)
        {
            _boobyTrap = boobyTrap;
        }

        public override void StartEngine()
        {
            if (_boobyTrap)
                throw new MetYourMakerException("Boom!! You are dead!");
            base.StartEngine();
        }
    }

    public class Prius : Car
    {
        public Prius(Color color) : base(color)
        {
        }

        public override void StartEngine()
        {
        }

        public override void StopEngine()
        {
        }
    }

    public class StolenCar : Car
    {
        private bool _ignitionWiresStripped;

        public StolenCar(Color color) : base(color)
        {
        }

        public void StripIgnitionWire()
        {
            _ignitionWiresStripped = true;
        }

        public override void StartEngine()
        {
            if (!_ignitionWiresStripped)
                return;
            base.StartEngine();
        }
    }

    public class PimpedCar : Car
    {
        private readonly Color _color;
        public PimpedCar(Color color) : base(color)
        {
        }

        public void setTempreture(int temp)
        {
            if (temp < 25)
                this.Color = _color;
            else
                Color = Color.Crimson;
        }
    }

}
