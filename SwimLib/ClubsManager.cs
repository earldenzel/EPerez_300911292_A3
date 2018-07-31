using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SwimLib
{
    public class ClubsManager : IClubsRepository
    {
        private Club[] clubs;
        private int number;
        private SwimmersManager swimmerManager;

        public ClubsManager()
        {
            clubs = new Club[100];
            number = 0;
        }

        public Club[] Clubs
        {
            get
            {
                return clubs;
            }

            set
            {
                clubs = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public SwimmersManager SwimmerManager
        {
            get
            {
                return swimmerManager;
            }

            set
            {
                swimmerManager = value;
            }
        }

        public void Add(Club aClub)
        {
            if (GetByRegNum((uint)aClub.Number) != null)
            {
                throw new Exception("Invalid club record. Club with the registration number already exists:");
            }
            else
            {
                clubs[Number] = aClub;
                Number++;
            }
        }

        public Club GetByRegNum(uint regNumber)
        {
            if (number == 0)
            {
                return null;
            }
            for(int i = 0; i<number; i++)
            {
                if(clubs[i].Number == regNumber)
                {
                    return clubs[i];
                }
            }
            return null;
        }

        public Club[] Load(string filename, string delimiter)
        {
            FileStream inFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string recordIn = reader.ReadLine();
            string[] fields;
            while (recordIn != null)
            {
                fields = recordIn.Split(new string[] { delimiter }, StringSplitOptions.None); //tables from Assignment 2 pdf called for a string delimiter and not a char delimiter
                Club newClub;
                uint clubNumber = 0;
                long phoneNumber;
                
                try
                {
                    clubNumber = Convert.ToUInt32(fields[0]);
                    phoneNumber = Convert.ToInt64(fields[6]);
                    newClub = new Club(fields[1], new Address(fields[2], fields[3], fields[4], fields[5]), phoneNumber, (int)clubNumber);
                    Add(newClub);
                }
                catch(FormatException ex)
                {
                    if (ex.ToString().Contains("ToUInt32"))
                    {
                        Console.WriteLine("Invalid club record. Club number is not valid:\n\t{0}", recordIn);
                    }
                    else if (ex.ToString().Contains("ToInt64"))
                    {
                        Console.WriteLine("Invalid club record. Phone number wrong format:\n\t{0}", recordIn);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}\n\t{1}", ex.Message, recordIn);
                }
                finally
                {
                    recordIn = reader.ReadLine();
                }
            }
            reader.Close();
            inFile.Close();
            return clubs;

        }

        public void Save(string filename, string delimiter)
        {
            FileStream outFile = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            for (int i = 0; i < Number; i++)
            {
                Club club = clubs[i];
                string line = club.Number + delimiter + club.Name + delimiter;
                line += club.Address.StreetAddress + delimiter + club.Address.Municipality + delimiter + club.Address.Province + delimiter + club.Address.ZipCode + delimiter;
                line += club.PhoneNumber;
                writer.WriteLine(line);
            }
            writer.Close();
            outFile.Close();

        }
    }
}
