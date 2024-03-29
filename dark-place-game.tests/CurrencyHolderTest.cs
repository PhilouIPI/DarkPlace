using System;
using Xunit;

namespace dark_place_game.tests
{
    
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true; //on change donc false par true
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            var ch = new CurrencyHolder ("Brouzouf", EXEMPLE_CAPACITE_VALIDE,0);        
        }

        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            var ch = new CurrencyHolder ("Dollard", EXEMPLE_CAPACITE_VALIDE,0); 
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var ch = new CurrencyHolder ("Dollard",EXEMPLE_CAPACITE_VALIDE,500);
            ch.Store(10);
            Assert.True(ch.CurrentAmount == 510);            
        }

        
        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 500, 490);
                ch.Store(20);
                };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il est possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("EU", EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de curren            
            // Astuce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer
            Action mauvaisAppel = () => {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,250,200);
            ch.Withdraw(-60);
            };
            Assert.Throws<CantWitchDrawMoreThanCurrentAmountExeption>(mauvaisAppel);
        }

        [Fact]         
        public void CreatingCurrencyHolderWithNameBetween4Than10CharacterThrowExeption() 
        {
            //test pour un nom de currency entre 4 et 10 caracteres
            Action mauvaisAppel1 = () => new CurrencyHolder("EU",EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel1);

            // test pour un nom de 12 caracteres
            Action mauvaisAppel2 = () => new CurrencyHolder("AZERTYUIOPQS",EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel2);
        }

        [Fact]         
        public void StoreMoreThanCurrentAmountInCurrencyHolderThrowExeption()        {
            //test pour ne peux pas mettre des currency dans un CurrencyHolder si ca le fait depasser sa capacité
            Action mauvaisAppel = () => {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,250,200);
            ch.Withdraw(-20);
            };
            Assert.Throws<CantWitchDrawMoreThanCurrentAmountExeption>(mauvaisAppel);       
                          
        }  
        
        [Fact]         
        public void CantCreateCurrencyHolderWithHThrowExeption()        {
            //test pour nom de currency ne commencant pas par une majuscule H par exemple
            Action mauvaisAppel = () => {
            var ch = new CurrencyHolder("Hdfhstjs",200,0);            
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);  

        }
        [Fact]         
        public void CantCreateCurrencyHolderWithhThrowExeption()        {
            //test pour nom de currency ne commencant pas par par une minuscule h par exemple
            Action mauvaisAppel = () => {
            var ch = new CurrencyHolder("hfgjgd",200,0);            
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);  

        }
        [Fact]         
        public void CantCreateCurrencyHolderWith0CapacityThrowExeption()        {
            //test CurrencyHolder ne peux avoir une capacité inférieure à 1
            Action mauvaisAppel = () => {
            var ch = new CurrencyHolder("essai",0,0);            
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);  

        }

        [Fact]  
        public void IsEmptyTrue()        {
        //test pour la méthode
            var ch = new CurrencyHolder("Test",250,0);
            Assert.True(ch.IsEmpty());
            }

             [Fact]  
        public void IsEmptyFalse()        {
            var ch = new CurrencyHolder("Test",250,100);
            Assert.False(ch.IsEmpty());
            }

            [Fact]  
        public void IsFullTrueTest()        {
            //test pour un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité 
            var ch = new CurrencyHolder("Test",250,250);
            Assert.True(ch.IsFull());
            var sac = new CurrencyHolder("Test",500,500);
            Assert.True(sac.IsFull());
            }
        public void IsFullFalseTest()        {
            var ch = new CurrencyHolder("Test",250,240);
            Assert.False(ch.IsFull());
            var sac = new CurrencyHolder("Test",300,200);
            Assert.False(sac.IsFull());
            }
        
    }
}