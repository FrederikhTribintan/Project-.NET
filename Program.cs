/*
Name: Frederikh Tribintan
NIM : 2281058
*/

using System;

namespace Tekotek
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("T E K O T E K");
            Console.WriteLine("jumlah anak ayam: ");
            int ayam = int.Parse(Console.ReadLine());

            Console.WriteLine("Tekkotek kotek kotek \nanak ayam turun berkotek");
            for(int i = ayam; i >= 1; i--){
                if (i > 1){
                    Console.WriteLine("Anak ayam turun "+ i +"\nmati satu tinggal " + (i-1) +"\ntekkotek kotek kotek anak ayam turun berkotek");
                }else{
                    Console.WriteLine("Anak ayam turun satu \nmati satu tinggal induknya");
                }
            }
        }
    }
}