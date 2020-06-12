using System;
using System.Linq;
using AnimalCentre.IO;

namespace AnimalCentre.Core
{
    public class Engine

    {
        private AnimalCentre centerController;
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.centerController = new AnimalCentre();
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = String.Empty;
            while (true)
            {
                if (input == "End")
                {
                    break;
                }
                try
                {
                    input = this.reader.readInput();
                    this.ReadInput(input);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine("ArgumentException: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("InvalidOperationException: " + e.Message);
                }
            }
           this.writer.WriteLine(this.centerController.AdoptedAnimals());
        }
        private void ReadInput(string input)
        {
            string[] tokens = input.Split(" ");
            var output = String.Empty;
            string[] regData = tokens.Skip(1).ToArray();

            switch (tokens[0])
            {
                case "RegisterAnimal":

                    var animal = regData[0];
                    var name = regData[1];
                    var energy = int.Parse(regData[2]);
                    var happiness = int.Parse(regData[3]);
                    var playTime = int.Parse(regData[4]);
                    output = this.centerController.RegisterAnimal(animal, name, energy, happiness, playTime);
                    break;
                case "Chip":
                    string animalName = regData[0];
                    int procedureTime = int.Parse(regData[1]);
                    output = this.centerController.Chip(animalName, procedureTime);
                    break;
                case "Play":
                    string playName = regData[0];
                    int playProcTime = int.Parse(regData[1]);
                    output = this.centerController.Play(playName, playProcTime);
                    break;
                case "Fitness":
                    string fitnessName = regData[0];
                    int fitnessTime = int.Parse(regData[1]);
                    output = this.centerController.Fitness(fitnessName, fitnessTime);
                    break;
                case "NailTrim":
                    string nailTrimName = regData[0];
                    int nailTrimTime = int.Parse(regData[1]);
                    output = this.centerController.NailTrim(nailTrimName, nailTrimTime);
                    break;
                case "Vaccinate":
                    string vaccinateName = regData[0];
                    int vaccinateTime = int.Parse(regData[1]);
                    output = this.centerController.Vaccinate(vaccinateName, vaccinateTime);
                    break;
                case "DentalCare":
                    string dentalName = regData[0];
                    int dentalTime = int.Parse(regData[1]);
                    output = this.centerController.DentalCare(dentalName, dentalTime);
                    break;
                case "Adopt":
                    string adoptAnimal = regData[0];
                    string owner = regData[1];
                    output = this.centerController.Adopt(adoptAnimal, owner);
                    break;
                case "History":
                    output = this.centerController.History(tokens[1]);
                    break;
            }
            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}