using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class SecretNumber : IEnumerable
    {
        // Privata fält
        public const int MaxNumberOfGuesses = 7;

        // Här ska mina gissningar sparas efterhand.
        private List<int> _previousGuesses;
        // Innehåller det hemliga talet
        private int _number;

        // Egenskaper

        // Egenskap som skapar "gömt" fält count som trots ej deklarerat fungerar räkna upp ifrån konstruktorn. Har getter som retunerar true eller false.
        public bool CanMakeGuess
        {
            get
            {
                if (Count < MaxNumberOfGuesses)
                {
                    return true;
                }
                return false;
            }

        }
        private int Count
        {
            get
            {
                return PreviousGuesses.Count;
            }
        }
        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
        }
        public Outcome Outcome { get; private set; }

        // Ska användas för hämta tidigare gissningar. som har sparats i listan
        public ReadOnlyCollection<int> PreviousGuesses
        {
            get { return new ReadOnlyCollection<int>(_previousGuesses); }
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
            _previousGuesses.Clear();
            
            // Initialiserar _random till en inbyggd metod av formen random, dvs skapar hemliga numret.
            Random _random = new Random();
            _number = _random.Next(1, 101);

            Outcome = Outcome.Indefinite;
        }

        // Metod av typen Outcome
        public Outcome MakeGuess(int guess)
        {

            if (guess < 1 || guess < 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (CanMakeGuess == false)
            {
                return Outcome.NoMoreGuesses;
            }
            // Eftersom en Lissta så kan jag använda inbyggda metoden Contains för jämföra om någon gissar samma nummer igen.
            if (PreviousGuesses.Contains(guess))
            {
                return Outcome.PreviousGuess;
            }
            else if (guess < _number)
            {
                return Outcome.Low;
            }
            else if (guess < _number)
            {
                return Outcome.High;
            }
            else
            {
                return Outcome.Correct;
            }

        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
