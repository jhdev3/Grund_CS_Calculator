# Grund_CS_Calculator
Grund kurs i C#, Uppgift Skapa en enkel Kalkylator! 

Jag använde uppgiften till att öva på git och github.
Har tidigare programmerat i c++
För att lära mig c# så har jag använt Kalkylator uppgiften till att lära mig: 
    -Classes
    -Read/write från fil med lite "pathing"  :)
    - ägnat mig åt lite felhantering för att lära mig språket och syntaxen i c# :) 
    
    Förbättringar på kalkylatorn 

Förbättringar: 	 

        Använda sig av någon annan fil typ än txt och readers/writers för att hantera användar datan.  

        Låta användaren välja om den vill spara sina kalkyler på en separat fil  

        Ge kalkylatorn fler matematiska funktioner som tex Convererar ett tal int till en byte/byteArray beroende på storleken då en byte högsta värde är 256 2^8(8 kolumner) . 
        Blir lite att tänka på som var MSB(Most Value Bit/byte) dvs skiftar åt rätt håll 😉 för stora tal samt hur man gör med +- decimaler blir också en del jobb 😊  

        Optimering av kod, tex mina do while satser göra till while tex:  
        while(!float.TryParse(input, out f), i funktionen Check input float.   

         private bool Check_whitespace(string to_beC) är ganska onödig och kan göras mycket bättre då inmating av färger är CaseSenesitiv så behöver den här funktionen bli                 bättre om den ska hantera DarkGrey eller DarkRed osv 😊 finns sätt att göra det på tar bara lite tid 😉  

 

Alternativ: 

            Låta användaren bestämma vart den vill spara sin “config” fil eller spara den i “user”/dokument/”calculator/ som de flesta spel gör med den typen av filer.  
            Går att göra med c# och använda sig av Environment.GetFolderPath(Environment.SpecialFolder.System));  

            Går även att lägga funktionen: Check_input_float i klassen Calc men den är kvar ifall man vill kontrollera input i tidigare skede 😉 
 

