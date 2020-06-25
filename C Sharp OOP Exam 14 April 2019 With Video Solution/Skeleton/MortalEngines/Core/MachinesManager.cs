namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        PilotRepository pilotRepository;
        MachineRepository machineRepository;
        PilotFactory pilotFactory;
        MachineFactory machineFactory;
        public MachinesManager()
        {
            pilotRepository = new PilotRepository();
            machineRepository = new MachineRepository();
            pilotFactory = new PilotFactory();
            machineFactory = new MachineFactory();
        }
        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machineRepository.Machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine defendingMachine = this.machineRepository.Machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackingMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:F2}";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilotRepository.Pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            IMachine machine = this.machineRepository.Machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string HirePilot(string name)
        {
            if (pilotRepository.ContainsPilot(name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = pilotFactory.CreatePilot(name);

            pilotRepository.AddPilot(pilot);

            return $"Pilot {name} hired";
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = machineRepository.Machines.First(m => m.Name == machineName);

            return machine.ToString();
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machineRepository.ContainsMachine(name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine fighter = machineFactory.CreateMachine("Fighter", name, attackPoints, defensePoints);

            machineRepository.AddMachine(fighter);

            bool isAggressive = ((IFighter)fighter).AggressiveMode;
            if (isAggressive)
            {
                return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
            }

            return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: OFF";


        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machineRepository.ContainsMachine(name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine tank = machineFactory.CreateMachine("Tank", name, attackPoints, defensePoints);

            machineRepository.AddMachine(tank);

            return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilotRepository.Pilots.First(p => p.Name == pilotReporting);

            return pilot.Report();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!machineRepository.ContainsMachine(fighterName))
            {
                return $"Machine {fighterName} could not be found";
            }

            IMachine fighter = machineRepository.Machines.First(m => m.Name == fighterName);

            ((IFighter)fighter).ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!machineRepository.ContainsMachine(tankName))
            {
                return $"Machine {tankName} could not be found";
            }

            IMachine tank = machineRepository.Machines.First(m => m.Name == tankName);

            ((ITank)tank).ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}