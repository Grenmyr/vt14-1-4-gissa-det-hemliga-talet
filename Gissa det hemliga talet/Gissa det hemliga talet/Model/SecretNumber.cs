using System;
using System.Collections.Generic;
using System.Collections;
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
    public class SecretNumber: IEnumerable
    {
        // Privata fält
        public const int MaxNumberOfGuesses = 7;

        // Här ska mina gissningar sparas efterhand.
        private List<int> _previousGuesses;
        // Innehåller det hemliga talet
        private int _number ;

        // Egenskaper

        // Egenskap som skapar "gömt" fält count som trots ej deklarerat fungerar räkna upp ifrån konstruktorn. Har getter som retunerar true eller false.
        public bool CanMakeGuess
        {
            get { return Count < MaxNumberOfGuesses; }
        }
        protected int Count { get; private set; }
        public int? Number { get { return _number; } }
        public Outcome Outcome { get;  private set; }

        // Ska användas för hämta tidigare gissningar. som har sparats i listan
        public IEnumerable<int> PreviousGuesses 
        {
            get { return _previousGuesses; }
        }

        // Konstruktor
        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }

        // Metod som _count och _random används i.
        public void Initialize()
        {
            // Initialiserar _random till en inbyggd metod av formen random, dvs skapar hemliga numret.
            Random _random = new Random();
            _number = _random.Next(1, 101);
            Count++;
        }

        // Metod av typen Outcome
        public Outcome MakeGuess(int guess)
        {
            return Outcome.Correct;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
