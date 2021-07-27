using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeGameDigitalTechnologyVer1._4
{
  public class GameRecord
    {
        //This is a class which used to store and instance the variable we may use  during process.
        private string name;
        private int death;
        private int score;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Death
        {
            get { return death; }
            set { death = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
