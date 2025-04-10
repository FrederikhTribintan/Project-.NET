using System;

// Declare struct as global properties
struct Mahasiswa {
    public int NIM;
    public string Nama;
    public int[] Tugas;

    // Constructor
    public Mahasiswa(int nim, string nama, int[] tugas){
        NIM = nim;
        Nama = nama;
        Tugas = tugas;
    }
}

class Program {
    static void Main(){
        // Declare mahasiswa struct to store mahasiswa
        Mahasiswa[] mhsArray = new Mahasiswa[3];

        // Call function to input each data mahasiswa
        InputDataTugas(mhsArray);

        // Clear console
        Console.Clear();

        // Create a 'table' structure for each student's details
        Console.WriteLine("No.\tNIM\tNama\t\t\tTugas-1\tTugas-2\tTugas-3");

        // Iterate through each student's details
        for(int i = 0; i < mhsArray.Length; i++){
            // Call function to print out each student's details
            CetakDataMahasiswa(mhsArray, i);
        }   
    }

    static void InputDataTugas(Mahasiswa[] mhsArray){
        // Iterate over the number of students = 3
        for(int i = 0; i < 3; i++){
            Console.Clear();
            Console.WriteLine($"Masukan detail Mahasiswa ke-{i + 1}: ");

            int nim = InputNIM();

            Console.Write("Nama: ");
            string nama = Console.ReadLine();

            int[] tugas = new int[3];
            for(int j = 0; j < 3; j++){
                Console.Write($"Ujian ke-{j + 1}: ");
                tugas[j] = int.Parse(Console.ReadLine());
            }

            // Store the data in the array to struct mhsArray
            mhsArray[i] = new Mahasiswa(nim, nama, tugas);
        }
    }

    static int InputNIM(){
        int nim;
        while (true)
        {
            try{
                Console.Write("NIM: ");
                nim = int.Parse(Console.ReadLine());
                break;
            }   
            catch(FormatException){
                Console.WriteLine("ERROR: NIM should contain numerical values, not alphabetic characters. Please re-input the NIM.");
            }
        }
        return nim; 
    }

    static void CetakDataMahasiswa(Mahasiswa[] mhsArray, int i){
        Console.Write($"{i + 1}.");
        Console.Write($"\t{mhsArray[i].NIM}");
        Console.Write($"\t{mhsArray[i].Nama}");
        for(int j = 0; j < mhsArray[i].Tugas.Length; j++){
            Console.Write($"\t{mhsArray[i].Tugas[j]}");
        } 
        Console.WriteLine();
    }
}
