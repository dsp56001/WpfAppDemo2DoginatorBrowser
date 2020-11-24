using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppDemo2DoginatorBrowser.Models
{
    class Dog
    {
        //Properties
        public string Name;
        public int Age;
        public int Weight;
        public string BarkSound;
        public string Image;

        //Constructor
        public Dog()
        {
            this.Age = 2;
            this.Name = "Fido";
            this.Weight = 2;
            this.BarkSound = "Woof!";
            this.Image = "/Assets/Fido.jpg";
        }

        //Methods

        /// <summary>
        /// Bark Method return the bark sound
        /// </summary>
        /// <returns>string the sound of the dog bark</returns>
        public string Bark()
        {
            return this.BarkSound;
        }

        /// <summary>
        /// Overloaded bark method returns multple barks
        /// </summary>
        /// <param name="howMany">int of om many times to bark</param>
        /// <returns>string of all the barks</returns>
        public string Bark(int howMany)
        {
            string barks = "";
            for (int i = 0; i < howMany; i++)
            {
                barks += $"{this.BarkSound} ";
            }
            return barks;
        }

        /// <summary>
        /// The dog eats and the weight goes up
        /// </summary>
        public void Eat()
        {
            this.Weight++;
        }

        /// <summary>
        /// The dog poops and the weight goes down
        /// </summary>
        public void Poop()
        {
            if(this.Weight > 0)
                this.Weight--;
        }

        public string About()
        {
            return $"{this.Name} is {this.Age} years old and sound like {this.Bark()}";
        }
    }
}
