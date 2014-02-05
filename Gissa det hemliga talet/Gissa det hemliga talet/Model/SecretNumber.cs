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
    public class SecretNumber
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
                if (Count == MaxNumberOfGuesses)
                {
                    return false;

                }
                return true;
            }

        }
        // Räknar mot min lista hur många gissningar jag gjort.
        public int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }
        // Retunerar null om jag kan gissa, annars retunerar den det hemliga numret.
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
        //  Autoimplementerande egenskap som jag är osäker på hur den fungerar.
        public Outcome Outcome { get; private set; }

        // Ska användas för hämta tidigare gissningar. som har sparats i listan
        public IEnumerable<int> PreviousGuesses
        {
            get { return _previousGuesses.AsReadOnly(); }
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
            Random random = new Random();
            _number = random.Next(1, 101);
            Outcome = Outcome.Indefinite;
        }

        // Metod av typen Outcome
        public Outcome MakeGuess(int guess)
        {
            // Första 3 if satserna används för kontrollera att det är giltig gissning.
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            // Eftersom en Lissta så kan jag använda inbyggda metoden Contains för jämföra om någon gissar samma nummer igen.
            if (PreviousGuesses.Contains(guess))
            {
                Outcome = Outcome.PreviousGuess;
            }
            if (CanMakeGuess == false)
            {
                Outcome = Outcome.NoMoreGuesses;
            }
            else
            {
                _previousGuesses.Add(guess);
                if (guess < _number)
                {
                    Outcome = Outcome.Low;
                }
                else if (guess > _number)
                {
                    Outcome = Outcome.High;
                }
                else
                {
                    Outcome = Outcome.Correct;
                }
            }
            return Outcome;
        }
    }
}
