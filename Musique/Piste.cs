using Music;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Music


{

    /// <summary>
    /// @ pour indiquer qu'une chaîne est un chemin
    /// </summary>
    [DataContract(Name = "Piste", Namespace = "Musique")]
    [KnownType(typeof(Note<notes>))]
    [KnownType(typeof(Silence))]





    public class Piste : IPiste
    {


        [DataMember()]
        private List<INote> notes = new List<INote>();

        private AStyle style;

        public Piste(AStyle style)
        {
            this.style = style;
        }

        public AStyle Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
            }
        }

        public void addNote(INote note)
        {

            notes.Add(note);
        }


        public void jouer()
        {
            foreach (INote note in notes)
            {
                float pause = style.tempo();
                Console.Out.WriteLine(pause);
                System.Threading.Thread.Sleep((int)(pause));


                note.jouer();
            }
        }

        public void convertToWav()
        {


            int sampleRate = 44100;


            List<double> data = new List<double>();

            SineOccilator rs = new SineOccilator(44100);


            foreach (INote n in notes)
            {
                double freq = (double)((Note<notes>)n).Frequency;
                rs.SetFrequency(freq);

                for (int i = 0; i < sampleRate * 2; i++)
                {
                    data.Add(rs.GetNext(i));
                }
            }


            SaveIntoStream("test14", data.ToArray(), data.Count, sampleRate); 


        }



        public static FileStream SaveIntoStream(string fileName, double[] sampleData, long sampleCount, int samplesPerSecond)
        {
            // Export
            FileStream stream = File.Create(fileName + ".wav");
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream);
            int RIFF = 0x46464952;
            int WAVE = 0x45564157;
            int formatChunkSize = 16;
            int headerSize = 8;
            int format = 0x20746D66;
            short formatType = 1;
            short tracks = 2;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int data = 0x61746164;
            int samples = (int)sampleCount;
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            writer.Write(RIFF);
            writer.Write(fileSize);
            writer.Write(WAVE);
            writer.Write(format);
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(data);
            writer.Write(dataChunkSize);

            double sample_l;
            short sl;
            for (int i = 0; i < sampleCount; i++)
            {
                sample_l = sampleData[i] * 30000.0;
                if (sample_l < -32767.0f) { sample_l = -32767.0f; }
                if (sample_l > 32767.0f) { sample_l = 32767.0f; }
                sl = (short)sample_l;
                stream.WriteByte((byte)(sl & 0xff));
                stream.WriteByte((byte)(sl >> 8));
                stream.WriteByte((byte)(sl & 0xff));
                stream.WriteByte((byte)(sl >> 8));
            }

            stream.Close();

            //BufferedWaveProvider bwp = new BufferedWaveProvider(new WaveFormat());
            //stream.Position = 0;
            //BinaryReader br = new BinaryReader(stream);


            //for (int i = 0; i < stream.Length / 4; i++)
            //{
            //    bwp.AddSamples(br.ReadBytes(4), (int)stream.Position, 4);
            //}

            //WaveOut wo = new WaveOut();
            //wo.Init(bwp);
            //wo.Play();

            return stream;
        }

    }
}


    
        
    

