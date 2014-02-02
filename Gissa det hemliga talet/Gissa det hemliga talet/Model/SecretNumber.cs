using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa_det_hemliga_talet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess

    }
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;

        private List<int> _previousGuesses;
        private int _number;

        public bool CanMakeGuess { get; }
        public int Count { get; }
        public int? Number { get; }
        public Outcome Outcome { get; set; }
        public IEnumerable<int> PreviousGuesses {get;}
        


        // konstruktor
        public SecretNumber()
        {
            Initialize();
        }

        // Metod som _count och _random används i.
        public void Initialize()
        {
            // Initialiserar _random till en inbyggd metod av formen random, dvs skapar hemliga numret.
            Random _random = new Random();
            _number = _random.Next(1, 101);

        }

        // Metod av typen Outcome
        public Outcome MakeGuess(int guess)
        {
            return Outcome.Correct;
        }





    }
}
