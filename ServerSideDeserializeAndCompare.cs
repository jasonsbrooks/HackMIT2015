Enter file contents hereusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceAFIS.Simple;
using System.Drawing;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication2
{
    class Program
    {
        private static object Afis;
        private static Person[] people = new Person[10];
        private static int count = 0;
        static void storeImage(string filepath, AfisEngine Afis)
        {
            Fingerprint fp1 = new Fingerprint();
            fp1.AsBitmap = new Bitmap(Image.FromFile(filepath));
            Person person = new Person();
            person.Fingerprints.Add(fp1);
            Afis.Extract(person);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, person);
            stream.Close();
            //people[count] = person;
            //count++;
        }

        static void Main(string[] args)
        {

            AfisEngine Afis = new AfisEngine();
            Afis.Threshold = 0;
            //storeImage(args[0], Afis);
            //storeImage("C:\\Users\\Admin\\Downloads\\Images-2015-09-20\\Images\\Daniel\\9.bmp", Afis);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(args[0], FileMode.Open, FileAccess.Read, FileShare.Read);
            Person person1 = (Person)formatter.Deserialize(stream);
            stream.Close();

            IFormatter formatter2 = new BinaryFormatter();
            Stream stream2 = new FileStream(args[1], FileMode.Open, FileAccess.Read, FileShare.Read);
            Person person2 = (Person)formatter.Deserialize(stream2);
            stream.Close();
            //System.Console.WriteLine(person);
            //System.Threading.Thread.Sleep(15000);
            //storeImage("C:\\Users\\Admin\\Downloads\\Images-2015-09-20\\Images\\Daniel\\1.bmp", Afis);
            //storeImage("C:\\Users\\Admin\\Downloads\\Images-2015-09-20\\Images\\Henok\\6.bmp", Afis);
            //storeImage("C:\\Users\\Admin\\Downloads\\Images-2015-09-20\\Images\\Prashan\\1.bmp", Afis);
            //storeImage("C:\\Users\\Admin\\Downloads\\Images-2015-09-20\\Images\\1 - Copy (7)\\identify_2015-09-19_19-34-48_00.bmp", Afis);
            System.Console.WriteLine(Afis.Verify(person1, person2));
            //System.Console.WriteLine(Afis.Verify(people[0], people[2]));
            //System.Console.WriteLine(Afis.Verify(people[0], people[3]));
            //System.Console.WriteLine(Afis.Verify(people[0], people[4]));
            //System.Threading.Thread.Sleep(15000);
        }
    }
}
