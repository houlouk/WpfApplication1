using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public enum notes {
            DO1 =33, DO1d=35,RE1=37, RE1d=39, MI1=41, FA1=44, FA1d=46, SOL1=49, SOL1d=52, LA1=55, LA1d=58, SI1=62,
        DO2 = 33, DO2d = 35, RE2 = 37, RE2d = 39, MI2 = 41, FA2 = 44, FA2d = 46, SOL2 = 49, SOL2d = 52, LA2 = 55, LA2d = 58, SI2 = 62,
        DO3 = 33, DO3d = 35, RE3 = 37, RE3d = 39, MI3 = 41, FA3 = 44, FA3d = 46, SOL3 = 49, SOL3d = 52, LA3 = 55, LA3d = 58, SI3 = 62,
        DO4 = 33, DO4d = 35, RE4 = 37, RE4d = 39, MI4 = 41, FA4 = 44, FA4d = 46, SOL4 = 49, SOL4d = 52, LA4 = 55, LA4d = 58, SI4 = 62,
        DO5 = 33, DO5d = 35, RE5 = 37, RE5d = 39, MI5 = 41, FA5 = 44, FA5d = 46, SOL5 = 49, SOL5d = 52, LA5 = 55, LA5d = 58, SI5 = 62,
        DO6 = 33, DO6d = 35, RE6 = 37, RE6d = 39, MI6 = 41, FA6 = 44, FA6d = 46, SOL6 = 49, SOL6d = 52, LA6 = 55, LA6d = 58, SI6 = 62,
        DO7 = 33, DO7d = 35, RE7 = 37, RE7d = 39, MI7 = 41, FA7 = 44, FA7d = 46, SOL7 = 49, SOL7d = 52, LA7 = 55, LA7d = 58, SI7 = 62,
        DO8=4186


    };

    public enum notesBlanches
    {
        DO1 = 33,  RE1 = 37, MI1 = 41, FA1 = 44, SOL1 = 49, LA1 = 55, SI1 = 62,
        DO2 = 65,  RE2 = 73, MI2 = 82, FA2 = 87, SOL2 = 98, LA2 = 110, SI2 = 123,
        DO3 = 131,  RE3 = 147, MI3 = 165, FA3 = 175, SOL3 = 196, LA3 = 220, SI3 = 247,
        DO4 = 262,  RE4 = 294, MI4 = 330, FA4 = 349, SOL4 = 392, LA4 = 440, SI4 = 494,
        DO5 = 523,  RE5 = 587, MI5 = 659, FA5 = 698, SOL5 = 784, LA5 = 880, SI5 = 988,
        DO6 = 1047,  RE6 = 1175, MI6 = 1319, FA6 = 1397, SOL6 = 1568, LA6 = 1760, SI6 = 1976,
        DO7 = 2093,  RE7 = 2349, MI7 = 2637, FA7 = 2794, SOL7 = 3136, LA7 = 3520, SI7 = 3951,
        DO8 = 4186

    };

    public enum notesNoires
    {
         DO1d = 35, RE1d = 39, FA1d = 46, SOL1d = 52, LA1d = 58,
         DO2d = 35, RE2d = 39, FA2d = 46, SOL2d = 52, LA2d = 58,
         DO3d = 35, RE3d = 39, FA3d = 46, SOL3d = 52, LA3d = 58, 
         DO4d = 35, RE4d = 39, FA4d = 46, SOL4d = 52, LA4d = 58, 
         DO5d = 35, RE5d = 39, FA5d = 46, SOL5d = 52, LA5d = 58, 
         DO6d = 35, RE6d = 39, FA6d = 46, SOL6d = 52, LA6d = 58,
         DO7d = 35, RE7d = 39, FA7d = 46, SOL7d = 52, LA7d = 58,
        SILENCE = 59
    };

    public enum dureeNote { RONDE = 400, BLANCHE = 200, NOIRE = 100, CROCHE = 50, DOUBLECROCHE = 25 };
    class Program
    {
        static void Main(string[] args)
        {

            //IChanson c = (IChanson)SaverLoader<Chanson>.read("ChansonSauvee.xml");
            //Console.Out.WriteLine(c.ToString());


            AStyle style = new HipHop();
            IPiste piste = new Piste(style);
            IPiste piste2 = new Piste(style);

            AStyle style2 = new Tango();
            ConsoleKeyInfo MaTouche;
            string[] TabTouche = new string[] { "Do = D", "Dod = Z", "Ré = R", "Réd = T", "Mi = E", "Fa = F", "Fad = J", "Sol = G", "Sold = K", "La = L", "Lad = Y", "Si = B" };

            
            piste2.addNote(new Note<notes>(style, notes.SOL1,dureeNote.NOIRE));
            piste2.addNote(new Note<notes>(style,notes.SOL1,dureeNote.DOUBLECROCHE));
            piste2.addNote(new Note<notes>(style, notes.SOL1,dureeNote.RONDE));
            piste2.addNote(new Note<notes>(style, notes.LA1,dureeNote.CROCHE));
            piste2.addNote(new Note<notes>(style, notes.SI1, dureeNote.BLANCHE));
            piste2.addNote(new Note<notes>(style, notes.LA1,dureeNote.NOIRE));
            piste2.addNote(new Note<notes>( style,notes.SOL1,dureeNote.BLANCHE));
            piste2.addNote(new Note<notes>(style, notes.SI1,dureeNote.RONDE));
            piste2.addNote(new Note<notes>(style, notes.LA1,dureeNote.NOIRE));
            piste2.addNote(new Note<notes>( style,notes.LA1,dureeNote.DOUBLECROCHE));
            piste2.addNote(new Note<notes>( style,notes.SOL1,dureeNote.RONDE));

            //piste.jouer();

            piste2.convertToWav();


            Console.Out.WriteLine("Tapez votre numéro de style");

            Console.Out.WriteLine("1 : Tango");
            Console.Out.WriteLine("2 : HipHop");

            string votreStyle = Console.In.ReadLine();


            switch (votreStyle)
            {
                case "1":
                    piste.Style = new Tango();
                    break;

                case "2":
                    piste.Style = new HipHop();
                    break;
                default:
                    try
                    {
                        throw new Exception("Mauvais style");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                    break;
            }
            for (int i = 0; i < TabTouche.Length; i++) { Console.WriteLine(TabTouche[i]); }
            do
            {
                Console.WriteLine("Entrez les Note<notes>s\n");
                MaTouche = Console.ReadKey();
                switch (MaTouche.KeyChar)
                {
                    case 's':
                        piste.addNote(new Silence(style, dureeNote.NOIRE));
                        INote MaNos = new Silence(style, dureeNote.NOIRE);
                        MaNos.jouer();
                        break;
                    case 'd':
                        piste.addNote(new Note<notes>(style, notes.DO1, dureeNote.NOIRE));
                        Note<notes> MaNo = new Note<notes>(style, notes.DO1, dureeNote.NOIRE);
                        MaNo.jouer();
                        break;
                    case 'z':
                        piste.addNote(new Note<notes>(style, notes.DO1d, dureeNote.NOIRE));
                        Note<notes> MaNod = new Note<notes>(style, notes.DO1d, dureeNote.NOIRE);
                        MaNod.jouer();
                        break;
                    case 'r':
                        piste.addNote(new Note<notes>(style, notes.RE1, dureeNote.NOIRE));
                        Note<notes> MaNo2 = new Note<notes>(style, notes.RE1, dureeNote.NOIRE);
                        MaNo2.jouer();
                        break;
                    case 't':
                        piste.addNote(new Note<notes>(style, notes.RE1d, dureeNote.NOIRE));
                        Note<notes> MaNo3 = new Note<notes>(style, notes.RE1d, dureeNote.NOIRE);
                        MaNo3.jouer();
                        break;
                    case 'e':
                        piste.addNote(new Note<notes>(style, notes.MI1, dureeNote.NOIRE));
                        Note<notes> MaNo4 = new Note<notes>(style, notes.MI1, dureeNote.NOIRE);
                        MaNo4.jouer();
                        break;
                    case 'f':
                        piste.addNote(new Note<notes>(style, notes.FA1, dureeNote.NOIRE));
                        Note<notes> MaNo5 = new Note<notes>(style, notes.FA1, dureeNote.NOIRE);
                        MaNo5.jouer();
                        break;
                    case 'j':
                        piste.addNote(new Note<notes>(style, notes.FA1d, dureeNote.NOIRE));
                        Note<notes> MaNo6 = new Note<notes>(style, notes.FA1d, dureeNote.NOIRE);
                        MaNo6.jouer();
                        break;
                    case 'g':
                        piste.addNote(new Note<notes>(style, notes.SOL1, dureeNote.NOIRE));
                        Note<notes> MaNo7 = new Note<notes>(style, notes.SOL1, dureeNote.NOIRE);
                        MaNo7.jouer();
                        break;
                    case 'k':
                        piste.addNote(new Note<notes>(style, notes.SOL1d, dureeNote.NOIRE));
                        Note<notes> MaNo8 = new Note<notes>(style, notes.SOL1d, dureeNote.NOIRE);
                        MaNo8.jouer();
                        break;
                    case 'a':
                        piste.addNote(new Note<notes>(style, notes.LA1, dureeNote.NOIRE));
                        Note<notes> MaNo9 = new Note<notes>(style, notes.LA1, dureeNote.NOIRE);
                        MaNo9.jouer();
                        break;
                    case 'y':
                        piste.addNote(new Note<notes>(style, notes.LA1d, dureeNote.NOIRE));
                        Note<notes> MaNoy = new Note<notes>(style, notes.LA1d, dureeNote.NOIRE);
                        MaNoy.jouer();
                        break;
                    case 'b':
                        piste.addNote(new Note<notes>(style, notes.SI1, dureeNote.NOIRE));
                        Note<notes> MaNob = new Note<notes>(style, notes.SI1, dureeNote.NOIRE);
                        MaNob.jouer();
                        break;
                }
            } while (MaTouche.KeyChar == 'd' || MaTouche.KeyChar == 'z' || MaTouche.KeyChar == 'r' || MaTouche.KeyChar == 't' ||
            MaTouche.KeyChar == 'e' || MaTouche.KeyChar == 'f' || MaTouche.KeyChar == 'j' || MaTouche.KeyChar == 'g' ||
            MaTouche.KeyChar == 'k' || MaTouche.KeyChar == 'a' || MaTouche.KeyChar == 'y' || MaTouche.KeyChar == 'b' || MaTouche.KeyChar == 's');

            IChanson chanson = new Chanson();
            chanson.addPiste(piste);
            chanson.addPiste(piste2);
            chanson.jouer();

            chanson.save("ChansonSauvee.xml");


            Console.ReadKey();
        }
        enum NoteClavier { D, Z, R, T, M, F, J, S, K, L, E, B };
    }
}


   